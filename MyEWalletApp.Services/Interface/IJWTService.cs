using MyEWalletApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyEWalletApp.Services.Interface
{
    public interface IJWTService
    {
        public Task<string> GenerateToken(AppUser user, List<string> userRoles);
    }
}
