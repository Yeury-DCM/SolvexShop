

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SolvexShop.Core.Application.Interfaces.Services;
using SolvexShop.Core.Application.Mapping;
using SolvexShop.Core.Application.Services;
using System.Reflection;

namespace SolvexShop.Core.Application
{
    public static class ServiceRegistration
    {

        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddTransient<ICurrentUserService, CurrentUserService>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
        }

        public static void ApplicationLayerGenericConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(m => m.AddProfile(new GeneralProfile()), typeof(GeneralProfile));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        }
    }
}
