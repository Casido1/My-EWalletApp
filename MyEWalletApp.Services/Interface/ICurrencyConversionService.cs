using MyEWalletApp.Models.WalletDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyEWalletApp.Services.Interface
{
    public interface ICurrencyConversionService
    {
        public Task<dynamic> ConversionRate(CurrencyConverter currency);
        public Task<dynamic> ConvertCurrency(CurrencyConverter currency);
        public Task<ConversionRate> GetMarketPrices();
    }
}
