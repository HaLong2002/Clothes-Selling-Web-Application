using Microsoft.AspNetCore.Identity;
using Website_ASP.NET_Core_MVC.Models;

namespace Website_ASP.NET_Core_MVC.Data
{
    public static class ContextSeed
    {
        public static async Task SeedRolesAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Customer.ToString()));
        }

        public static async Task SeedAdminAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new User
            {
                UserName = "halong122002@gmail.com",
                Email = "halong122002@gmail.com",
                FullName = "Hạ Long",
                EmailConfirmed = true,
                //PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$$word.");
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Customer.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Admin.ToString());
                }

            }
        }
    }
}
