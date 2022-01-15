using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyEWalletApp.DataAccess;
using MyEWalletApp.Models.DTOs;
using MyEWalletApp.Models.Models;
using MyEWalletApp.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEWalletApp.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userMgr;
        private readonly IWalletService _walletService;
        private readonly IMapper _mapper;
        private readonly MyEWalletAppContext _cntx;

        public UserService(UserManager<AppUser> userMgr, IWalletService walletService, IMapper mapper, MyEWalletAppContext cntx)
        {
            _userMgr = userMgr;
            _walletService = walletService;
            _mapper = mapper;
            _cntx = cntx;
        }

        public async Task<string> RegisterAsync(Register register, string role)
        {
            if(role.ToLower() != "admin")
            {
                var user = _mapper.Map<AppUser>(register);
                user.UserName = register.Email;

                var x = await _userMgr.FindByEmailAsync(user.UserName);

                if (x != null)
                {
                    return "User already exists";
                }

                user.CreatedAt = DateTime.Now;
                var response = await _userMgr.CreateAsync(user, register.Password);

                IdentityResult result = null;
                if (response.Succeeded) result = await _userMgr.AddToRoleAsync(user, role);
                else return "error!";


                var res = await _userMgr.FindByEmailAsync(register.Email);
                var userid = res.Id;
                if (result.Succeeded)
                {
                    await _walletService.CreateWalletAsync(userid, register.MainCurrency);
                    //Add code to send email here
                    //Add for automatically creating a default wallet here
                    return "Successfully created a default wallet for new user";
                }
                return "error";
            }

            return "Registration failed; cannot register an admin user";


        }
        public async Task<bool> Logout(string userToken)
        {
            var token = new BlackListedTokens();
            token.Token = userToken;
            await _cntx.BlackListedTokens.AddAsync(token);
            var response = await _cntx.SaveChangesAsync();

            if (response > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<string> ForgotPassword(string email)
        {
            var user = await _userMgr.FindByEmailAsync(email);

            if (user != null)
            {
                return $"Password: {user.Password}";
            }
            return "No such user exists";
        }

        public Task<bool> IsTokenBlackListed(string token)
        {
            var response = _cntx.BlackListedTokens.Where(x => x.Token == token).FirstOrDefault();
            if (response != null) return Task.FromResult(true);
            return Task.FromResult(false);
        }
        //public async Task<string> DeleteUserByEmailAsync(string email)
        //{
        //    var user = await _userMgr.FindByEmailAsync(email);

        //    if(user != null)
        //    {
        //        var result = await _userMgr.DeleteAsync(user);
        //        if (!result.Succeeded)
        //        {
        //            return "Delete operation failed!";
        //        }

        //        return $"User with email: {email} successfully deleted";
        //    }

        //    return "There is no such user in the database!";

        //}

        public async Task<string> DeleteUserByIdAsync(string userId)
        {
            var user = await _userMgr.FindByIdAsync(userId);
            if (user != null)
            {
                var res = await _walletService.DeleteAllWalletAsync(userId);
                var result = await _userMgr.DeleteAsync(user);
                if (!result.Succeeded)
                {
                    return "Delete operation failed!";
                }

                return $"User with userId: {userId} successfully deleted";
            }

            return "There is no such user in the database!";
        }

        public async Task<List<AppUser>> GetAllUsersAsync()
        {
            return await _userMgr.Users.ToListAsync();
        }

        //public async Task<AppUser> GetUserByEmailAsync(string email)
        //{
        //    return await _userMgr.FindByEmailAsync(email);
        //}

        public async Task<AppUser> GetUserByIdAsync(string userId)
        {
            return await _userMgr.FindByIdAsync(userId);
        }

        public async Task UpdateUserByIdAsync(string userId, UserToUpdate userToUpdate)
        {
            var user = await _userMgr.FindByIdAsync(userId);
            var UpdatedUser = _mapper.Map<AppUser>(userToUpdate);
            UpdatedUser.Id = userId;
            await _userMgr.UpdateAsync(UpdatedUser);
        }

        
    }
}
