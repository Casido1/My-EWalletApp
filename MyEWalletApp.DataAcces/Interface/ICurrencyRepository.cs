using Microsoft.AspNetCore.Identity;
using MyEWalletApp.Models.DTOs;
using MyEWalletApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyEWalletApp.DataAccess.Interface
{
    public interface ICurrencyRepository
    {
        public Task<string> CreateCurrency(Currency currency);
        public Task<List<Currency>> GetAllCurrencies();
        public Task<string> DeleteCurrency(int Id);
        public Task<Currency> GetCurrency(int id);
    }
}
