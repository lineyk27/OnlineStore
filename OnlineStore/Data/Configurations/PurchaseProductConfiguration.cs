using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OnlineStore.Models.Database;

namespace OnlineStore.Data.Configurations
{
    public class PurchaseProductConfiguration : IEntityTypeConfiguration<PurchaseProduct>
    {
        public void Configure(EntityTypeBuilder<PurchaseProduct> builder)
        {
            builder.HasKey(e => new { e.PurchaseId, e.ProductId});

            builder.HasOne(e => e.Product).WithMany(e => e.PurchaseProducts).HasForeignKey(e => e.ProductId);
            builder.HasOne(e => e.Purchase).WithMany(e => e.PurchaseProducts).HasForeignKey(e => e.PurchaseId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
