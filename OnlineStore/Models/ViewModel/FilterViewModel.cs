using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineStore.Models.Database;
namespace OnlineStore.Models.ViewModel
{
    public class FilterViewModel
    {
        public FilterViewModel(List<Category> categories,
            int? category,
            string name,
            decimal? lowprice,
            decimal? upprice,
            decimal? lowrate
            )
        {
            categories.Insert(0, new Category() { Name="All", Id=0});
            Categories = new SelectList(categories, "Id", "Name", category);
            SelectedCategory = category;
            SelectedName = name;
        }
        public SelectList Categories { get; private set; }
        public int? SelectedCategory { get; private set; }
        public string SelectedName { get; private set; }
        public decimal? LowPrice { get; private set; }
        public decimal? UpPrice { get; private set; }
        public float LowRate { get; private set; }
    }
}
