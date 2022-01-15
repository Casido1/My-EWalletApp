using Microsoft.AspNetCore.Authorization;
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
    //[Authorize(Roles = "admin")]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _curSer;

        public CurrencyController(ICurrencyService curSer)
        {
            _curSer = curSer;
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateCurrencyAsync([FromBody] CurrencyToAdd currencyToAdd)
        {
            var res = await _curSer.CreateCurrencyAsync(currencyToAdd);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurrencyAsync([FromRoute] int id)
        {
            var res = await _curSer.DeleteCurrencyAsync(id);
            return Ok(res);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllCurrenciesAsync()
        {
            var res = await _curSer.GetAllCurrenciesAsync();
            return Ok(res);
        }
    }
}
