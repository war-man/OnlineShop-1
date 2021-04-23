using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Data.Entity
{
   public class Messages
    {
        public int Id { get; set; }
        
        public string UserName { get; set; }
        
        public string Text { get; set; }
        public DateTime When { get; set; }

        public string UserID { get; set; }
   
    }
}
