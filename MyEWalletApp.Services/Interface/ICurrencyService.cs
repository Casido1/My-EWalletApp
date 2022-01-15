using MyEWalletApp.Models.DTOs;
using MyEWalletApp.Models.Models;
using MyEWalletApp.Models.ReturnDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyEWalletApp.Services.Interface
{
    public interface ICurrencyService
    {
        public Task<string> CreateCurrencyAsync(CurrencyToAdd currencyToAdd);
        public Task<string> DeleteCurrencyAsync(int Id);
        public Task<List<CurrencyToAdd>> GetAllCurrenciesAsync();
        public Task<Currency> GetCurrencyAsync(int id);
    }
}
