﻿using System;
using System.Collections.Generic;

namespace OnlineStore.Models.Database
{
    public class Product
    {
        public int Id { get; set; }
        public string Producer { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreationTime { get; set; }
        public bool CommentsEnabled { get; set; }

        public int CategoryId { get; set; }
        public int CreatorUserId { get; set; }

        public Category Category { get; set; }
        public User CreatorUser { get; set; }

        public ICollection<ShoppingCart> ShoppingCarts { get; set; }
        public ICollection<Rate> Rates { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<PurchaseProduct> PurchaseProducts { get; set; }
    }
}
