using System;
using System.Collections.Generic;
using System.Text;

namespace MyEWalletApp.Models.ReturnDTOs
{
    public class BalanceToReturn
    {
        public string CurrencyCode { get; set; }
        public decimal Balance { get; set; }
    }
}
