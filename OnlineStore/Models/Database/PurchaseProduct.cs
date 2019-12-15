using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Models.Database
{
    public class PurchaseProduct
    {
        public Purchase Purchase { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
    }
}
