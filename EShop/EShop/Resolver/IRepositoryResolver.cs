using EShop.DBContext;
using EShop.Repository;
using System;

namespace EShop.Resolver
{
    public interface IRepositoryResolver
    {
        IGenericRepository<T, BaseContext> Resolve<T>(int countryId)
           where T : class;
    }
}
