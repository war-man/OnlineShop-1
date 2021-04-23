using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Model.ChatModel
{
    public class ChatViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime DateCreated { get; set; }
        public string Content { get; set; }
    }
}
