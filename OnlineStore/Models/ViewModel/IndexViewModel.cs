using System.Collections.Generic;
using OnlineStore.Models.Database;

namespace OnlineStore.Models.ViewModel
{
    public class IndexViewModel
    {
        public IEnumerable<Product> Products{ get; set; }
        public PageViewModel PageViewModel { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
        public SortViewModel SortViewModel { get; set; }
    }
}