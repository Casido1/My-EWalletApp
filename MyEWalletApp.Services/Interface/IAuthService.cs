using MyEWalletApp.Models.DTOs;
using MyEWalletApp.Models.ReturnDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyEWalletApp.Services.Interface
{
    public interface IAuthService
    {
        public Task<LoginCred> LoginAsync(Login login);
    }
}
