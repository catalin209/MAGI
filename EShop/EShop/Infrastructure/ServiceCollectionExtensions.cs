using EShop.DBContext;
using EShop.Repository;
using EShop.Resolver;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEShop(this IServiceCollection service, IConfiguration configuration) =>
            service
                .AddSql(configuration)
                .AddResolvers();

        private static IServiceCollection AddResolvers(this IServiceCollection service) =>
            service
            .AddTransient<IDbContextResolver, DbContextResolver>()
            .AddTransient<IRepositoryResolver, RepositoryResolver>()
            .AddTransient(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));


        private static IServiceCollection AddSql(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddEntityFrameworkSqlServer()
                .AddSqlServerConfiguration(configuration)
                .AddSingleton<BaseContext>()
                .AddDbContext<RoDbContext>(options => options.UseSqlServer(SqlServerConfiguration.RoConnection))
                .AddDbContext<BgDbContext>(options => options.UseSqlServer(SqlServerConfiguration.BgConnection))
                .AddDbContext<SrDbContext>(options => options.UseSqlServer(SqlServerConfiguration.SrConnection))
                .AddDbContext<UkDbContext>(options => options.UseSqlServer(SqlServerConfiguration.UkConnection));
    }
}