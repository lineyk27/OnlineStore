using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;

namespace OnlineStore.Models.ViewModel
{
    public class ProductEditModel
    {
        public int Id { get; set; }
        public string Producer { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public SelectList CommentsEnabled { get; set; }
        public SelectList Categories { get; set; }
        public string ImageName { get; set; }
        public IFormFile Image{ get; set; }
    }
}
