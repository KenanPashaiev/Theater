using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Theater.Models;

namespace Theater.DAL.Abstractions
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(Guid id);

        Task<User> GetUserByEmailAsync(string email);

        Task<IEnumerable<User>> GetAllUsersAsync();

        Task<User> AddUserAsync(User entity);

        Task<User> UpdateUserAsync(Guid id, User entity);

        Task<User> DeleteUserAsync(Guid id);
    }
}
