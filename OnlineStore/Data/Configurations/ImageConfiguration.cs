using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OnlineStore.Models.Database;

namespace OnlineStore.Data.Configurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasMany(e => e.Products).WithOne(e => e.Image).HasForeignKey(x => x.ImageId);
        }
    }
}
