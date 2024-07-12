using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Dirty_
{
    public class UserManager
    {
        private UserRepository _repository;
        public UserManager()
        {
            _repository = new UserRepository();
            _repository.createDatabase();
        }
        ~UserManager()
        {
            _repository.closeDatabase();
        }

        public bool isUsernameFree(string username)
        {
            try
            {
                SqlCommand checkIfFree = new SqlCommand("select count(*) from users where username= @username"); //connection at end
                checkIfFree.Parameters.AddWithValue("username", username);

                _repository.executeQuery(checkIfFree);

                object result = checkIfFree.ExecuteScalar();
                if ((int)result == 0)
                {
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                return true;
            }
        }
        public void addUser(string username, string password)
        {
            if (!isUsernameFree(username))
            {
                throw new Exception("Username already exists");
            }
            else
            {
                SqlCommand addToDatabase = new SqlCommand("insert into Users(username, password) values(@username, @password)");

                addToDatabase.Parameters.AddWithValue("username", username);
                addToDatabase.Parameters.AddWithValue("password", password);

                _repository.executeQuery(addToDatabase);
            }
        }

        public void removeUser(User user)
        {
            string username = user.UserName;

            if (isUsernameFree(username))
            {
                throw new Exception("Username not exists");
            }
            else
            {
                SqlCommand deleteFromDatabase = new SqlCommand("DELETE from Users Where UserName = '" + username + "'");

                deleteFromDatabase.Parameters.AddWithValue("username", username);

                _repository.executeQuery(deleteFromDatabase);
            }
        }
    }
}
