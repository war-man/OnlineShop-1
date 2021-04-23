using Microsoft.AspNetCore.Mvc.Rendering;
using ShopOnline.Application.Page;
using ShopOnline.Model.ProductModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Web.Models
{
    public class ProductListViewModel
    {
        public PagedResult<ProductViewModel> ListProduct { get; set; }
        public string Keyword { get; set; }
        public int PageSize { get; set; }
        public List<SelectListItem> SortBy { get; } = new List<SelectListItem>
        {
            new SelectListItem(){Value = "lastest",Text = "Lastest"},
            new SelectListItem(){Value = "price",Text = "Price"},
            new SelectListItem(){Value = "name",Text = "Name"},
        };
        public List<SelectListItem> Page { get; } = new List<SelectListItem>
        {
            new SelectListItem(){Value = "1",Text = "1"},
            new SelectListItem(){Value = "2",Text = "2"},
            new SelectListItem(){Value = "3",Text = "3"},
        };
    }
}
