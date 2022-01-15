using AutoMapper;
using MyEWalletApp.Models.DTOs;
using MyEWalletApp.Models.Models;
using MyEWalletApp.Models.ReturnDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyEWalletApp.Commons
{
    public class AutoMapping: Profile
    {
        public AutoMapping()
        {
            CreateMap<Register, AppUser>();
            CreateMap<UserToUpdate, AppUser>();
            CreateMap<CurrencyToAdd, Currency>();
            CreateMap<Currency, CurrencyToAdd>();
            CreateMap<Wallet, WalletToReturn>();
            
            
        }
    }
}
