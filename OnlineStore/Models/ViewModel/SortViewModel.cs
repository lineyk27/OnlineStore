using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Models.ViewModel
{
    public enum SortState
    {
        NameAsc,
        NameDesc,
        RateAsc,
        RateDesc,
        PriceAsc,
        PriceDesc,
        CategoryAsc,
        CategoryDesc,
    }
    public class SortViewModel
    {
        public SortState NameSort { get; private set; }
        public SortState RateSort { get; private set; } 
        public SortState PriceSort { get; private set; }
        public SortState CategorySort { get; private set; }
        public SortState Current { get; private set; }
        public SortViewModel(SortState sortOrder)
        {
            NameSort = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            RateSort = sortOrder == SortState.RateAsc ? SortState.RateDesc : SortState.RateAsc;
            PriceSort = sortOrder == SortState.PriceAsc ? SortState.PriceDesc : SortState.CategoryAsc;
            CategorySort = sortOrder == SortState.CategoryAsc ? SortState.CategoryDesc : SortState.CategoryAsc;
            Current = sortOrder;
        }
    }
}
