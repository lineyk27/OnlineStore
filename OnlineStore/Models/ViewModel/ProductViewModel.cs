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
        public bool Commented { get; set; }
        public bool Rated{ get; set; }
        public bool CanEditComments { get; set; }
        public bool CanEditProduct { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
