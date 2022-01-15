using AutoMapper;
using MyEWalletApp.DataAccess.Interface;
using MyEWalletApp.Models.DTOs;
using MyEWalletApp.Models.Models;
using MyEWalletApp.Models.ReturnDTOs;
using MyEWalletApp.Services.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace MyEWalletApp.Services.Implementation
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IMapper _mapper;
        private readonly ICurrencyRepository _currencyRepo;

        public CurrencyService(IMapper mapper, ICurrencyRepository currencyRepo)
        {
            _mapper = mapper;
            _currencyRepo = currencyRepo;
        }
        public async Task<string> CreateCurrencyAsync(CurrencyToAdd currencyToAdd)
        {
            currencyToAdd.ShortCode = currencyToAdd.ShortCode.ToUpper();
            TextInfo text = new CultureInfo("en-US", false).TextInfo;
            currencyToAdd.Name = text.ToTitleCase(currencyToAdd.Name.Trim().ToLower());
            var currency = _mapper.Map<Currency>(currencyToAdd);
            return await _currencyRepo.CreateCurrency(currency);
        }

        public async Task<string> DeleteCurrencyAsync(int Id)
        {
            return await _currencyRepo.DeleteCurrency(Id);
        }

        public async Task<List<CurrencyToAdd>> GetAllCurrenciesAsync()
        {
            var currencies = await _currencyRepo.GetAllCurrencies();
            var currencyToReturn = new List<CurrencyToAdd>();

            foreach (var currency in currencies)
            {
                currencyToReturn.Add(_mapper.Map<CurrencyToAdd>(currency));
            }
            return currencyToReturn;

        }

        public async Task<Currency> GetCurrencyAsync(int id)
        {
            return await _currencyRepo.GetCurrency(id);
        }
    }
}
