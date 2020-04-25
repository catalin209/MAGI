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
            List<Product> products = GetProductList();
            CreateProducts(roContext, products);
            CreateProducts(bgContext, products);
            CreateProducts(srDbContext, products);
            CreateProducts(ukDbContext, products);
            CreateCatalog(roContext);
            CreateCatalog(bgContext);
            CreateCatalog(srDbContext);
            CreateCatalog(ukDbContext);


        }

        private static void CreateProducts(BaseContext context, List<Product> products)
        {
            for (int i = 0; i < products.Count; i++)
            {
                context.Products.Add(products[i]);
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

        private static List<Product> GetProductList()
        {
            Random rnd = new Random();
            List<Product> products = new List<Product>();
            for (int i = 0; i < 100; i++)
            {
                products.Add(new Product(i % 2 == 0 ? "Nvidia RTX " + i : "Ryzen " + i, i % 2 == 0 ? "GPU NUMBER" + i : "CPU number", 100 * i, rnd.Next(1, 4), i % 2 + 1));
            }

            return products;
        }
    }
}
