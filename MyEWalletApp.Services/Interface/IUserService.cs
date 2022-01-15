using Microsoft.AspNetCore.Identity;
using MyEWalletApp.Models.DTOs;
using MyEWalletApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyEWalletApp.Services.Interface
{
    public interface IUserService
    {
        public Task<string> RegisterAsync(Register register, string role);
        public Task<bool> Logout(string userToken);
        public Task<string> ForgotPassword(string email);
        public Task<bool> IsTokenBlackListed(string token);
        public Task UpdateUserByIdAsync(string userId, UserToUpdate userToUpdate);
        public Task<string> DeleteUserByIdAsync(string userId);

        //public Task<string> DeleteUserByEmailAsync(string userId);
        public Task<List<AppUser>> GetAllUsersAsync();
        public Task<AppUser> GetUserByIdAsync(string userId);
        //public Task<AppUser> GetUserByEmailAsync(string email);
        
       

    }
}
