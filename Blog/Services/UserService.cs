using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using Blog.Domain;
using Blog.Repositories;
using Blog.Services;
using Blog.Domain.Common;

namespace Blog.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _customerRepository;

        public UserService(IUserRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<bool> CreateAsync(Post user)
        {
            var existingUser = await _customerRepository.GetAsync(customer.Id.Value);
            if (existingUser is not null)
            {
                var message = $"A user with id {user.Id} already exists";
                throw new ValidationException(message, new[]
                {
                new ValidationFailure(nameof(Post), message)
            });
            }

            var customerDto = user.ToUser();
            return await _customerRepository.CreateAsync(customerDto);
        }

        public async Task<Post?> GetAsync(Guid id)
        {
            var user = await _customerRepository.GetAsync(id);
            return user?.ToUser();
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            var customerDtos = await _customerRepository.GetAllAsync();
            return customerDtos.Select(x => x.ToUser());
        }

        public async Task<bool> UpdateAsync(Post user)
        {
            var customerDto = user.ToUser();
            return await _customerRepository.UpdateAsync(user);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _customerRepository.DeleteAsync(id);
        }
    }

}
