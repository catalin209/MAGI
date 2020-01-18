using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Infrastructure
{
    public static class SqlServerConfiguration
    {
        public static IConfiguration Configuration { get; set; }
        public static IConfigurationSection Section => Configuration.GetSection("ConnectionStrings");

        public static string UserConnection => Section.GetSection("UserConnection").Get<string>();
        public static string LocationConnection => Section.GetSection("LocationConnection").Get<string>();
        public static string BasketConnection => Section.GetSection("BasketConnection").Get<string>();
        public static string OrderConnection => Section.GetSection("OrderConnection").Get<string>();
        public static string ProductConnection => Section.GetSection("ProductConnection").Get<string>();

        public static IServiceCollection AddSqlServerConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            Configuration = configuration;        
            return services;
        }
    }
}
