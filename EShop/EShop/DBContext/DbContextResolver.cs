using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.DBContext
{
    public class DbContextResolver : IDbContextResolver
    {
        private readonly IServiceProvider _serviceProvider;
        public DbContextResolver(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public DbContext Resolve(Type type)
        {
            if (type == typeof(RoDbContext)) return _serviceProvider.GetService<RoDbContext>();
            if (type == typeof(BgDbContext)) return _serviceProvider.GetService<BgDbContext>();
            if (type == typeof(SrDbContext)) return _serviceProvider.GetService<SrDbContext>();
            if (type == typeof(UkDbContext)) return _serviceProvider.GetService<UkDbContext>();

            throw new NotImplementedException();
        }
    }
}
