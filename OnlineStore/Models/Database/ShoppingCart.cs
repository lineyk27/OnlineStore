using System;
using System.Collections.Generic;

namespace OnlineStore.Models.Database
{
    public class ShoppingCart
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }

        public User User { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
    }
}
