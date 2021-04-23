using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Data.Entity
{
    public class Chat
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime DateCreated { get; set; }
        public int RoomId { get; set; }
        public string Content { get; set; }
    }
}
