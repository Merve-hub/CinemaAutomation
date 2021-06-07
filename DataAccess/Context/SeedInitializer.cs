using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Context
{
    public static class SeedInitializer
    {   public static void SeedData(UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
           

        }
        
        private static void SeedUsers(UserManager<AppUser> userManager)
        {
            if (userManager.FindByNameAsync("testAdmin").Result == null)
            {
                AppUser user = new AppUser();
                user.UserName = "testAdmin";
                user.Email = "testAdmin@test.com";
                user.FirstName = "x";
                user.LastName = "y";

                var result = userManager.CreateAsync(user, "test123++").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administratör").Wait();

                }
                else
                {
                    foreach(var item in result.Errors)
                    {

                    }

                }



                if (userManager.FindByNameAsync("testUser").Result == null)
                {
                    AppUser appUser = new AppUser();
                 
                    user.UserName = "testUser";
                    user.Email = "testUser@test.com";
                    user.FirstName = "a";
                    user.LastName = "b";

                    var sonuc=userManager.CreateAsync(user, "test123++").Result;

                    if (sonuc.Succeeded)
                    {
                        userManager.AddToRoleAsync(user, "User").Wait();

                    }


                }

            }

        }
        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {

            if (roleManager.RoleExistsAsync("Administratör").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Administrator";
                var roleResult = roleManager.CreateAsync(role).Result;
                if (roleResult.Succeeded)
                {

                }

            }
            if (roleManager.RoleExistsAsync("Administratör").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "User";
                var result = roleManager.CreateAsync(role).Result;

                if (result.Succeeded)
                {

                }
            }

        }
    }

}