using Microsoft.Extensions.DependencyInjection;
using AssetManager.Entity;
using AssetManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManager
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(   this IServiceCollection services)
        {
            services.AddTransient<IWebServices<UnitProfile>, UnitProfileService>();
            services.AddTransient<IWebServices<Unit>, UnitService>();
            // Add all other services here.
            return services;
        }
    }
}
