using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OnlineStore.Models.Database;

namespace OnlineStore.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Producer).HasMaxLength(64);

            builder.Property(e => e.Model).HasMaxLength(64);

            builder.Property(e => e.Price).HasColumnType("decimal(5,2)");

            builder.Property(e => e.Description).IsUnicode(true);
            builder.Property(e => e.Description).HasColumnType("ntext");

            builder.Property(e => e.ImageUrl).HasMaxLength(256);

            builder.Property(e => e.CreationTime).HasDefaultValue(DateTime.Now);

            builder.Property(e => e.CommentsEnabled).HasDefaultValue(true);
        }

    }
}
