using EShop.DBContext;
using EShop.Repository;
using System;

namespace EShop.Resolver
{
    public interface IRepositoryResolver
    {
        IGenericRepository<T, BaseContext> Resolve<T>(CountryType countryId)
           where T : class;
    }
}
