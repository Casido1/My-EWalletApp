using System;
using System.Collections.Generic;
using System.Text;

namespace MyEWalletApp.Models.ReturnDTOs
{
    public class LoginCred
    {
        public string Id { get; set; }
        public string token { get; set; }
        public bool status { get; set; }
        public string Message { get; set; }
    }
}
