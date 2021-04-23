using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Model.CartModel
{
    public class RemoveCart
    {
        public int ProductId { get; set; }
        public int ColorId { get; set; }
        public int SizeId { get; set; }
    }
}
