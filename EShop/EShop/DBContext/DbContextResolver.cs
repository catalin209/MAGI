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
            if (type == typeof(UserDbContext)) return _serviceProvider.GetService<UserDbContext>();
            if (type == typeof(LocationDbContext)) return _serviceProvider.GetService<LocationDbContext>();
            if (type == typeof(BasketDbContext)) return _serviceProvider.GetService<BasketDbContext>();
            if (type == typeof(ProductDbContext)) return _serviceProvider.GetService<ProductDbContext>();
            if (type == typeof(OrderDbContext)) return _serviceProvider.GetService<OrderDbContext>();

            throw new NotImplementedException();
        }
    }
}
