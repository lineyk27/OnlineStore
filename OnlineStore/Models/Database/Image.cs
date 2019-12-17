using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Models.Database
{
    public class Image
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public Product Product { get; set; }
    }
}