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
    public class WalletController : ControllerBase
    {
        private readonly IWalletService _walService;

        public WalletController(IWalletService walService)
        {
            _walService = walService;
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateWalletAsync([FromBody] WalletToAdd walletToAdd)
        {
            var res = await _walService.CreateWalletAsync(walletToAdd.UserId, walletToAdd.MainCurrency);
            return Ok(res);
        }

        [HttpDelete("{walletid}")]
        public async Task<IActionResult> DeleteWalletAsync([FromRoute] string walletid)
        {
            var res = await _walService.DeleteWalletAsync(walletid);
            return Ok(res);
        }
        [HttpPost("{walletid}/{currencycode}")]
        public async Task<IActionResult> AddWalletCurrencyAsync([FromRoute] string walletid, [FromRoute] string currencycode)
        {
            var res = await _walService.AddWalletCurrencyAsync(walletid, currencycode);
            return Ok(res);
        }

        [HttpGet("wallets/{userid}")]
        public async Task<IActionResult> GetAllUserWalletsAsync([FromRoute] string userid)
        {
            var res = await _walService.GetAllUserWalletsAsync(userid);
            return Ok(res);
        }

        [HttpGet("{userid}/{walletid}")]
        public async Task<IActionResult> GetWalletAsync([FromRoute] string userid, [FromRoute] string walletid)
        {
            var res = await _walService.GetWalletAsync(userid, walletid);
            return Ok(res);
        }

        [HttpGet("balance/{userid}")]
        public async Task<IActionResult> UserBalanceAsync([FromRoute] string userid)
        {
            var res = await _walService.UserBalanceAsync(userid);
            return Ok(res);
        }

        [HttpGet("{walletid}")]
        public async Task<IActionResult> WalletBalance([FromRoute] string walletid)
        {
            var res = await _walService.WalletBalance(walletid);
            return Ok(res);
        }
    }
}
