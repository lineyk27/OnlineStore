using System.Collections.Generic;
using OnlineStore.Models.Database;

namespace OnlineStore.Models.ViewModel
{
    public class UserPurchasesViewModel
    {
        public IEnumerable<Purchase> Purchases { get; set; }
    }
}
