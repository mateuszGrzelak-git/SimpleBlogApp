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
        /// <summary>
        /// checks if username is free or not
        /// </summary>
        /// <param name="username">username to check</param>
        /// <returns>true or false</returns>
        public bool isUsernameFree(string username)
        {
            try
            {
                SqlCommand checkIfFree = new SqlCommand("select count(*) from users where username= @username", _repository.getConnection()); //connection at end
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
        /// <summary>
        /// adds user to database
        /// </summary>
        /// <param name="username">username of account that was created</param>
        /// <param name="password">hashed password of the account that was created</param>
        /// <exception cref="Exception">If username exists throws error</exception>
        public void addUser(string username, string password)
        {
            if (!isUsernameFree(username))
            {
                throw new Exception("Username already exists");
            }
            else
            {
                SqlCommand addToDatabase = new SqlCommand("insert into Users(username, password) values(@username, @password)", _repository.getConnection());

                addToDatabase.Parameters.AddWithValue("username", username);
                addToDatabase.Parameters.AddWithValue("password", password);

                _repository.executeQuery(addToDatabase);
            }
        }
        /// <summary>
        /// removes user from database
        /// </summary>
        /// <param name="user">class User that represents account to delete</param>
        /// <exception cref="Exception">If account doesnt exists throws error</exception>
        public void removeUser(User user)
        {
            string username = user.UserName;

            if (isUsernameFree(username))
            {
                throw new Exception("Username not exists");
            }
            else
            {
                SqlCommand deleteFromDatabase = new SqlCommand("DELETE from Users Where UserName = '" + username + "'", _repository.getConnection());

                deleteFromDatabase.Parameters.AddWithValue("username", username);

                _repository.executeQuery(deleteFromDatabase);
            }
        }
    }
}
