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
    /// Class <c>UserRepository</c> stores all data about posts in sql
    /// </summary>
    public class UserRepository
    {
        /// <summary>
        /// Represents opening of the database
        /// </summary>
        private static SqlConnection connection = new SqlConnection();
        /// <summary>
        /// defines where database is
        /// </summary>
        private static string databaseSource = "Data Source=(local)\\USERDATABASE;Initial Catalog=UserRepository;Integrated Security=True";
        /// <summary>
        /// opens/creates database
        /// </summary>
        public void createDatabase()
        {
            connection.ConnectionString = databaseSource;
            connection.Open();
        }
        /// <summary>
        /// closes database
        /// </summary>
        public void closeDatabase()
        {
            connection.Close();
        }

      
        /// <summary>
        /// executes commands as adapter
        /// </summary>
        private static SqlDataAdapter adapter = new SqlDataAdapter();
        /// <summary>
        /// assigns commands to adapter and run database through it
        /// </summary>
        /// <param name="tblName"></param>
        /// <param name="databaseCommands"></param>
        /// <returns></returns>
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

        /// <summary>
        /// basic sql command
        /// </summary>
        private static SqlCommand command = new SqlCommand();
        /// <summary>
        /// read data from commands that you wrote
        /// </summary>
        /// <param name="query">commands that read</param>
        /// <param name="tblName">Name of the table which will be read</param>
        public void readDataFromCommands(string query, DataTable tblName)
        {
            command.Connection = connection;
            command.CommandText = query;
            command.CommandType = CommandType.Text;

            adapter = new SqlDataAdapter(command);
            adapter.Fill(tblName);
        }
        /// <summary>
        /// read data from commands without specifing table name
        /// </summary>
        /// <param name="query">commands that read</param>
        /// <returns></returns>
        private static SqlDataReader readDataFromStream(string query)
        {
            SqlDataReader reader;

            command.Connection = connection;
            command.CommandText = query;
            command.CommandType = CommandType.Text;

            reader = command.ExecuteReader();
            return reader;
        }
        /// <summary>
        /// execute premade commands
        /// </summary>
        /// <param name="dbCommand"></param>
        /// <returns></returns>
        public int executeQuery(SqlCommand dbCommand)
        {
            dbCommand.Connection = connection;
            dbCommand.CommandType= CommandType.Text;

            return dbCommand.ExecuteNonQuery();
        }
        /// <summary>
        /// returns connection to database
        /// </summary>
        /// <returns></returns>
        public SqlConnection getConnection()
        {
            return connection;
        }
    }
}
