using Microsoft.AspNetCore.Identity;
using MyEWalletApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyEWalletApp.DataAccess.Interface
{
    public interface IUserRepository : ICrudRepo
    {
        public Task<List<AppUser>> GetAllUsersAsync();
        public Task<AppUser> GetUserbyIdAsync(string Id);
        public Task<AppUser> GetUserbyEmailAsync(string Email);
        public Task<int> RowCount();
        public Task<bool> SaveChangesAsync();
    }
}
