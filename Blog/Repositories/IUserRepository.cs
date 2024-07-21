using Blog.Domain;
using Blog.Domain.Common;

namespace Blog.Repositories
{
    public interface IUserRepository
    {
        Task<bool> CreateAsync(Post user);

        Task<Post> GetAsync(Guid id);

        Task<IEnumerable<Post>> GetAllAsync();

        Task<bool> UpdateAsync(Post user);

        Task<bool> DeleteAsync(Guid id);
    }
}
