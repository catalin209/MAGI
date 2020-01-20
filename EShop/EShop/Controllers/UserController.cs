using EShop.DTO;
using EShop.Model.Basket;
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
        [HttpPost("register")]
        public ActionResult<User> Post(string username, string password, int countryId)
        {
            var repoUser = _repoResolver.Resolve<User>(countryId);
            var result = repoUser.Insert(new User()
            {
                FirstName = username,
                Country = countryId,
                Password = password,
            });
            repoUser.Save();

            var repoBasket = _repoResolver.Resolve<Basket>(countryId);
            repoBasket.Insert(new Basket
            {
                UserId = result.Id
            });
            repoBasket.Save();

            foreach (int cId in Enum.GetValues(typeof(Country)))
            {
                var repo = _repoResolver.Resolve<UserPrerequisites>(cId);
                repo.Insert(new UserPrerequisites
                {
                    Id = result.Id,
                    Username = username,
                    Country = countryId
                });
                repo.Save();
            }

            return result;
        }

        [HttpPost("login")]
        public ActionResult<User> Post(string username, string password)
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
                int countryId = prerequisites.FirstOrDefault(p => p.Username == username).Country;
                var repo = _repoResolver.Resolve<User>(countryId);
                result = repo.GetAll().FirstOrDefault(x => x.Username == username && x.Password == password);
            }
            catch (Exception)
            {

            }
            
            return result;
        }

    }
}
