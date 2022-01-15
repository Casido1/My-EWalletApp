using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyEWalletApp.Models.Models
{
    public class BlackListedTokens
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BlacklistedTokensId { get; set; }
        public string Token { get; set; }
        public BlackListedTokens()
        {

        }
    }
}
