using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.DTO
{
    public class UserLoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int CountryId { get; set; }
    }
}
