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
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] Login login)
        {
            var result = await _authService.LoginAsync(login);
            return Ok(result);   
        }

        


    }
}
