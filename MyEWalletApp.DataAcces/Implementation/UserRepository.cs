//using Microsoft.AspNetCore.Identity;
//using MyEWalletApp.DataAccess.Interface;
//using MyEWalletApp.Models.Models;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;

//namespace MyEWalletApp.DataAccess.Implementation
//{
//    public class UserRepository : IUserRepository
//    {
//        private readonly UserManager<AppUser> _userMgr;

//        public UserRepository(UserManager<AppUser> userMgr)
//        {
//            _userMgr = userMgr;

//        }
//        public Task<bool> Add<T>(T entity)
//        {
//            _userMgr.CreateAsync();
//        }

//        public Task<bool> Delete<T>(T entity)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<List<AppUser>> GetAllUsersAsync()
//        {
//            throw new NotImplementedException();
//        }

//        public Task<AppUser> GetUserbyEmailAsync(string Email)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<AppUser> GetUserbyIdAsync(string Id)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<int> RowCount()
//        {
//            throw new NotImplementedException();
//        }

//        public Task<bool> SaveChangesAsync()
//        {
//            throw new NotImplementedException();
//        }

//        public Task<bool> Update<T>(T entity)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
