using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Models.Database
{
    public class Rate
    {
        public User User { get; set; }
        public Product Product { get; set; }
        public int Score { get; set; }
    }
}
