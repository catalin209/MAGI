using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.DBContext
{
    public interface IDbContextResolver
    {
        DbContext Resolve(Type type);
    }

}
