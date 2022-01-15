using System;
using System.Collections.Generic;
using System.Text;

namespace MyEWalletApp.Models.ReturnDTOs
{
    public class WalletToReturn
    {
        public string MainCurrency { get; set; }
        public decimal WalletBalance { get; set; }
    }
}
