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

        public static string RoConnection => Section.GetSection("RoConnection").Get<string>();
        public static string BgConnection => Section.GetSection("BgConnection").Get<string>();
        public static string SrConnection => Section.GetSection("SrConnection").Get<string>();
        public static string UkConnection => Section.GetSection("UkConnection").Get<string>();

        public static IServiceCollection AddSqlServerConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            Configuration = configuration;        
            return services;
        }
    }
}
