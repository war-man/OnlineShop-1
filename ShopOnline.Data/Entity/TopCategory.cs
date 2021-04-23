using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Data.Entity
{
    public class TopCategory
    {
        public string Id { get; set; }
        public string Decripstion { get; set; }
        public string Name { get; set; }
        public string ParentId { get; set; }
        public string URL { get; set; }

    }
}
