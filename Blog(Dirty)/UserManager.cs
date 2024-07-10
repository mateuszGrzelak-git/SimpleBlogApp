using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Blog_Dirty_
{
    internal class UserManager
    {
        private static SqlConnection connection = new SqlConnection();
        private static string databaseSource = "Data Source=(local);Initial Catalog=UserRepository;Integrated Security=True";
        public void createDatabase()
        {
            connection.ConnectionString = databaseSource;
            connection.Open();
        }

        public void closeDatabase()
        {
            connection.Close();
        }

        private static SqlDataAdapter adapter = new SqlDataAdapter();
        public int executeDataAdapter(DataTable tblName, string databaseCommands)
        {
            if (connection.State == 0)
            {
                createDatabase();
            }

            adapter.SelectCommand.CommandText = databaseCommands;
            adapter.SelectCommand.CommandType = CommandType.Text;
            SqlCommandBuilder DbCommandBuilder = new SqlCommandBuilder(adapter);

            string insert = DbCommandBuilder.GetInsertCommand().CommandText.ToString();
            string update = DbCommandBuilder.GetUpdateCommand().CommandText.ToString();
            string delete = DbCommandBuilder.GetDeleteCommand().CommandText.ToString();

            return adapter.Update(tblName);
        }

        private static SqlCommand command = new SqlCommand();
        public void readDataFromCommands(string query, DataTable tblName)
        {
            command.Connection = connection;
            command.CommandText = query;
            command.CommandType = CommandType.Text;

            adapter = new SqlDataAdapter(command);
            adapter.Fill(tblName);
        }

        private static SqlDataReader readDataFromStream(string query)
        {
            SqlDataReader reader;

            command.Connection = connection;
            command.CommandText = query;
            command.CommandType = CommandType.Text;

            reader = command.ExecuteReader();
            return reader;
        }

        public int executeQuery(SqlCommand dbCommand)
        {
            dbCommand.Connection = connection;
            dbCommand.CommandType= CommandType.Text;

            return dbCommand.ExecuteNonQuery();
        }
    }
}
