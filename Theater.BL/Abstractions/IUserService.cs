using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Theater.BL.Models.User;

namespace Theater.BL.Services
{
    public interface IUserService
    {
        Task<UserDto> GetUserAsync(Guid id);

        Task<UserDto> GetUserByEmailAsync(string email);

        Task<IEnumerable<UserDto>> GetAllUsersAsync();

        Task<UserDto> RegisterAsync(UserRegisterDto userRegisterDto);

        Task<string> LoginAsync(UserLoginDto userRegisterDto);

        Task<UserDto> UpdateUserAsync(Guid id, UserUpdateDto userUpdateDto);
    }
}
