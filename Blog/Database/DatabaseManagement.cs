using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Data.SqlClient;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Web;
using System.Data;
using Azure.Identity;

namespace Blog.Database
{
    public class DatabaseManagement
    {
        private SqlCommand cmd;
        private string connectionString;
        private SqlConnection conn;
        private SqlDataAdapter adapter;
        private bool databaseExistence = false;
        public DatabaseManagement(string connectionStringArg)
        {
            DatabaseTest database = new DatabaseTest();
            databaseExistence = database.isDatabaseExists(connectionStringArg);
            if (!databaseExistence)
            {
                //throw new Exception("Connection string passed to DatabaseManagement class is incorrect!!!");
                //return HttpStatusCode.InternalServerError;
                /* < a class="nav-link text-dark" asp-area="" asp-page="/FrontEnd/loginPage/login">Login</a>
      */
                
            }
            else
            {
                connectionString = connectionStringArg;
                this.conn = new SqlConnection(connectionString);
                conn.Open();
                this.cmd = new SqlCommand(connectionString);
                this.adapter = new SqlDataAdapter();
            }
        }

        public void addValue(string author, string postName, string postData)
        {
            cmd = new SqlCommand("insert into onlinePosts(username, postName, postData) values(@username, @postName, @postData)", new SqlConnection());    

            cmd.Parameters.AddWithValue("username", author);
            cmd.Parameters.AddWithValue("postName", postName);
            cmd.Parameters.AddWithValue("postData", postData);

            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;

            cmd.ExecuteNonQuery();
        }

        public void addValue(string login, string password)
        {
            cmd = new SqlCommand("insert into Users(login, password) values(@login, @password)", new SqlConnection());

            cmd.Parameters.AddWithValue("login", login);
            cmd.Parameters.AddWithValue ("password", password);

            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;

            cmd.ExecuteNonQuery();
        }

        public void removeValue(int id, char firstLetterOfDatabase)
        {
            SqlCommand removeFromDatabase;
            if(firstLetterOfDatabase=='U')
            {
                removeFromDatabase = new SqlCommand("DELETE FROM Users WHERE ID=@id");
            }
            else if(firstLetterOfDatabase=='P')
            {
                removeFromDatabase = new SqlCommand("DELETE FROM onlinePosts WHERE ID=@id");
            }
            else
            {
                throw new Exception("Unknown Database");
            }

            removeFromDatabase.Parameters.AddWithValue("id", id);

            cmd.ExecuteNonQuery();
        }

        public void removeValue(string postName)
        {
            SqlCommand removeFromDatabase = new SqlCommand("DELETE FROM onlinePosts WHERE postName=@postName");

            removeFromDatabase.Parameters.AddWithValue("postName", postName);

            cmd.ExecuteNonQuery();
        }

        public string getValue(int id)
        {
            SqlCommand cmd = new SqlCommand("SELECT login FROM users WHERE ID=@id");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;

            cmd.Parameters.AddWithValue("id", id);

            string author = "";

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    // Odczytaj każdą z trzech kolumn
                    author = reader.GetString(0); // Odczytuje pierwszą kolumnę jako string (username)
                }
            }

            return author;
        }
        public int GetLastId()
        {
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 ID FROM Users ORDER BY ID DESC", conn); // Zakładam, że tabela nazywa się Posts, a kolumna z ID to PostID
                
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;

            int id = 1;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while(reader.Read())
                {
                    id = reader.GetInt32(0);
                }
            }
            return id;
        }
        
        public string getBlogData(string postName)
        {
            SqlCommand cmd = new SqlCommand("SELECT postData FROM onlinePosts WHERE postName=@postName");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;

            cmd.Parameters.AddWithValue("postName", postName);

            string blogData = "";

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    // Odczytaj każdą z trzech kolumn
                    blogData = reader.GetString(0); // Odczytuje pierwszą kolumnę jako string (username)
                }
            }
            return blogData;
        }

        public void updateValue(int id)
        {
            SqlCommand updateFromDatabase = new SqlCommand();

            updateFromDatabase.Parameters.AddWithValue("id", id);
        }

        public string getConnectionString()
        {
            return connectionString;
        }

        ~DatabaseManagement()
        {
            if (databaseExistence)
            {
                conn.Close();
            }
        }

        public List<string> GetUsersHistory()
        {
            List<string> users = new List<string>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT login FROM Users"; // Tutaj dopasuj zapytanie SQL do swojej bazy danych

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string username = reader.GetString(0); // Odczytuje pierwszą kolumnę jako string
                                users.Add(username);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Tutaj możesz dodać logowanie błędów lub inny sposób obsługi wyjątków
                Console.WriteLine("Błąd podczas pobierania historii użytkowników: " + ex.Message);
            }

            return users;
        }

        public List<string> GetBlogsHistory()
        {
            List<string> blogs = new List<string>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString)) // poprawiona nazwa pola _connectionString
                {
                    connection.Open();

                    // Dopasuj zapytanie SQL do swojej bazy danych
                    string query = "SELECT username, postName, postData FROM onlinePosts";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Odczytaj każdą z trzech kolumn
                                string username = reader.GetString(0); // Odczytuje pierwszą kolumnę jako string (username)
                                string postName = reader.GetString(1); // Odczytuje drugą kolumnę jako string (postName)
                                string postData = reader.GetString(2); // Odczytuje trzecią kolumnę jako DateTime (postData)

                                // Dodaj sformatowany string do listy
                                blogs.Add($"User: {username}, Post: {postName}, Data: {postData}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Obsługa błędów
                Console.WriteLine("Błąd podczas pobierania historii blogów: " + ex.Message);
            }

            return blogs;
        }

    }
}
