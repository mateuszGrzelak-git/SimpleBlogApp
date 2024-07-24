using Microsoft.AspNetCore.Connections;
using Dapper;
using Blog.Database;
using Blog.Domain;

namespace Blog.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public UserRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<bool> CreateUser(Post customer)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            var result = await connection.ExecuteAsync(
                @"INSERT INTO Customers (Id, Username, FullName, Email, DateOfBirth) 
            VALUES (@Id, @Username, @FullName, @Email, @DateOfBirth)",
                customer);
            return result > 0;
        }

        public async Task<Post> GetAsync(Guid id)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            return await connection.QuerySingleOrDefaultAsync<Post>(
                "SELECT * FROM Customers WHERE Id = @Id LIMIT 1", new { Id = id.ToString() });
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            return await connection.QueryAsync<Post>("SELECT * FROM Customers");
        }

        public async Task<bool> UpdateAsync(Post customer)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            var result = await connection.ExecuteAsync(
                @"UPDATE Customers SET Username = @Username, FullName = @FullName, Email = @Email, 
                 DateOfBirth = @DateOfBirth WHERE Id = @Id",
                customer);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            var result = await connection.ExecuteAsync(@"DELETE FROM Customers WHERE Id = @Id",
                new { Id = id.ToString() });
            return result > 0;
        }
    }
}
