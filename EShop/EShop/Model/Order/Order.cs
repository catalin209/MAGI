using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Model.Order
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BasketCheckoutId { get; set; }
        public DateTime OrderData { get; set; }
        public double Total { get; set; }
        public int OrderNumber { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingState { get; set; }
        public string ShippingCountry { get; set; }
    }
}
