using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.Model.Enums;
using EShop.Model.Product;
using EShop.Resolver;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private const int MAX_REPO_INDEX = 4;
        private readonly IRepositoryResolver _repoResolver;
        public ProductController(IRepositoryResolver resolver)
        {
            _repoResolver = resolver;
        }

        // GET: api/Product
        [HttpGet]
        public ActionResult<List<Product>> Get(int minPrice = 0, int maxPrice = Int32.MaxValue, bool available = false, int countryId = 0)
        {
            List<Product> products = new List<Product>();
            try
            {
                foreach(int cId in Enum.GetValues(typeof(Country)))
                {
                    try
                    {
                        products = _repoResolver.Resolve<Product>(cId)
                                                  .GetAll().ToList();
                        break;
                    }
                    catch (Exception ex)
                    {
                        if (cId >= MAX_REPO_INDEX)
                            throw ex;
                    }
                }
                products = products.Where(p => p.Price >= minPrice && p.Price <= maxPrice)
                                   .ToList();
                if (available)
                    products = products.Where(p => p.Available).ToList();
                if (countryId > 0 && countryId < 5)
                    products = products.Where(p => p.Country == countryId).ToList();
            }
            catch (Exception)
            {

            }
            return products;
        }
    }
}
