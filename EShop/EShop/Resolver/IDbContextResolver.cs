using EShop.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Resolver
{
    public interface IDbContextResolver
    {
        BaseContext Resolve(Type type);
    }

}
