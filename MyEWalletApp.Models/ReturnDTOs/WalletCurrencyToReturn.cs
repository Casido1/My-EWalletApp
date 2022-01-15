using System;
using System.Collections.Generic;
using System.Text;

namespace MyEWalletApp.Models.ReturnDTOs
{
    public class WalletCurrencyToReturn
    {
        public string CurrencyCode { get; set; }
        public decimal WalletCurrencyBalance { get; set; }
    }
}
