using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Model.MessageModel
{
    public class AnnouncementViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public string DeCripstion { get; set; }
    }
}
