using EShop.DTO;
using EShop.Model.Enums;
using EShop.Model.User;
using EShop.Resolver;
using EShop.Utils;
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
        private const int MAX_REPO_INDEX = 4;
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
            foreach (int cId in Enum.GetValues(typeof(Country)))
            {
                var repo = _repoResolver.Resolve<UserPrerequisites>(cId);
                repo.Insert(new UserPrerequisites
                {
                    Id = result.Id,
                    Username = userDto.Username,
                    Country = userDto.Country
                });
                repo.Save();
            }
            _repoResolver.Resolve<User>(userDto.Country).Save();

            return result;
        }

        [HttpPost("login")]
        public ActionResult<User> Post([FromBody] UserLoginDto userLoginDto)
        {
            User result = null;
            try
            {
                List<UserPrerequisites> prerequisites = null;
                foreach (int cId in Enum.GetValues(typeof(Country)))
                {
                    try
                    {
                        prerequisites = _repoResolver.Resolve<UserPrerequisites>(cId)
                                                     .GetAll().ToList();
                        break;
                    }
                    catch (Exception ex)
                    {
                        if (cId >= Constants.MAX_REPO_INDEX)
                            throw ex;
                    }
                }
                int countryId = prerequisites.FirstOrDefault(p => p.Username == userLoginDto.Username).Country;
                var repo = _repoResolver.Resolve<User>(countryId);
                result = repo.GetAll().FirstOrDefault(x => x.Username == userLoginDto.Username && x.Password == userLoginDto.Password);
            }
            catch (Exception)
            {

            }
            
            return result;
        }

    }
}
