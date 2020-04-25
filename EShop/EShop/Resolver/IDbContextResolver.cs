using EShop.DBContext;
using System;

namespace EShop.Resolver
{
    public interface IDbContextResolver
    {
        BaseContext Resolve(Type type);
    }

}
