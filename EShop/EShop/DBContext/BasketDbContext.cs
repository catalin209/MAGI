using EShop.Model.Basket;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.DBContext
{
    public class BasketDbContext : DbContext
    {
        public BasketDbContext(DbContextOptions<BasketDbContext> options)
        : base(options)
        {
        }
        public DbSet<Basket> Basket { get; set; }
        public DbSet<BasketCheckout> BasketCheckouts { get; set; }
        public DbSet<BasketItem>  BasketItem{ get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
