using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyEWalletApp.Models.Models
{
    public class AppUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; } = DateTime.Now;
        public string Gender { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; } = false;
        public List<Wallet> Wallets { get; set; }

        public AppUser()
        {
            Wallets = new List<Wallet>();
        }

    }
}
