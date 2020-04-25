using EShop.DBContext;
using EShop.Model.Basket;
using EShop.Resolver;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Repository
{
    public class BasketRepository<Q> : GenericRepository<Basket, Q> where Q : BaseContext
    {
        public BasketRepository(IDbContextResolver _dbContextResolver) : base(_dbContextResolver) { }

        public virtual Basket GetById(int id)
        {
            return _context.Baskets.Include(b => b.BasketItems.Select(bi => bi.Product)).FirstOrDefault(b => b.Id == id);
        }
    }
}
