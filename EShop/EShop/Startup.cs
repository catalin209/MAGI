using EShop.DBContext;
using EShop.Infrastructure;
using EShop.Repository;
using EShop.Resolver;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EShop
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().
                SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton<BaseContext>();
            services
                .AddEntityFrameworkSqlServer()
                .AddSqlServerConfiguration(Configuration)
                .AddDbContext<RoDbContext>(options => options.UseSqlServer(SqlServerConfiguration.RoConnection))
                .AddDbContext<BgDbContext>(options => options.UseSqlServer(SqlServerConfiguration.BgConnection))
                .AddDbContext<SrDbContext>(options => options.UseSqlServer(SqlServerConfiguration.SrConnection))
                .AddDbContext<UkDbContext>(options => options.UseSqlServer(SqlServerConfiguration.UkConnection))
                .AddTransient<IDbContextResolver, DbContextResolver>()
                .AddTransient<IRepositoryResolver,RepositoryResolver>()
                .AddTransient(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var roContext = serviceScope.ServiceProvider.GetRequiredService<RoDbContext>();
                var bgContext = serviceScope.ServiceProvider.GetRequiredService<BgDbContext>();
                var srContext = serviceScope.ServiceProvider.GetRequiredService<SrDbContext>();
                var ukContext = serviceScope.ServiceProvider.GetRequiredService<UkDbContext>();
                

                if (!(roContext.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
                {
                    roContext.Database.Migrate();
                    bgContext.Database.Migrate();
                    srContext.Database.Migrate();
                    ukContext.Database.Migrate();
                    EShopSeed.CreateSeed(roContext, bgContext, srContext, ukContext);
                }
                else
                {
                    roContext.Database.Migrate();
                    bgContext.Database.Migrate();
                    srContext.Database.Migrate();
                    ukContext.Database.Migrate();
                }

            }
            app.UseHttpsRedirection()
                .UseMvc();
        }
    }
}

