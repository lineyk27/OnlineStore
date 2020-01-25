using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OnlineStore.Models.Database;

namespace OnlineStore.Data.Configurations
{
    public class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.Adress).HasMaxLength(128);
            builder.Property(e => e.FullPrice).HasColumnType("decimal(8, 2)");

            builder.HasMany(e => e.PurchaseProducts).WithOne(e => e.Purchase).HasForeignKey(e => e.PurchaseId);
            builder.HasOne(e => e.User).WithMany(e => e.Purchases).HasForeignKey(e => e.UserId);
        
        }
    }
}
