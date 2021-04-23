using Microsoft.AspNetCore.Mvc.Rendering;
using ShopOnline.Application.Page;
using ShopOnline.Model.ProductModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Web.Models
{
    public class ProductListViewModelPart2
    {
        public PagedResult<ProductViewModel> ListProduct { get; set; }
        public List<SelectListItem> ListColor { get; } = new List<SelectListItem>
        {
            new SelectListItem(){Value = "1",Text = "Black"},
            new SelectListItem(){Value = "2",Text = "Blue"},
            new SelectListItem(){Value = "3",Text = "Green"},
        };
        public List<SelectListItem> ListSize { get; } = new List<SelectListItem>
        {
            new SelectListItem(){Value = "1",Text = "XL"},
            new SelectListItem(){Value = "2",Text = "X"},
            new SelectListItem(){Value = "3",Text = "S"},
        };
        public List<SelectListItem> ListPage { get; } = new List<SelectListItem>
        {
            new SelectListItem(){Value = "5",Text = "5"},
            new SelectListItem(){Value = "10",Text = "10"},
            new SelectListItem(){Value = "15",Text = "15"},
        };
        public List<SelectListItem> ListSort { get; } = new List<SelectListItem>
        {
            new SelectListItem(){Value = "1",Text = "Hàng giảm giá"},
            new SelectListItem(){Value = "2",Text = "Hàng hóa nổi bật"},
            new SelectListItem(){Value = "3",Text = "All"},
        };
        public decimal FromPrice { get; set; }
        public decimal ToPrice { get; set; }
        public int PageSize { get; set; }
        public int ColorId { get; set; }
        public int SizeId { get; set; }
    }
}
