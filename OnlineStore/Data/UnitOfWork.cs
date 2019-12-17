using System;

using OnlineStore.Data.Interfaces;
using OnlineStore.Models.Database;

namespace OnlineStore.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private OnlineStoreDbContext context;
        private bool disposed;
        public UnitOfWork()
        {
            context = OnlineStoreDbContextFactory.Create();
            disposed = false;
        }

        private Repository<Rate> rateRepository;
        private Repository<User> userRepository; 
        private Repository<Product> productRepository; 
        private Repository<Category> categoryRepository;
        private Repository<Comment> commentRepository;
        private Repository<Purchase> purchaseRepository;
        private Repository<PurchaseProduct> purchaseProductRepository;
        private Repository<ShoppingCart> shoppingCartRepository;
        private Repository<UserRole> userRoleRepository;
        private Repository<Image> imageRepository;
        public Repository<User> UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new Repository<User>(context);
                }
                return userRepository;
            }
        }
        public Repository<Product> ProductRepository
        {
            get
            {
                if (productRepository == null)
                {
                    productRepository = new Repository<Product>(context);
                }
                return productRepository;
            }
        }
        public Repository<Rate> RateRepository
        {
            get
            {
                if (rateRepository == null)
                {
                    rateRepository = new Repository<Rate>(context);
                }
                return rateRepository;
            }
        }
        public Repository<Category> CategoryRepository
        {
            get
            {
                if (categoryRepository == null)
                {
                    categoryRepository = new Repository<Category>(context);
                }
                return categoryRepository;
            }
        }
        public Repository<Comment> CommentRepository
        {
            get
            {
                if (commentRepository == null)
                {
                    commentRepository = new Repository<Comment>(context);
                }
                return commentRepository;
            }
        }
        public Repository<Purchase> PurchaseRepository
        {
            get
            {
                if (purchaseRepository == null)
                {
                    purchaseRepository = new Repository<Purchase>(context);
                }
                return purchaseRepository;
            }
        }
        public Repository<PurchaseProduct> PurchaseProductRepository
        {
            get
            {
                if (purchaseProductRepository == null)
                {
                    purchaseProductRepository = new Repository<PurchaseProduct>(context);
                }
                return purchaseProductRepository;
            }
        }
        public Repository<ShoppingCart> ShoppingCartRepository
        {
            get
            {
                if (shoppingCartRepository == null)
                {
                    shoppingCartRepository = new Repository<ShoppingCart>(context);
                }
                return shoppingCartRepository;
            }
        }
        public Repository<UserRole> UserRoleRepository
        {
            get
            {
                if (userRoleRepository == null)
                {
                    userRoleRepository = new Repository<UserRole>(context);
                }
                return userRoleRepository;
            }
        }
        public Repository<Image> ImageRepository
        {
            get
            {
                if (imageRepository == null)
                {
                    imageRepository = new Repository<Image>(context);
                }
                return imageRepository;
            }
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
