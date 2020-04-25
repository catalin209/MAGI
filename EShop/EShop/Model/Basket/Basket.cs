﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Model.Basket
{
    public class Basket
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User.User User { get; set; }
        public List<BasketItem> BasketItems { get; set; }
    }
}
