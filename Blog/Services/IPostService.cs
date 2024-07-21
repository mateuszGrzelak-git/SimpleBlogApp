using Blog.Domain;

namespace Blog.Services
{
    public interface IUserService
    {
        Task<bool> CreateAsync(Post user);

        Task<Post?> GetAsync(Guid id);

        Task<IEnumerable<Post>> GetAllAsync();

        Task<bool> UpdateAsync(Post user);

        Task<bool> DeleteAsync(Guid id);
    }
}
