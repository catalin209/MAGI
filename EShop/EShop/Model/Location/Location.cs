using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Model.Location
{
    public class Location
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Latittude { get; set; }
        public double Longitude { get; set; }

    }
}
