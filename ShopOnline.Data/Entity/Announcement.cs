using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Data.Entity
{
    public class Announcement
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public string DeCripstion { get; set; }
    }
}
