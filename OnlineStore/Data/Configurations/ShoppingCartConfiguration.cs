using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OnlineStore.Models.Database;

namespace OnlineStore.Data.Configurations
{
    public class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.HasKey(e => new { e.UserId, e.ProductId });
            builder.HasOne(e => e.User).WithMany(e => e.ShoppingCart).HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(e => e.Product).WithMany(e => e.ShoppingCarts).HasForeignKey(e => e.ProductId);
        }
    }
}
