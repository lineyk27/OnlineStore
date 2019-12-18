using System;
using System.Collections.Generic;
using OnlineStore.Models.Database;

namespace OnlineStore.Models.ViewModel
{
    public class ShoppingCartModel
    {
        public IEnumerable<ShoppingCart> ShoppingCarts{ get; set; }
        public decimal TotalPrice { get; set; }
    }
}
