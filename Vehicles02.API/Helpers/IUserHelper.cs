using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicles02.API.Data.Entities;
using Vehicles02.API.Models;

namespace Vehicles02.API.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserAsync(string email);

        Task<User> GetUserAsync(Guid id);

        Task<IdentityResult> AddUserAsync(User user, string password);

        Task<IdentityResult> UpdateUserAsync(User user);
        
        Task<IdentityResult> DeleteUserAsync(User user);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(User user, string roleName);

        Task<bool> IsUserInRoleAsync(User user, string roleName);

        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();
    }
}
