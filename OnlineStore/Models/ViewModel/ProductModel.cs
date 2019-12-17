using System;
using System.Collections.Generic;
using OnlineStore.Models.Database;

namespace OnlineStore.Models.ViewModel
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Producer{ get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public double Score { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public string ImageName { get; set; }
        public ProductModel(Product product, double score=0)
        {
            Id = product.Id;
            Producer = product.Producer;
            Model = product.Model;
            Description = product.Description;
            Category = product.Category.Name;
            Price = product.Price;
            Score = score;
            Comments = product.Comments;
            ImageName = product.Image.Path;
        }
        public ProductModel() { }
    }
}
