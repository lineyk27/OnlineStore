using System;
using System.Collections.Generic;
using OnlineStore.Models.Database;

namespace OnlineStore.Models.ViewModel
{
    public class ProductViewModel
    {
        public Product Product{get;set;}
        public bool InShopingCart { get; set; }
        public bool InPurchase { get; set; }
        public List<Comment> Comments { get; set; }
        public string Comment { get; set; }
    }
}
