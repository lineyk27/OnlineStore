using System;

namespace OnlineStore.Models.ViewModel
{
    public class FilterModel
    {
        public int? LowPrice { get; set; }
        public int? UpPrice { get; set; }
        public string Search { get; set; }
        public string Category { get; set; }
        public int? LowScore { get; set; }
    }
}
