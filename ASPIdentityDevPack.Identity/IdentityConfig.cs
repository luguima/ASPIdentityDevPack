using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetDevPack.Identity;
using NetDevPack.Identity.Jwt;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASPIdentityDevPack.Identity
{
    public static class IdentityConfig
    {
        public static void AddWebAppIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<CustomIdentityContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("CustomConnection")));

            services.AddIdentityEntityFrameworkContextConfiguration(options =>
                SqlServerDbContextOptionsExtensions.UseSqlServer(options, configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("ASPIdentityDevPack.Identity")));

            services.AddCustomIdentity<CustomIdentityUser>(options =>
            {
                options.SignIn.RequireConfirmedEmail = false;
                options.Lockout.MaxFailedAccessAttempts = 5;
            })
            .AddCustomRoles<MyIdentityRoles>()
            .AddCustomEntityFrameworkStores<MyIdentityContext>()
            .AddDefaultTokenProviders();

            services.AddIdentityConfiguration();

            // Default JWT configuration from NetDevPack.Identity
            services.AddJwtConfiguration(configuration, "AppSettings");
        }

        public class MyIdentityRoles : IdentityRole
        {

        }

        public class MyIdentityContext : IdentityDbContext<CustomIdentityUser, MyIdentityRoles, string>
        {
            public MyIdentityContext(DbContextOptions<MyIdentityContext> options) : base(options) { }
        }
    }
}
