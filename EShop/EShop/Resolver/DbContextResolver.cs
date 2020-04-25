using EShop.DBContext;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EShop.Resolver
{
    public class DbContextResolver : IDbContextResolver
    {
        private readonly IServiceProvider _serviceProvider;

        public DbContextResolver(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public BaseContext Resolve(Type type)
        {
            if (type == typeof(RoDbContext)) return _serviceProvider.GetService<RoDbContext>();
            if (type == typeof(BgDbContext)) return _serviceProvider.GetService<BgDbContext>();
            if (type == typeof(SrDbContext)) return _serviceProvider.GetService<SrDbContext>();
            if (type == typeof(UkDbContext)) return _serviceProvider.GetService<UkDbContext>();

            throw new NotImplementedException();
        }
    }
}
