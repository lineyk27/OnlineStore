using OnlineStore.Models.Database;

namespace OnlineStore.Data.Interfaces
{
    interface IUnitOfWork
    {
        public Repository<Category> CategoryRepository { get; }
        public Repository<Comment> CommentRepository { get; }
        public Repository<Product> ProductRepository { get; }
        public Repository<Purchase> PurchaseRepository{ get;}
        public Repository<PurchaseProduct> PurchaseProductRepository{ get; }
        public Repository<Rate> RateRepository{ get; }
        public Repository<ShoppingCart> ShoppingCartRepository{ get; }
        public Repository<User> UserRepository{ get; }
        public Repository<UserRole> UserRoleRepository{ get;}
    }
}
