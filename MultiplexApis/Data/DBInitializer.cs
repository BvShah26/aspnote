using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace MultiplexApis.Data
{
    public static class DBInitializer
    {
        public static async Task IntializeAsync(IServiceProvider serviceProvider, UserManager<ApplicationUser> _userManager)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] rolesName = { "SuperAdmin", "MultiplexAdmin","Client" };

            IdentityResult result;
            // Adding Role
            foreach (var item in rolesName)
            {
                var roleExists = await RoleManager.RoleExistsAsync(item);
                if (!roleExists)
                {
                    result = await RoleManager.CreateAsync(new IdentityRole(item));
                }
            }

            string Email = "Admin@gmail.com";
            string Password = "Lanet@1234";

            //Adding Default User [ SuperAdmin ] 
            if (await _userManager.FindByEmailAsync(Email) == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.Email = Email;
                user.UserName = Email;
                
                IdentityResult identityResult = _userManager.CreateAsync(user, Password).Result;
                if (identityResult.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "SuperAdmin").Wait();
                }
            }
        }
    }
}
