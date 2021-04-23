using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopOnline.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Configuration
{
    public class ChatConfiguration : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            builder.ToTable("Chats");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserName);
            builder.Property(x => x.Content);
            builder.Property(x => x.DateCreated);
            builder.Property(x => x.RoomId);
        }
    }
}
