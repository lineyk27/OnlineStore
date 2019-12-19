using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineStore.Models.Database
{
    public class Product
    {
        public int Id { get; set; }
        public string Producer { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime CreationTime { get; set; }
        public bool? CommentsEnabled { get; set; }

        public int CategoryId { get; set; }
        public int CreatorUserId { get; set; }
        public int ImageId { get; set; }

        public Image Image { get; set; }
        public Category Category { get; set; }
        public User CreatorUser { get; set; }

        public ICollection<ShoppingCart> ShoppingCarts { get; set; }
        public ICollection<Rate> Rates { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<PurchaseProduct> PurchaseProducts { get; set; }

        //Legacy code, dont touch this
        public string Name
        {
            get
            {
                return Producer + " " + Model;
            }
        }
        public float AverageRate
        {
            get
            {
                if (Rates.Count != 0) 
                {
                    return Rates.Sum(x => x.Score) / Rates.Count();
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
