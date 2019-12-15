﻿using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;
using OnlineStore.Data.Configurations;
using OnlineStore.Models.Database;


namespace OnlineStore.Data
{
    public class OnlineStoreDbContext : DbContext
    {
        public OnlineStoreDbContext():base()
        {
        }

        public OnlineStoreDbContext(DbContextOptions<OnlineStoreDbContext> options)
                    : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments{ get; set; }
        public DbSet<Purchase> Purchases{ get; set; }
        public DbSet<PurchaseProduct> PurchaseProducts{ get; set; }
        public DbSet<Rate> Rates{ get; set; }
        public DbSet<ShoppingCart> ShoppingCarts{ get; set; }
        public DbSet<UserRole> UserRoles{ get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
            builder.ApplyConfiguration(new PurchaseConfiguration());
            builder.ApplyConfiguration(new CommentConfiguration());
        }
    }
}
