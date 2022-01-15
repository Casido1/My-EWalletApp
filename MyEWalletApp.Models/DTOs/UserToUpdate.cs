using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyEWalletApp.Models.DTOs
{
    public class UserToUpdate
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }
        public string Gender { get; set; }

        [Required, MinLength(8, ErrorMessage = "Must be atleast 8 characters \nMust include atleast 1 uppercase character, lowercase chracter and special character")]

        public string Password { get; set; }

    }
}
