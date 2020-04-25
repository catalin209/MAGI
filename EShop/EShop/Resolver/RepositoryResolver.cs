using EShop.DBContext;
using EShop.Model.Basket;
using EShop.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace EShop.Resolver
{
    public class RepositoryResolver : IRepositoryResolver
    {
        private readonly IServiceProvider _serviceProvider;
        public RepositoryResolver(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

        }

        IGenericRepository<T, BaseContext> IRepositoryResolver.Resolve<T>(int type)
        {
            if (type == 1) return _serviceProvider.GetService<IGenericRepository<T, RoDbContext>>() as IGenericRepository<T, BaseContext>;
            if (type == 2) return _serviceProvider.GetService<IGenericRepository<T, BgDbContext>>() as IGenericRepository<T, BaseContext>;
            if (type == 3) return _serviceProvider.GetService<IGenericRepository<T, UkDbContext>>() as IGenericRepository<T, BaseContext>;
            if (type == 4) return _serviceProvider.GetService<IGenericRepository<T, SrDbContext>>() as IGenericRepository<T, BaseContext>;

            throw new NotImplementedException();
        }
    }
}
