﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Model.Basket
{
    public class BasketItem
    {
        public int Id { get; set; }
        public int BarketId { get; set; }
        public int ProductId { get; set; }
    }
}
