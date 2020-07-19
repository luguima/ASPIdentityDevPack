using ASPIdentityDevPack.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPIdentityDevPack
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            // Resolve another dependencies here!
            //services.AddScoped<IUserClaimsPrincipalFactory<CustomIdentityUser>, UserClaimsPrincipalFactory<CustomIdentityUser>>();
            
            return services;
        }
    }
}
