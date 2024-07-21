using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Blog_Dirty_
{
    /// <summary>
    /// Class <c>PostsManager</c> manages posts in the repository
    /// </summary>
    public class PostsManager
    {
        /// <summary>
        /// contains PostsRepository class initialized in constructor
        /// </summary>
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
        /// <summary>
        /// Checks if post was created or not
        /// </summary>
        /// <list type="bullet">
        /// <item><param name="postName">name of the post to check</param></item>
        /// </list>
        /// <returns>true or false</returns>
        public bool isPostExists(string postName)
        {
            try
            {
                SqlCommand checkIfExists = new SqlCommand("select count(*) from posts where PostName= @postName", _repository.getConnection()); //connection at end
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
        /// <summary>
        /// Adds post to the database
        /// </summary>
        /// <param name="user">User class who created the post</param>
        /// <param name="postName">name of the post to be created</param>
        /// <param name="postData">data of post which user wrote</param>
        public void addPost(User user, string postName, string postData)
        {
            string username = user.UserName;

            SqlCommand addToDatabase = new SqlCommand("insert into posts(username, postName, postData) values(@username, @postName, @postData)", _repository.getConnection());

            addToDatabase.Parameters.AddWithValue("username", username);
            addToDatabase.Parameters.AddWithValue("postName", postName);
            addToDatabase.Parameters.AddWithValue("postData", postData);

            _repository.executeQuery(addToDatabase);
        }
        /// <summary>
        /// removes post from the database
        /// </summary>
        /// <param name="posts">Posts class which will be removed</param>
        /// <exception cref="Exception">throws if the post was not created</exception>
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
                SqlCommand deleteFromDatabase = new SqlCommand("DELETE from Posts Where PostName = '" + postName + "'" + "AND username = " + "'username'", _repository.getConnection());

                deleteFromDatabase.Parameters.AddWithValue("PostName", postName);
                deleteFromDatabase.Parameters.AddWithValue("username", username);

                _repository.executeQuery(deleteFromDatabase);
            }
        }

        /// <summary>
        /// search for posts of the selected author
        /// </summary>
        /// <param name="username">Username of the author</param>
        /// <returns>all posts that were found</returns>
        /// <exception cref="Exception">If no post where find throws exception</exception>
        public string[] searchForUserPosts(string username)
        {
            List<string> result = new List<string>();

            string query = "SELECT * from Posts Where username = @username";
            SqlCommand searchInDatabase = new SqlCommand(query, _repository.getConnection());

            searchInDatabase.Parameters.AddWithValue("@username", username);

            using (SqlDataReader reader = searchInDatabase.ExecuteReader())
            {
                while (reader.Read())
                {
                    string postData = reader[3].ToString();
                    result.Add(postData);
                }
            }

            if (result.Count == 0)
            {
                throw new Exception("No rows");
            }

            return result.ToArray();
        }


        /// <summary>
        /// search for the post by selected author and postName
        /// </summary>
        /// <param name="username">Author of the post</param>
        /// <param name="postName">Name of the post that someone is looking</param>
        /// <returns>First post that was found</returns>
        /// <exception cref="Exception"></exception>
        public string[] searchForSpecifiedPost(string username, string postName)
        {
            List<string> result = new List<string>();

            string query = "SELECT * from Posts Where username = '" + username + "'";
            SqlCommand searchInDatabase = new SqlCommand("SELECT * from Posts Where username = '" + username + "'" + " AND " + "postname = '" + postName + "'", _repository.getConnection());

            searchInDatabase.Parameters.AddWithValue("username", username);

            using (SqlDataReader reader = searchInDatabase.ExecuteReader())
            {
                if (reader.Read())
                {

                    string postData = reader[2].ToString();
                    result.Add(postData);
                }
                else
                {
                    throw new Exception("No rows");
                }
            }

            return result.ToArray();
        }
    }
}
