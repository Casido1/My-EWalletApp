using System;
using System.Collections.Generic;
using System.Text;

namespace MyEWalletApp.Models.Models
{
    public class BaseEntity
    {
        public string CreatedAt { get; set; }
        public string ModifiedAt { get; set; } = DateTime.Now.ToString();
    }
}
