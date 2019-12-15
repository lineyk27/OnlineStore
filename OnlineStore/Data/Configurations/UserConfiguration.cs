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
            
            builder.Property(e => e.Email).HasMaxLength(128);
            builder.Property(e => e.Email).IsUnicode(true);

            builder.Property(e => e.PasswordHash).HasMaxLength(64);
            
            builder.Property(e => e.Adress).IsUnicode(true);
            builder.Property(e => e.Adress).HasMaxLength(256);

            builder.Property(e => e.AuthValue).HasMaxLength(64);

            builder.Property(e => e.CreationTime).HasDefaultValue(DateTime.Now);
        }
    }
}
