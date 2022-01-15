using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyEWalletApp.Models.DTOs;
using MyEWalletApp.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEWalletApp.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register/{role}")]
        public async Task<IActionResult> RegisterUserAsync([FromBody] Register register, [FromRoute] string role)
        {
            var result = await _userService.RegisterAsync(register, role);
            return Ok(result);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] Logout logout)
        {
            var res = await _userService.Logout(logout.Token);
            if (res) return Ok("Logged out successfully");
            return Ok("Logout failed!");
        }

        [HttpPost("forgot password")]
        public async Task<IActionResult> ForgotPasswordAsync([FromBody] ForgotPassword forgotPassword)
        {
            var res = await _userService.ForgotPassword(forgotPassword.Email);
            return Ok(res);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserByIdAsync([FromRoute] string id, [FromBody] UserToUpdate userToUpdate)
        {
            await _userService.UpdateUserByIdAsync(id, userToUpdate);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserByIdAsync([FromRoute] string id)
        {
            var result = await _userService.DeleteUserByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserByIdAsync([FromRoute] string id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return Ok(user);
        }

        //[HttpGet("")]
        //public async Task<IActionResult> GetUserByEmailAsync()
        //{
        //    var users = await _userService.GetAllUsersAsync();
        //    return Ok(users);
        //}
    }
}
