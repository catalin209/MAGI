using EShop.Model.Location;
using EShop.Model.Order;
using EShop.Model.Product;
using EShop.Model.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using System;
using System.Linq;

namespace EShop.DBContext
{
    public class BgDbContext : BaseContext 
    {
        public BgDbContext(DbContextOptions<BgDbContext> options) : base(DbContextException.ChangeOptionsType<BaseContext>( options))
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

       
    }


}
