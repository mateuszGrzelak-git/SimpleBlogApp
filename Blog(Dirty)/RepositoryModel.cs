﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace Blog_Dirty_
{
    /// <summary>
    /// Class <c>PostsRepository</c> stores all data about posts in sql
    /// </summary>
    public class RepositoryModel
    {
        /// <summary>
        /// basic sql command
        /// </summary>
        private SqlCommand command;

        /// <summary>
        /// Represents opening of the database
        /// </summary>
        private SqlConnection connection;

        /// <summary>
        /// defines where the database is
        /// </summary>
        private string databaseSource;

        /// <summary>
        /// executes commands as adapter
        /// </summary>
        private SqlDataAdapter adapter = new SqlDataAdapter();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="databaseSource"></param>
        public RepositoryModel(string databaseSource)
        {
            this.databaseSource = databaseSource;
            this.connection = new SqlConnection();
            this.command = new SqlCommand(); 
            this.adapter = new SqlDataAdapter();
        }

        /// <summary>
        /// Destructor
        /// </summary>
        ~RepositoryModel()
        {
            closeDatabase();
        }

        /// <summary>
        /// returns connection to database
        /// </summary>
        /// <returns></returns>
        public SqlConnection getConnection()
        {
            return connection;
        }

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
        /// assigns commands to adapter and run database through it
        /// </summary>
        /// <param name="tblName">Name of the table which will be changed</param>
        /// <param name="databaseCommands">strubg of sql commands that will be executed</param>
        /// <returns>Count of database</returns>
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

            closeDatabase();
            return adapter.Update(tblName);
        }

        /// <summary>
        /// reads data from commands that you wrote
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
        private SqlDataReader readDataFromStream(string query)
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
            dbCommand.CommandType = CommandType.Text;

            return dbCommand.ExecuteNonQuery();
        }
    }
}
