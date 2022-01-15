using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyEWalletApp.Models.WalletDTOs
{
    public class CurrencyConverter
    {
        [Required]
        public string From { get; set; }
        [Required]
        public string To { get; set; }
        [Required]
        public decimal amount { get; set; }
    }
}
