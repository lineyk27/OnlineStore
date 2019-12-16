using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

using OnlineStore.Models.Database;


namespace OnlineStore.Data.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(e => new {e.ProductId, e.UserId});
            builder.Property(e => e.Text).HasColumnType("ntext");
            builder.HasOne(e => e.User).WithMany(e => e.Comments).HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(e => e.Product).WithMany(e => e.Comments).HasForeignKey(e => e.ProductId);

        }
    }
}
