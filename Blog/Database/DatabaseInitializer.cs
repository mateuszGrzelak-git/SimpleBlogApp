using Microsoft.AspNetCore.Connections;
using Dapper;

namespace Blog.Database
{
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
            await connection.ExecuteAsync(@"CREATE TABLE IF NOT EXISTS Users (
        Id CHAR(36) PRIMARY KEY, 
        Username TEXT NOT NULL,
        Password TEXT NOT NULL");
        }
    }
}
