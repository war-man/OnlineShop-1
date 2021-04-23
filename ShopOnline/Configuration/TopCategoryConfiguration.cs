using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopOnline.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Configuration
{
    public class TopCategoryConfiguration : IEntityTypeConfiguration<TopCategory>
    {
        public void Configure(EntityTypeBuilder<TopCategory> builder)
        {
            builder.ToTable("TopCategories");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name);
            builder.Property(x => x.Decripstion);
            builder.Property(x => x.ParentId);
            builder.Property(x => x.URL);
        }
    }
}
