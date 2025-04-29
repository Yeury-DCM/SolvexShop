
using SolvexShop.Core.Application.Dtos;
using SolvexShop.Core.Application.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvexShop.Core.Application.Interfaces.Services
{
    public interface IAccountService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<SaveUserResponse> CreateUser(SaveUserRequest request);
        Task SignOutAsync();

        Task UpdateUserAsync(SaveUserDto saveUserDto);
        Task<List<UserDto>> GetAllUserDtosAsync();
        Task<UserDto> GetUserDtoByIdAsync(string id);

        Task ActivateUser(string userId);
        Task DeactivateUser(string userId);
    }
}
