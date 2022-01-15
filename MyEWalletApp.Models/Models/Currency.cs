using System;
using System.Collections.Generic;
using System.Text;

namespace MyEWalletApp.Models.Models
{
    public class Currency : BaseEntity
    {
        public int Id { get; set; }
        public List<WalletCurrency> WalletCurrencies { get; set; }
        public string Name { get; set; }
        public string ShortCode { get; set; }

    }
}
