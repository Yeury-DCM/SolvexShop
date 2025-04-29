using SolvexShop.Core.Domain.Enums;
using SolvexShop.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;

namespace InternetBanking.Infrastructure.Identity.Seeds
{
    public static class DefaultUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            ApplicationUser defaultUser = new()
            {
                FirstName = "Jane",
                LastName = "Doe",
                Email = "user@email.com",
                UserName = "user",
                IdentificationNumber = "001-0034009-3",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                IsActive = true
            };

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {

                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "1234");
                    await userManager.AddToRoleAsync(defaultUser, Roles.User.ToString());
                }

            }


        }
    }
}
