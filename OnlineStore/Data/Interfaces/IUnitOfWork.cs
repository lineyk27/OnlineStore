using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using OnlineStore.Models.Database;

namespace OnlineStore.Data.Interfaces
{
    interface IUnitOfWork
    {
        Repository<Category> CategoryRepository { get; set; }
        Repository<Comment> CommentRepository { get; set; }
        Repository<Product> ProductRepository { get; set; }
        Repository<Purchase> PurchaseRepository{ get; set; }
        Repository<PurchaseProduct> PurchaseProductRepository{ get; set; }
        Repository<Rate> RateRepository{ get; set; }
        Repository<ShoppingCart> ShoppingCartRepository{ get; set; }
        Repository<User> UserRepository{ get; set; }
        Repository<UserRole> UserRoleRepository{ get; set; }
    }
}
