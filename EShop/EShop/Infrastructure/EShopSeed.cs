using EShop.DBContext;
using EShop.Model.Product;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Infrastructure
{
    public static class EShopSeed
    {
        public static void CreateSeed(RoDbContext roContext, BgDbContext bgContext, SrDbContext srDbContext, UkDbContext ukDbContext)
        {

            CreateProducts(roContext);
            CreateProducts(bgContext);
            CreateProducts(srDbContext);
            CreateProducts(ukDbContext);
            CreateCatalog(roContext);
            CreateCatalog(bgContext);
            CreateCatalog(srDbContext);
            CreateCatalog(ukDbContext);


        }

        private static void CreateProducts(BaseContext context)
        {
            for (int i = 0; i < 100; i++)
            {
                var product = new Product(i % 2 == 0 ? "Nvidia RTX " + i : "Ryzen " + i, i % 2 == 0 ? "GPU NUMBER" + i : "CPU number", 100 * i, "Germany", i % 2 + 1);
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        private static void CreateCatalog(BaseContext roContext)
        {
            roContext.Catalog.Add(new Catalog("This category contains GPU products", 1));
            roContext.Catalog.Add(new Catalog("This category contains CPU products", 2));
            roContext.CatalogItems.Add(new CatalogType("GPU"));
            roContext.CatalogItems.Add(new CatalogType("CPU"));
            roContext.SaveChanges();

        }
    }
}
