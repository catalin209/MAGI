using EShop.DTO;
using EShop.Model.User;
using EShop.Resolver;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepositoryResolver _repoResolver;
        public UserController(IRepositoryResolver resolver)
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

        // POST api/values
        [HttpPost]
        public ActionResult<User> Post([FromBody] UserDto userDto)
        {
            var result = _repoResolver.Resolve<User>(userDto.Country).Insert(new User()
            {
                FirstName = userDto.Username,
                Country = userDto.Country,
                Password = userDto.Password,
            });
            _repoResolver.Resolve<User>(userDto.Country).Save();

            return result;
        }

        [HttpPost("login")]
        public ActionResult<User> Post([FromBody] UserLoginDto userLoginDto)
        {
            var repo = _repoResolver.Resolve<User>(userLoginDto.CountryId);
            var result = repo.GetAll().FirstOrDefault(x => x.Username == userLoginDto.Username && x.Password == userLoginDto.Password);
            return result;
        }

    }
}
