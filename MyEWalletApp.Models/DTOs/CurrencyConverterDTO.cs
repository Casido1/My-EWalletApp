using System.ComponentModel.DataAnnotations;


namespace MyEWalletApp.Models.DTOs
{
    public class CurrencyConverterDTO
    {
        [Required]
        public string From { get; set; }
        [Required]
        public string To { get; set; }
        [Required]
        public decimal amount { get; set; }
    }
}