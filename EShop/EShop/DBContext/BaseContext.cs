using EShop.Model.Location;
using EShop.Model.Order;
using EShop.Model.Product;
using EShop.Model.User;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace EShop.DBContext
{
    public class BaseContext : DbContext
    {

        public BaseContext(DbContextOptions<BaseContext> options)
        : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<UserLocation> UserLocations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Catalog> Catalog { get; set; }
        public DbSet<CatalogType> CatalogItems { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
