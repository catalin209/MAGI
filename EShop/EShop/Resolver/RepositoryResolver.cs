using EShop.DBContext;
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

        IGenericRepository<T, BaseContext> IRepositoryResolver.Resolve<T>(CountryType type)
        {
            if (type == CountryType.Roumania) return _serviceProvider.GetService<IGenericRepository<T, RoDbContext>>() as IGenericRepository<T, BaseContext>;
            if (type == CountryType.Bulgaria) return _serviceProvider.GetService<IGenericRepository<T, BgDbContext>>() as IGenericRepository<T, BaseContext>;
            if (type == CountryType.Serbia) return _serviceProvider.GetService<IGenericRepository<T, SrDbContext>>() as IGenericRepository<T, BaseContext>;
            if (type == CountryType.Ukraine) return _serviceProvider.GetService<IGenericRepository<T, UkDbContext>>() as IGenericRepository<T, BaseContext>;

            throw new NotImplementedException();
        }
    }

    public enum CountryType
    {
        Roumania,
        Bulgaria,
        Serbia,
        Ukraine

    }
}
