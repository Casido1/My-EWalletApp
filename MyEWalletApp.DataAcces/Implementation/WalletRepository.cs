using MyEWalletApp.DataAccess.Interface;
using MyEWalletApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEWalletApp.DataAccess.Implementation
{
    public class WalletRepository : IWalletRepository
    {
        private readonly MyEWalletAppContext _cntx;

        public WalletRepository(MyEWalletAppContext cntx)
        {
            _cntx = cntx;
        }
        public async Task<int> CreateWallet(Wallet wallet)
        {
            await _cntx.Wallet.AddAsync(wallet);
            var res = await _cntx.SaveChangesAsync();
            return res;
        }

        public async Task<int> DeleteWallet(string WalletId)
        {
            var result = await _cntx.Wallet.FindAsync(WalletId);
            _cntx.Wallet.Remove(result);
            return await _cntx.SaveChangesAsync();

        }


        public Task<List<Wallet>> GetAllWallets(string UserId)
        {
            var wallets = _cntx.Wallet.Where(x => x.UserId == UserId).ToList();
            return Task.FromResult(wallets);
        }

        public Task<Wallet> GetWallet(string UserId, string WalletId)
        {
            var wallet = _cntx.Wallet.Where(x => x.UserId == UserId && x.Id == WalletId).FirstOrDefault();
            return Task.FromResult(wallet);
        }

        public async Task<int> UpdateWalletBalance(string WalletId, decimal Amount)
        {
            var wallet = await _cntx.Wallet.FindAsync(WalletId);
            wallet.WalletBalance = Amount;
            _cntx.Wallet.Update(wallet);
            return await _cntx.SaveChangesAsync();
        }
    }
}
