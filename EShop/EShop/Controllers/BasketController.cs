using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.Model.Basket;
using EShop.Model.User;
using EShop.Repository;
using EShop.Resolver;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Controllers
{
    [Route("api/basket")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IRepositoryResolver _repoResolver;
        public BasketController(IRepositoryResolver resolver)
        {
            _repoResolver = resolver;
        }

        // GET: api/Basket/5
        [HttpGet("{id}")]
        public ActionResult<Basket> Get(int countryId, int userId)
        {
            Basket model = new Basket();
            try
            {
                var repo = _repoResolver.Resolve<Basket>(countryId);
                model = repo.GetAll().First(b => b.UserId == userId);
                model.BasketItems = _repoResolver.Resolve<BasketItem>(countryId)
                                                 .GetAll()
                                                 .Where(bi => bi.BasketId == model.Id)
                                                 .ToList();
            }
            catch (Exception)
            {
                return BadRequest(new { success = false, message = "Could not get basket!" });
            }
            return Ok(model);
        }

        // PUT: api/Basket/5
        [HttpPost("/put/{id}")]
        public ActionResult Put(int countryId, int id, [FromBody] BasketItem item)
        {
            try
            {
                var repo = _repoResolver.Resolve<BasketItem>(countryId);
                item.BasketId = id;
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
        [HttpPost("delete/{id}")]
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
