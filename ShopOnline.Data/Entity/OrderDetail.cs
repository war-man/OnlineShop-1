using ShopOnline.Data.EntityComponent;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Data.Entity
{
    public class OrderDetail : Common
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal ProductLastPrice { get; set; }
        public string ColorName { get; set; }
        public string SizeName { get; set; }
        public int ProductQuantity { get; set; }
        public int ProductId { get; set; }
        public int ColorId { get; set; }
        public int SizeId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
