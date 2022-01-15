using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyEWalletApp.Models.Models
{
    public class Wallet : BaseEntity
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public List<WalletCurrency> WalletCurrencies { get; set; }
        public string MainCurrency { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal WalletBalance { get; set; } = 0;
        public bool IsDefault { get; set; } = false;
        public List<Transactions> Transactions { get; set; }

        public Wallet()
        {
            Id = Guid.NewGuid().ToString();
            WalletCurrencies = new List<WalletCurrency>();
            Transactions = new List<Transactions>();
        }

    }
}
