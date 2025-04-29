
using SolvexShop.Core.Domain.Enums;
using SolvexShop.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;

namespace InternetBanking.Infrastructure.Identity.Seeds
{
    public class DefaultSellerUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            ApplicationUser defaultUser = new()
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "seller@email.com",
                IdentificationNumber = "002-0034009-3",
                UserName = "sellerUser",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                IsActive = true,
            };

           

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {

                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    var createResult = await userManager.CreateAsync(defaultUser, "1234");
                    var addRoleResult =  await userManager.AddToRoleAsync(defaultUser, Roles.Seller.ToString());
                    Console.WriteLine("xd");
                }

            }

        }
    }
}
