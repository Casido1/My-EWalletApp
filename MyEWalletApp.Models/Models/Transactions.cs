using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyEWalletApp.Models.Models
{
    public class Transactions : BaseEntity
    {
        public string Id { get; set; }
        public string TransactionType { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public int CurrencyId { get; set; }
        public string Status { get; set; }
        public string SenderWalletCurrencyAddress { get; set; }
        public string BeneficiaryWalletCurrencyAddress { get; set; }
        public string WalletId { get; set; }
        public Wallet Wallet { get; set; }

        public Transactions()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
