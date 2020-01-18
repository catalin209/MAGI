using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.DBContext;
using EShop.Model.User;
using EShop.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IGenericRepository<User,UserDbContext> _userRepo; 
        public ValuesController(IGenericRepository<User,UserDbContext> userRepo)
        {
            _userRepo = userRepo;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            _userRepo.Insert(new User("Dan", "Toma", "1234-5678-9136-5321", "Pitesti", "Roumania", "danT@gmail.com"));
            _userRepo.Save();
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
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
