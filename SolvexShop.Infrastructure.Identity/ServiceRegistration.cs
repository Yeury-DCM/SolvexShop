
using InternetBanking.Infrastructure.Identity.Seeds;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SolvexShop.Core.Application.Interfaces.Services;
using SolvexShop.Infrastructure.Identity.Context;
using SolvexShop.Infrastructure.Identity.Entities;
using SolvexShop.Infrastructure.Identity.Services;

namespace SolvexShop.Infrastructure.Identity
{
    public static class ServiceRegistration
    {
        public static void AddIdentityLayer(this IServiceCollection services, IConfiguration configuration)
        {
            #region Database Configuration
            if (configuration.GetValue<bool>("UseInMemoryDataBase"))
            {
                services.AddDbContext<IdentityContext>(options =>
                    options.UseInMemoryDatabase("IdentityDb"));
            }
            else
            {
                var ConnectionString = configuration.GetConnectionString("IdentityConnection");
                services.AddDbContext<IdentityContext>(options => options.UseSqlServer(ConnectionString, m => m.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName).EnableRetryOnFailure()));
            }
            #endregion

            #region Identity
           

            services.AddIdentityCore<ApplicationUser>()
            .AddRoles<IdentityRole>()
            .AddSignInManager()
            .AddEntityFrameworkStores<IdentityContext>()
            .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>(TokenOptions.DefaultProvider);

            services.Configure<DataProtectionTokenProviderOptions>(option =>
            {
                option.TokenLifespan = TimeSpan.FromHours(1);
            });



            services.AddAuthentication(options =>
            {
                options.DefaultScheme = IdentityConstants.ApplicationScheme;
                options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
                options.DefaultSignInScheme = IdentityConstants.ApplicationScheme;
            }).AddCookie(IdentityConstants.ApplicationScheme, options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                options.SlidingExpiration = true;
                options.LoginPath = "/Account/LogIn";
                options.LogoutPath = "/Account/LogOut";
                options.AccessDeniedPath = "/Account/AccessDenied";


                options.Events = new CookieAuthenticationEvents
                {
                    OnValidatePrincipal = async context =>
                    {

                    },
                    OnSigningOut = context =>
                    {

                        context.CookieOptions.Expires = DateTime.UtcNow.AddDays(-1);
                        return Task.CompletedTask;
                    }
                };
            });



            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;


            });
            #endregion

            #region Services
            services.AddTransient<IAccountService, AccountService>();
            #endregion

         
        }

        public async static Task RunSeedAsync(this IServiceProvider appServices, IConfiguration configuration)
        {
            using (var scope = appServices.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;

                try
                {
                    var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();


                    await DefaultRoles.SeedAsync(roleManager);

                    await DefaultSellerUser.SeedAsync(userManager);
                    await DefaultUser.SeedAsync(userManager); 
                    await DefaultAdminUser.SeedAsync(userManager);
                }
                catch (Exception)
                {
                }
            }
        }

    }
}
