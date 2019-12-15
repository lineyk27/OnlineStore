using System;

using OnlineStore.Data.Interfaces;
using OnlineStore.Models.Database;

namespace OnlineStore.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private OnlineStoreDbContext context = OnlineStoreDbContextFactory.Create();
        private bool disposed = false;
        public Repository<Category> CategoryRepository
        {
            get
            {
                if (CategoryRepository == null)
                {
                    CategoryRepository = new Repository<Category>(context);
                }
                return CategoryRepository;
            }
            private set { }
        }
        public Repository<User> UserRepository
        {
            get
            {
                if (UserRepository == null)
                {
                    UserRepository = new Repository<User>(context);
                }
                return UserRepository;
            }
            private set { }
        }
        public Repository<Product> ProductRepository
        {
            get
            {
                if (ProductRepository == null)
                {
                    ProductRepository = new Repository<Product>(context);
                }
                return ProductRepository;
            }
            private set { }
        }
        public Repository<Purchase> PurchaseRepository
        {
            get
            {
                if (PurchaseRepository == null)
                {
                    PurchaseRepository = new Repository<Purchase>(context);
                }
                return PurchaseRepository;
            }
            private set { }
        }
        public Repository<PurchaseProduct> PurchaseProductRepository
        {
            get
            {
                if (PurchaseProductRepository == null)
                {
                    PurchaseProductRepository = new Repository<PurchaseProduct>(context);
                }
                return PurchaseProductRepository;
            }
            private set { }
        }
        public Repository<Rate> RateRepository
        {
            get
            {
                if (RateRepository == null)
                {
                    RateRepository = new Repository<Rate>(context);
                }
                return RateRepository;
            }
            private set { }
        }
        public Repository<Comment> CommentRepository
        {
            get
            {
                if (CommentRepository == null)
                {
                    CommentRepository = new Repository<Comment>(context);
                }
                return CommentRepository;
            }
            private set { }
        }
        public Repository<ShoppingCart> ShoppingCartRepository
        {
            get
            {
                if (ShoppingCartRepository == null)
                {
                    ShoppingCartRepository = new Repository<ShoppingCart>(context);
                }
                return ShoppingCartRepository;
            }
            private set { }
        }
        public Repository<UserRole> UserRoleRepository
        {
            get
            {
                if (UserRoleRepository == null)
                {
                    UserRoleRepository = new Repository<UserRole>(context);
                }
                return UserRoleRepository;
            }
            private set { }
        }


        public void Save()
        {
            context.SaveChanges();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
