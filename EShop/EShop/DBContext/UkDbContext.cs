using EShop.Model.Location;
using EShop.Model.Order;
using EShop.Model.Product;
using EShop.Model.User;
using Microsoft.EntityFrameworkCore;

namespace EShop.DBContext
{
    public class UkDbContext : BaseContext
    {
        public UkDbContext(DbContextOptions<UkDbContext> options) : base(DbContextExtension.ChangeOptionsType<BaseContext>(options))
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
