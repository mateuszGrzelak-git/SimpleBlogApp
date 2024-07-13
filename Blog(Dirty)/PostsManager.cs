using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Blog_Dirty_
{
    public class PostsManager
    {
        private PostsRepository _repository;

        public PostsManager()
        {
            _repository = new PostsRepository();
            _repository.createDatabase();
        }
        ~PostsManager()
        {
            _repository.closeDatabase();
        }

        public bool isPostExists(string postName)
        {
            try
            {
                SqlCommand checkIfExists = new SqlCommand("select count(*) from posts where PostName= @postName"); //connection at end
                checkIfExists.Parameters.AddWithValue("postName", postName);

                _repository.executeQuery(checkIfExists);

                object result = checkIfExists.ExecuteScalar();
                if ((int)result == 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return true;
            }
        }
        public void addPost(User user, string postName, string postData)
        {
            string username = user.UserName;

            SqlCommand addToDatabase = new SqlCommand("insert into posts(username, postName, postData) values(@username, @postName, @postData)");

            addToDatabase.Parameters.AddWithValue("username", username);
            addToDatabase.Parameters.AddWithValue("postName", postName);
            addToDatabase.Parameters.AddWithValue("postData", postData);

            _repository.executeQuery(addToDatabase);
        }

        public void removePost(Posts posts)
        {
            string postName = posts.postName;
            if (!isPostExists(postName))
            {
                throw new Exception("Post not exists");
            }
            else
            {
                string username = posts.username;
                SqlCommand deleteFromDatabase = new SqlCommand("DELETE from Posts Where PostName = '" + postName + "'" + "AND username = " + "'username'");

                deleteFromDatabase.Parameters.AddWithValue("PostName", postName);
                deleteFromDatabase.Parameters.AddWithValue("username", username);

                _repository.executeQuery(deleteFromDatabase);
            }
        }

        public void searchForUserPosts(string username)
        {
            string query = "SELECT * from Posts Where username = '" + username + "'";
            //SqlCommand searchInDatabase = new SqlCommand("SELECT * from Posts Where username = '" + username + "'");

            //searchInDatabase.Parameters.AddWithValue("username", username);

            DataTable dataTable = new DataTable();

            _repository.readDataFromCommands(query, dataTable);

        }
    }
}
