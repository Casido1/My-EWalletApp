using Microsoft.AspNetCore.Identity;
using MyEWalletApp.Models.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEWalletApp.DataAccess
{
    public class Seeder
    {
        private readonly UserManager<AppUser> _userMgr;
        private readonly RoleManager<IdentityRole> _roleMgr;
        private readonly MyEWalletAppContext _cntx;

        public Seeder(UserManager<AppUser> userMgr, RoleManager<IdentityRole> roleMgr, MyEWalletAppContext cntx)
        {
            _userMgr = userMgr;
            _roleMgr = roleMgr;
            _cntx = cntx;

        }

        public async Task SeedMe()
        {
            _cntx.Database.EnsureCreated();

            try
            {
                var roles = new string[] {"Noob", "Elite", "Admin"};
                if (!_roleMgr.Roles.Any())
                {
                    foreach (var role in roles)
                    {
                        await _roleMgr.CreateAsync(new IdentityRole(role));
                    }
                }


                if (!_userMgr.Users.Any())
                {
                    var user = new AppUser
                    { 
                        FirstName = "Ugochukwu",
                        LastName = "Anunihu",
                        CreatedAt = DateTime.Now,
                        Gender = "Male",
                        Email = "ugochukwu.anunihu@gmail.com",
                        UserName = "ugochukwu.anunihu@gmail.com",
                        Password = "Dap20000?"

                    };

               
                   var result = await _userMgr.CreateAsync(user, "Dap20000?");

                   if (result.Succeeded) await _userMgr.AddToRoleAsync(user, "Admin");

                   _cntx.SaveChanges();
                }
            }
            catch (DbException)
            {

            }
        }
    }
}
