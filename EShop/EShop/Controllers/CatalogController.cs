using EShop.Model.Product;
using EShop.Resolver;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IRepositoryResolver _repoResolver;
        public CatalogController(IRepositoryResolver resolver)
        {
            _repoResolver = resolver;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            //_userRepo.Insert(new User("Dan", "Toma", "1234-5678-9136-5321", "Pitesti", "Roumania", "danT@gmail.com","pass1234"));
            //_userRepo.Save();
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Product>> Get(int country, int id)
        {
            var products = _repoResolver.Resolve<Product>(country).GetAll().Where(x => x.CategoryId == id);

            return Ok(products);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
