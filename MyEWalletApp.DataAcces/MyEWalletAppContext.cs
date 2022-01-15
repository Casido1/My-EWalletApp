using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyEWalletApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyEWalletApp.DataAccess
{
    public class MyEWalletAppContext: IdentityDbContext<AppUser>
    {
        public MyEWalletAppContext(DbContextOptions<MyEWalletAppContext> options):base(options)
        {
           

        }

        public DbSet<Currency> Currency { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<Wallet> Wallet { get; set; }
        public DbSet<WalletCurrency> WalletCurrency { get; set; }
        public DbSet<BlackListedTokens> BlackListedTokens { get; set; }



    }
}
