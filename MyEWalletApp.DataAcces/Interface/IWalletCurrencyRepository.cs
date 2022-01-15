using MyEWalletApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyEWalletApp.DataAccess.Interface
{
    public interface IWalletCurrencyRepository
    {
        public Task<int> CreateWalletCurrency(WalletCurrency walletCurrency, string CurrencyCode);
        public Task<List<WalletCurrency>> GetWalletCurrencies(string WalletId);
        public Task<WalletCurrency> GetWalletCurrency(string WalletId, int CurrencyId);
        public Task<int> WithdrawWalletCurrency(string WalletCurrencyId, decimal Amount);
        public Task<int> FundWalletCurrency(string WalletCurrencyId, decimal Amount);
        public Task<int> DeleteWalletCurrency(string Id);  
        
    }
}
