using AutoMapper;
using MyEWalletApp.DataAccess;
using MyEWalletApp.DataAccess.Interface;
using MyEWalletApp.Models.DTOs;
using MyEWalletApp.Models.Models;
using MyEWalletApp.Models.ReturnDTOs;
using MyEWalletApp.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEWalletApp.Services.Implementation
{
    public class WalletCurrencyService : IWalletCurrencyService
    {
        private readonly IWalletCurrencyRepository _walletCurrencyRepo;
        private readonly MyEWalletAppContext _cntx;

        public WalletCurrencyService(IWalletCurrencyRepository walletCurrencyRepo, MyEWalletAppContext cntx)
        {
            _walletCurrencyRepo = walletCurrencyRepo;
            _cntx = cntx;
        }
        public async Task<string> CreateWalletCurrencyAsync(string WalletId, string CurrencyCode)
        {
            var wallet = await _cntx.Wallet.FindAsync(WalletId);
            if(wallet != null)
            {
                var currency = "";
                var walletCurrency = new WalletCurrency()
                {
                    WalletId = WalletId,
                    CreatedAt = DateTime.Now.ToString()
                };
                if (_cntx.WalletCurrency.Count(x => x.WalletId == WalletId) > 0)
                {
                    walletCurrency.IsMain = false;
                    currency = CurrencyCode;
                }
                else
                {
                    walletCurrency.IsMain = true;
                    currency = wallet.MainCurrency;
                }
                currency = CurrencyCode;

                var res = await _walletCurrencyRepo.CreateWalletCurrency(walletCurrency, currency);
                if (res > 0)
                {
                    return $"{CurrencyCode} wallet successfully created";
                }
                return "Selected currency is unavailable!";

            }
            return "Wallet doesn't exist!";


        }

        public async Task<string> DeleteWalletCurrency(string Id)
        {
            var res = await _walletCurrencyRepo.DeleteWalletCurrency(Id);
            if(res > 0)
            {
                return $"wallet successfully deleted!";
            }
            return "Wallet does not exist!";
        }



        public async Task<string> FundWalletCurrencyAsync(string WalletCurrencyId, decimal Amount)
        {
            var res = await _walletCurrencyRepo.FundWalletCurrency(WalletCurrencyId, Amount);
            if(res > 0)
            {
                return "Successful!"; 
            }
            return "Unsuccessful!";
        }


        public async Task<List<WalletCurrencyToReturn>> GetWalletCurrenciesAsync(string WalletId)
        {
            var walletCurrencies = new List<WalletCurrencyToReturn>();
            var results = await _walletCurrencyRepo.GetWalletCurrencies(WalletId);

            foreach (var result in results)
            {
                var currency = await _cntx.Currency.FindAsync(result.CurrencyId);
                walletCurrencies.Add(new WalletCurrencyToReturn
                {
                    CurrencyCode = currency.ShortCode,
                    WalletCurrencyBalance = result.WalletCurrencyBalance

                }); ;
            }
            return walletCurrencies;
        }

        public async Task<WalletCurrencyToReturn> GetWalletCurrencyAsync(string WalletId, int CurrencyId)
        {
            var res = await _walletCurrencyRepo.GetWalletCurrency(WalletId, CurrencyId);
            var currency = await _cntx.Currency.FindAsync(CurrencyId);

            return new WalletCurrencyToReturn
            {
                CurrencyCode = currency.ShortCode,
                WalletCurrencyBalance = res.WalletCurrencyBalance
            };
        }

        public async Task<string> WithdrawWalletCurrencyAsync(string WalletCurrencyId, decimal Amount)
        {
            var res = await _walletCurrencyRepo.FundWalletCurrency(WalletCurrencyId, Amount);
            if (res > 0)
            {
                return "Successful!";
            }
            return "Unsuccessful!";

            
        }

       

    }
}
