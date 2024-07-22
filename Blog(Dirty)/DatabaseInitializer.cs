using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Blog_Dirty_
{
    public interface IDbConnectionFactory
    {
        public Task<IDbConnection> CreateConnectionAsync();
    }
    public class SqlConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString;

        public SqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IDbConnection> CreateConnectionAsync()
        {
            var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            return connection;
        }
    }

    public class DatabaseInitializer
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public DatabaseInitializer(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task InitializeAsync()
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            await connection.ExecuteAsync(@"CREATE TABLE IF NOT EXISTS Users
            ID CHAR(36) PRIMARY KEY, 
            Username TEXT NOT NULL,
            Password TEXT NOT NULL");

            await connection.ExecuteAsync(@"CREATE TABLE IF NOT EXISTS Posts
            ID CHAR(36) PRIMARY KEY,
            username TEXT NOT NULL,
            postName TEXT NOT NULL,
            postData TEXT NOT NULL");
        }
    }
}
