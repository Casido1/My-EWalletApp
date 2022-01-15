using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MyEWalletApp.DataAccess;
using MyEWalletApp.Models.DTOs;
using MyEWalletApp.Models.Models;
using MyEWalletApp.Models.ReturnDTOs;
using MyEWalletApp.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEWalletApp.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userMgr;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IJWTService _jWTService;
        
        

        public AuthService(UserManager<AppUser> userMgr, SignInManager<AppUser> signInManager, IJWTService jWTService)
        {
            _userMgr = userMgr;
            _signInManager = signInManager;
            _jWTService = jWTService;
            
            
        }

        
        public async Task<LoginCred> LoginAsync(Login login)
        {
            var user = await _userMgr.FindByEmailAsync(login.Email);
            if (user == null)
                return new LoginCred {status=false, Message = "Email or Password incorrect"};
            var result = await _signInManager.PasswordSignInAsync(user, login.Password, login.RememberMe, false);

            if (!result.Succeeded)
            {
                return new LoginCred { status = false, Message = "Email or Password incorrect" };
            }

            //Get JWT token
            var userRoles = await _userMgr.GetRolesAsync(user);
            var token = await _jWTService.GenerateToken(user, userRoles.ToList());
            
            return new LoginCred() { Id = user.Id, status = true, token = token, Message = "Log in successful" };

        }

       
    }
}
