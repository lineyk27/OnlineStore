using System.Collections.Generic;
using System;

namespace OnlineStore.Models.Database
{
    public class Purchase
    {
        public int Id { get; set; }
        public string Adress { get; set; }
        public decimal FullPrice { get; set; }
        public DateTime CreationTime { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<PurchaseProduct> PurchaseProducts { get; set; }
    }
}
