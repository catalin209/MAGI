using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Model.Product
{
    public class Catalog
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int TypeId { get; set; }
    }
}
