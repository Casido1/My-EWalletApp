using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyEWalletApp.Models.Models
{
    public class WalletCurrency : BaseEntity
    {
        public string Id { get; set; }
        public string WalletId { get; set; }
        public Wallet Wallet { get; set; }
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal WalletCurrencyBalance { get; set; } = 0;

        public bool IsMain { get; set; }

        public WalletCurrency()
        {
            Id = Guid.NewGuid().ToString();
        }

    }
}
