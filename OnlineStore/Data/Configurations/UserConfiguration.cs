using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OnlineStore.Models.Database;

namespace OnlineStore.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.Name).HasMaxLength(32);
            builder.Property(e => e.Surname).HasMaxLength(32);

            builder.Property(e => e.Email).HasMaxLength(128);
            builder.Property(e => e.Email).IsUnicode(true);

            builder.Property(e => e.PasswordHash).HasMaxLength(64);
            
            builder.Property(e => e.Adress).IsUnicode(true);
            builder.Property(e => e.Adress).HasMaxLength(256);

            builder.Property(e => e.AuthValue).HasMaxLength(64);

            builder.HasOne(e => e.Role).WithMany(e => e.Users).HasForeignKey(e => e.RoleId);
            builder.HasMany(e => e.Products).WithOne(e => e.CreatorUser).HasForeignKey(e => e.CreatorUserId);
            builder.HasMany(e => e.ShoppingCart).WithOne(e => e.User).HasForeignKey(e => e.UserId);
            builder.HasMany(e => e.Rates).WithOne(e => e.User).HasForeignKey(e => e.UserId);
            builder.HasMany(e => e.Comments).WithOne(e => e.User).HasForeignKey(e => e.UserId);
            builder.HasMany(e => e.Purchases).WithOne(e => e.User).HasForeignKey(e => e.UserId);
        }
    }
}
