using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Application.Page
{
    public class RequestBase
    {
        public string Keyword { get; set; }
        public decimal FromPrice { get; set; }
        public decimal ToPrice { get; set; }
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 5;
        public int ColorId { get; set; }
        public int SizeId { get; set; }
    }
}
