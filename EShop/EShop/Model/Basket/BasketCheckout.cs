using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Model.Basket
{
    public class BasketCheckout
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Strert { get; set; }
        public string Country { get; set; }
        public int BasketId { get; set; }
        public string CardNumber { get; set; }
        public DateTime CardExpiration { get; set; }
        public string CardSecurityNumber { get; set; }
    }
}
