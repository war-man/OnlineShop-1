using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopOnline.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Configuration
{
    public class ImageUserConfiguration : IEntityTypeConfiguration<ImageUser>
    {
        public void Configure(EntityTypeBuilder<ImageUser> builder)
        {
            builder.ToTable("ImageUsers");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserName);
            builder.Property(x => x.PathImage);
            builder.Property(x => x.Decripstion);
        }
    }
}
