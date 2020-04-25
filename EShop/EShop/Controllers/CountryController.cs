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
    public class CountryController : ControllerBase
    {
        private const int MAX_REPO_INDEX = 4;
        private readonly IRepositoryResolver _repoResolver;
        public CountryController(IRepositoryResolver resolver)
        {
            _repoResolver = resolver;
        }

        // GET: api/Country
        [HttpGet]
        public ActionResult Get()
        {
            List<int> values = new List<int>();
            foreach (int val in Enum.GetValues(typeof(Country)))
                values.Add(val);
            return Ok(values.Select(v => new { name = Enum.GetName(typeof(Country), (Country)v), id = v }));
        }
    }
}
