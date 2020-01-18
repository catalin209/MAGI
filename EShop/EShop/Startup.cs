using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.DBContext;
using EShop.Infrastructure;
using EShop.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

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

            

            services
                .AddEntityFrameworkSqlServer()
                .AddSqlServerConfiguration(Configuration)
                .AddDbContext<UserDbContext>(options => options.UseSqlServer(SqlServerConfiguration.UserConnection))
                .AddDbContext<LocationDbContext>(options => options.UseSqlServer(SqlServerConfiguration.LocationConnection))
                .AddDbContext<BasketDbContext>(options => options.UseSqlServer(SqlServerConfiguration.BasketConnection))
                .AddDbContext<OrderDbContext>(options => options.UseSqlServer(SqlServerConfiguration.OrderConnection))
                .AddDbContext<ProductDbContext>(options => options.UseSqlServer(SqlServerConfiguration.ProductConnection));

            services.AddTransient<IDbContextResolver, DbContextResolver>();
            services.AddTransient(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
          
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var userContext = serviceScope.ServiceProvider.GetRequiredService<UserDbContext>();
                var locationContext = serviceScope.ServiceProvider.GetRequiredService<LocationDbContext>();
                var basketContext = serviceScope.ServiceProvider.GetRequiredService<BasketDbContext>();
                var orderContext = serviceScope.ServiceProvider.GetRequiredService<OrderDbContext>();
                var productContext = serviceScope.ServiceProvider.GetRequiredService<ProductDbContext>();
                userContext.Database.Migrate();
                locationContext.Database.Migrate();
                basketContext.Database.Migrate();
                orderContext.Database.Migrate();
                productContext.Database.Migrate();
            }

            app.UseHttpsRedirection().UseMvc();
        }
    }
}
