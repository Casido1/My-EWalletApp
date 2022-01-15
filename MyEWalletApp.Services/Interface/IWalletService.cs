using MyEWalletApp.Models.ReturnDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyEWalletApp.Services.Interface
{
    public interface IWalletService
    {
        public Task<string> CreateWalletAsync(string UserId, string MainCurrency);
        public Task<string> DeleteWalletAsync(string WalletId);
        public Task<string> DeleteAllWalletAsync(string UserId);
        Task<string> AddWalletCurrencyAsync(string walletId, string currencyCode);
        public Task<List<WalletToReturn>> GetAllUserWalletsAsync(string UserId);
        public Task<WalletToReturn> GetWalletAsync(string UserId, string WalletId);
        Task<BalanceToReturn> UserBalanceAsync(string userId);
        Task<BalanceToReturn> WalletBalance(string walletId);
    }
  
    

    
}
