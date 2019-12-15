using System;
using System.Collections.Generic;

namespace OnlineStore.Models.Database
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Adress { get; set; }
        public string AuthValue { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastLogin { get; set; }

        public int RoleId { get; set; }
        public UserRole Role { get; set; }
        
        public ICollection<Product> Products { get; set; }
        public ICollection<ShoppingCart> ShoppingCart { get; set; }
        public ICollection<Rate> Rates { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Purchase> Purchases { get; set; }


    }
}
