using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Model.CartModel
{
    public class UpdateCart
    {
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public int ColorId { get; set; }
        public int LastColorId { get; set; }
        public int LastSizeId { get; set; }
    }
}
