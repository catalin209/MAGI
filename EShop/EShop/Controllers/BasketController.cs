using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.Model.Basket;
using EShop.Model.Product;
using EShop.Model.User;
using EShop.Repository;
using EShop.Resolver;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IRepositoryResolver _repoResolver;
        public BasketController(IRepositoryResolver resolver)
        {
            _repoResolver = resolver;
        }

        // GET: api/Basket/5
        [HttpGet("getbasket")]
        public ActionResult<Basket> Get(int countryId, int userId)
        {
            Basket model = new Basket();
            try
            {
                var repoBasket = _repoResolver.Resolve<Basket>(countryId);
                var repoProduct = _repoResolver.Resolve<Product>(countryId);
                model = repoBasket.GetAll().First(b => b.UserId == userId);
                model.BasketItems = _repoResolver.Resolve<BasketItem>(countryId)
                                                 .GetAll()
                                                 .Where(bi => bi.BasketId == model.Id)
                                                 .ToList();
                foreach(BasketItem bi in model.BasketItems)
                {
                    bi.Product = repoProduct.GetById(bi.Id);
                }
            }
            catch (Exception)
            {
                return BadRequest(new { success = false, message = "Could not get basket!" });
            }
            return Ok(new { basketId = model.Id, productList = model.BasketItems.Select(bi => bi.Product), totalCount = model.BasketItems.Count });
        }

        // PUT: api/Basket/5
        [HttpPost("put")]
        public ActionResult Put(int countryId, int id, int productId)
        {
            try
            {
                var repo = _repoResolver.Resolve<BasketItem>(countryId);
                BasketItem item = new BasketItem
                {
                    BasketId = id,
                    ProductId = productId
                };
                repo.Insert(item);
                repo.Save();
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpPost("delete")]
        public ActionResult Delete(int countryId, int id)
        {
            try
            {
                var repo = _repoResolver.Resolve<BasketItem>(countryId);
                List<BasketItem> toDelete = repo.GetAll()
                                                .Where(bi => bi.BasketId == id)
                                                .ToList();
                foreach (BasketItem bi in toDelete)
                    repo.Delete(bi.Id);
                repo.Save();
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
