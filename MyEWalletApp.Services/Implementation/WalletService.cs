using AutoMapper;
using MyEWalletApp.DataAccess;
using MyEWalletApp.DataAccess.Interface;
using MyEWalletApp.Models.Models;
using MyEWalletApp.Models.ReturnDTOs;
using MyEWalletApp.Models.WalletDTOs;
using MyEWalletApp.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEWalletApp.Services.Implementation
{
    public class WalletService : IWalletService
    {
        private readonly ICurrencyConversionService _curConService;
        private readonly IWalletCurrencyRepository _walCurRepo;
        private readonly IWalletCurrencyService _walCurService;
        private readonly IWalletRepository _walletRepo;
        private readonly ICurrencyService _curSevice;
        private readonly IMapper _mapper;
        private readonly MyEWalletAppContext _cntx;

        //private readonly MyEWalletAppContext _cntx;

        public WalletService(ICurrencyConversionService curConService, IWalletCurrencyRepository walCurRepo, IWalletRepository walletRepo, ICurrencyService curSevice, IMapper mapper, MyEWalletAppContext cntx, IWalletCurrencyService walCurService)
        {
            _curConService = curConService;
            _walCurRepo = walCurRepo;
            _walCurService = walCurService;
            _walletRepo = walletRepo;
            _curSevice = curSevice;
            _mapper = mapper;
            _cntx = cntx;
        }
        public async Task<string> AddWalletCurrencyAsync(string walletId, string currencyCode)
        {

            var res = await _walCurService.CreateWalletCurrencyAsync(walletId, currencyCode);
            return res;
        }

        public async Task<string> CreateWalletAsync(string UserId, string MainCurrency)
        {
            var wallet = new Wallet
            { 
                UserId = UserId,
                MainCurrency = MainCurrency,
                CreatedAt = DateTime.Now.ToString()

        };
            var count = _cntx.Wallet.Count(x => x.UserId == UserId);

            if(count == 0)
            {
                wallet.IsDefault = true;
            }

            var res = await _walletRepo.CreateWallet(wallet);

            if (res > 0) return "Wallet created successfully";
            return "Wallet creation failed!";
        }



        public async Task<string> DeleteWalletAsync(string WalletId)
        {
            var walletBalance = await WalletBalance(WalletId);

            if(walletBalance.Balance > 0)
            {
                return "Wallet cannot be deleted because its balance is not zero!";
            }

            var walletCurrencies = await _walCurRepo.GetWalletCurrencies(WalletId);

            foreach(var walletCurrency in walletCurrencies)
            {
                await _walCurService.DeleteWalletCurrency(walletCurrency.Id);
               
            }
            var res = await _walletRepo.DeleteWallet(WalletId);
            if(res > 0)
            {
                return "Wallet deleted successfully";
            }
            return "Wallet delete operation unsuccessful!";
            
        }

        public async Task<string> DeleteAllWalletAsync(string UserId)
        {
            var wallets = await _walletRepo.GetAllWallets(UserId);

            foreach(var wallet in wallets)
            {
                await DeleteAllWalletAsync(wallet.Id);
            }
            return "Successfully deleted wallets for this user!";
        }

        public async Task<List<WalletToReturn>> GetAllUserWalletsAsync(string UserId)
        {
            var results = await _walletRepo.GetAllWallets(UserId);

            var listOfWallets = new List<WalletToReturn>();
            foreach(var result in results)
            {
                listOfWallets.Add(_mapper.Map<WalletToReturn>(result));
            }
            return listOfWallets;
            
;        }

        public async Task<WalletToReturn> GetWalletAsync(string UserId, string WalletId)
        {
            var result = await _walletRepo.GetWallet(UserId, WalletId);
            var waletToReturn = _mapper.Map<WalletToReturn>(result);
            return waletToReturn;
        }

        public async Task<BalanceToReturn> UserBalanceAsync(string userId)
        {
            var userWallets = await _walletRepo.GetAllWallets(userId);
            decimal TotalBalance = 0;

            var DefaultCurrency = "";
            foreach(var userWallet in userWallets)
            {
                if (userWallet.IsDefault == true) DefaultCurrency = userWallet.MainCurrency;
            }

            foreach(var userWallet in userWallets)
            {
                if (DefaultCurrency != userWallet.MainCurrency)
                {
                    var convertedBalance = await _curConService.ConvertCurrency(new CurrencyConverter
                    {
                        amount = userWallet.WalletBalance,
                        From = userWallet.MainCurrency,
                        To = DefaultCurrency
                    });
                    TotalBalance += convertedBalance;
                }
                else TotalBalance += userWallet.WalletBalance;
            }
            var balanceToReturn = new BalanceToReturn
            {
                CurrencyCode = DefaultCurrency,
                Balance = TotalBalance
            };

            return balanceToReturn;

        }

        public async Task<BalanceToReturn> WalletBalance(string walletId)
        {
            var walletCurrencies = await _walCurRepo.GetWalletCurrencies(walletId);
            decimal TotalWalletBalance = 0;

            var MainCurrency = "";
            Currency currency = null; 

            foreach(var walletCurrency in walletCurrencies)
            {
                if (walletCurrency.IsMain == true) 
                {
                    currency = await _curSevice.GetCurrencyAsync(walletCurrency.CurrencyId);
                    MainCurrency = currency.ShortCode;
                } 
            }

            foreach (var walletCurrency in walletCurrencies)
            {
                currency = await _curSevice.GetCurrencyAsync(walletCurrency.CurrencyId);

                if (MainCurrency != currency.ShortCode)
                {
                    var convertedBalance = await _curConService.ConvertCurrency(new CurrencyConverter
                    {
                        amount = walletCurrency.WalletCurrencyBalance,
                        From = currency.ShortCode,
                        To = MainCurrency
                    });
                    TotalWalletBalance += convertedBalance;
                }
                else TotalWalletBalance += walletCurrency.WalletCurrencyBalance;
            }

            var balanceToReturn = new BalanceToReturn
            {
                CurrencyCode = MainCurrency,
                Balance = TotalWalletBalance
            };

            return balanceToReturn;


        }
    }
}
