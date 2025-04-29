
using SolvexShop.Core.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace InternetBanking.Infrastructure.Identity.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new(Roles.Seller.ToString()));
            await roleManager.CreateAsync(new(Roles.User.ToString()));
            await roleManager.CreateAsync(new(Roles.Admin.ToString()));
        }

        
    }
}
