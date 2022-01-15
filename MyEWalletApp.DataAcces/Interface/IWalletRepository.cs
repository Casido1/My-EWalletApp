using MyEWalletApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyEWalletApp.DataAccess.Interface
{
    public interface IWalletRepository
    {
        public Task<int> CreateWallet(Wallet wallet);
        public Task<int> DeleteWallet(string WalletId);
        public Task<List<Wallet>> GetAllWallets(string UserId);
        public Task<Wallet> GetWallet(string UserId, string WalletId);
        public Task<int> UpdateWalletBalance(string WalletId, decimal Amount);
    }
}
