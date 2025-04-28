
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SolvexShop.Infrastructure.Identity.Context;

namespace SolvexShop.Infrastructure.Identity
{
    public static class ServiceRegistration
    {
        public static void AddIdentityLayer(this IServiceCollection services, IConfiguration configuration)
        {
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
        }
    }
}
