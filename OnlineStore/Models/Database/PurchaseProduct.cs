using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Models.Database
{
    public class PurchaseProduct
    {
        public int PurchaseId { get; set; }
        public int ProductId { get; set; }
        public Purchase Purchase { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
    }
}
