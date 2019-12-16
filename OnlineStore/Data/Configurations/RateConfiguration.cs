using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OnlineStore.Models.Database;

namespace OnlineStore.Data.Configurations
{
    public class RateConfiguration : IEntityTypeConfiguration<Rate>
    {
        public void Configure(EntityTypeBuilder<Rate> builder)
        {
            builder.HasKey(e => new { e.ProductId, e.UserId });
            builder.HasOne(e => e.Product).WithMany(e => e.Rates).HasForeignKey(e => e.ProductId);
            builder.HasOne(e => e.User).WithMany(e => e.Rates).HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
