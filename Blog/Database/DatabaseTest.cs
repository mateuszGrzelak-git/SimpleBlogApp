using Microsoft.Data.SqlClient;

namespace Blog.Database
{
    public class DatabaseTest
    {
        private SqlConnection conn;
        private bool isDatabaseExisting = false;
        public bool isDatabaseExists(string connectionString)
        {
            conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                isDatabaseExisting = true;
                return true;
            }
            catch (Exception ex)
            {
                if (ex.Message == "The ConnectionString property has not been initialized.")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Unkown Error: ");
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }
        ~DatabaseTest()
        {
            conn.Close();
        }
    }
}
