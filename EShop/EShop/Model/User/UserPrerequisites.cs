using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Model.User
{
    public class UserPrerequisites
    {
        public UserPrerequisites()
        {

        }
        public UserPrerequisites(string username, int country)
        {
            Username = username;
            Country = country;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public int Country { get; set; }
    }
}
