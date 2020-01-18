using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Model.Location
{
    public class UserLocation
    {
        public int UserLocationId { get; set; }
        public int UserId { get; set; }
        public int LocationId { get; set; }
    }
}
