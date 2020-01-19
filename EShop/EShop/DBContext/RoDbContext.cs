using EShop.Model.Location;
using EShop.Model.Order;
using EShop.Model.Product;
using EShop.Model.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.DBContext
{
    public class RoDbContext : BaseContext
    {
        public RoDbContext(DbContextOptions<RoDbContext> options) : base(DbContextException.ChangeOptionsType<BaseContext>(options))
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
