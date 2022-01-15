using Microsoft.AspNetCore.Identity;
using MyEWalletApp.DataAccess.Interface;
using MyEWalletApp.Models.DTOs;
using MyEWalletApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEWalletApp.DataAccess.Implementation
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly MyEWalletAppContext _cntx;

        public CurrencyRepository(MyEWalletAppContext cntx)
        {
            _cntx = cntx;
        }
        public async Task<string> CreateCurrency(Currency currency)
        {
            var res = _cntx.Currency.Where(x => x.ShortCode == currency.ShortCode).FirstOrDefault();
            if (res != null)
            {
                return "Currency already exists!";
            }
            currency.CreatedAt = DateTime.Now.ToString();
            await _cntx.Currency.AddAsync(currency);
            await _cntx.SaveChangesAsync();
            return "Currency successfully created";

           
        }


        public async Task<string> DeleteCurrency(int Id)
        {
            var res = await _cntx.Currency.FindAsync(Id);
            if (res != null)
            {
                _cntx.Remove(res);
                await  _cntx.SaveChangesAsync();
                return $"{res.ShortCode} successfully removed for the database!";
            }
            return $"Currency with Id {Id} does not exist!";
        }

        public Task<List<Currency>> GetAllCurrencies()
        {
            var res = _cntx.Currency.ToList();
            return Task.FromResult(res);
        }

        public async Task<Currency> GetCurrency(int id)
        {
            var res = await _cntx.Currency.FindAsync(id);
            return res;
        }

    }
}
