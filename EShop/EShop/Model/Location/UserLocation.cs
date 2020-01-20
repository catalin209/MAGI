using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Model.Location
{
    public class UserLocation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User.User User { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}
