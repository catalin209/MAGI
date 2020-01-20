using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.DTO
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public int Country { get; set; }
        public string Password { get; set; }
    }
}
