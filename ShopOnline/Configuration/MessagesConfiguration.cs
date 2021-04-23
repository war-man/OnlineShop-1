using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopOnline.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Configuration
{
    public class MessagesConfiguration : IEntityTypeConfiguration<Messages>
    {
        public void Configure(EntityTypeBuilder<Messages> builder)
        {
            builder.ToTable("Messages");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserName);
            builder.Property(x => x.UserID);
            builder.Property(x => x.When);
            builder.Property(x => x.Text);
        }
    }
}
