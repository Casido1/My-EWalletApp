using MyEWalletApp.DataAccess.Interface;
using MyEWalletApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEWalletApp.DataAccess.Implementation
{
    public class WalletCurrencyRepository : IWalletCurrencyRepository
    {
        private readonly MyEWalletAppContext _cntx;

        public WalletCurrencyRepository(MyEWalletAppContext cntx)
        {
            _cntx = cntx;
        }
        public async Task<int> CreateWalletCurrency(WalletCurrency walletCurrency, string CurrencyCode)
        {
            var result = await _cntx.Currency.FindAsync(CurrencyCode);

            if (result != null)
            {
                walletCurrency.CurrencyId = result.Id;
                await _cntx.WalletCurrency.AddAsync(walletCurrency);
                var res = await _cntx.SaveChangesAsync();
                return res;
                
            }
            return 0;
        }

        public async Task<int> DeleteWalletCurrency(string Id)
        {
            var result = await _cntx.WalletCurrency.FindAsync(Id);

            if(result != null)
            {
                _cntx.WalletCurrency.Remove(result);
                var res = await _cntx.SaveChangesAsync();
                return res;
            }
            return 0;
        }

        public Task<List<WalletCurrency>> GetWalletCurrencies(string WalletId)
        {
            var results = _cntx.WalletCurrency.Where(x => x.WalletId == WalletId).ToList();
            return Task.FromResult(results);
        }

        public Task<WalletCurrency> GetWalletCurrency(string WalletId, int CurrencyId)
        {
            var result = _cntx.WalletCurrency.Where(x => x.WalletId == WalletId && x.CurrencyId == CurrencyId).FirstOrDefault();
            return Task.FromResult(result);
        }

        public async Task<int> FundWalletCurrency(string WalletCurrencyId, decimal Amount)
        {
            var walletcurrency = await _cntx.WalletCurrency.FindAsync(WalletCurrencyId);
            walletcurrency.WalletCurrencyBalance += Amount;
            _cntx.WalletCurrency.Update(walletcurrency);
            return await _cntx.SaveChangesAsync();
        }

        public async Task<int> WithdrawWalletCurrency(string WalletCurrencyId, decimal Amount)
        {
            var walletcurrency = await _cntx.WalletCurrency.FindAsync(WalletCurrencyId);

            if(Amount > walletcurrency.WalletCurrencyBalance)
            {
                return 0;
            }
            walletcurrency.WalletCurrencyBalance -= Amount;
            _cntx.WalletCurrency.Update(walletcurrency);
            return await _cntx.SaveChangesAsync();
        }
    }
}
