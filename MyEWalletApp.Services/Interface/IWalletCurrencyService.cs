using MyEWalletApp.Models.DTOs;
using MyEWalletApp.Models.Models;
using MyEWalletApp.Models.ReturnDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyEWalletApp.Services.Interface
{
    public interface IWalletCurrencyService
    {
        public Task<string> CreateWalletCurrencyAsync(string WalletId, string CurrencyCode);
        public Task<List<WalletCurrencyToReturn>> GetWalletCurrenciesAsync(string WalletId);
        public Task<WalletCurrencyToReturn> GetWalletCurrencyAsync(string WalletId, int CurrencyId);
        public Task<string> FundWalletCurrencyAsync(string WalletCurrencyId, decimal Amount);
        public Task<string> WithdrawWalletCurrencyAsync(string WalletCurrencyId, decimal Amount);
        public Task<string> DeleteWalletCurrency(string Id);
    }
}
