using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;
using OnlineStore.Data.Configurations;
using OnlineStore.Models.Database;


namespace OnlineStore.Data
{
    public class OnlineStoreDbContext : DbContext
    {
        public OnlineStoreDbContext(DbContextOptions<OnlineStoreDbContext> options)
                    : base(options)
        {
        }
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
