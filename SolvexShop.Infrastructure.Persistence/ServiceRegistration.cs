using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SolvexShop.Core.Application.Interfaces.Repositories;
using SolvexShop.Infrastructure.Persistence.Contexts;
using SolvexShop.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvexShop.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDataBase"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("SolvexShop"));
            }
            else
            {
      
                var ConnectionString = configuration.GetConnectionString("IdentityConnection");
                services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(ConnectionString, m => m.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName).EnableRetryOnFailure()));
            }

            #region Dependency Injection
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductVariationRepository, ProductVariationRepository>();
            #endregion
        }
    }
}
