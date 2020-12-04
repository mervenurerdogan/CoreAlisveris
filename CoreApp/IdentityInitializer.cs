using CoreApp.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp
{
    public class IdentityInitializer
    {


        public static void OlusuturAdmin(UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            //kontrol etmeden önce bir user oluşturuyoruz
            AppUser appUser = new AppUser()
            {

                Name = "Merve Nur",
                Surname = "Erdoğan",
                UserName = "Merve"
            };

            if (userManager.FindByNameAsync("Merve").Result==null)
            {
               var ıdentityResult = userManager.CreateAsync(appUser, "1").Result;


            }

            if (roleManager.FindByNameAsync("Admin").Result==null)
            {

                IdentityRole role = new IdentityRole
                {
                    Name = "Admin"
                };

                var IdentityResult=  roleManager.CreateAsync(role).Result;

                var result =userManager.AddToRoleAsync(appUser, role.Name).Result;

            }


        }
    }
}
