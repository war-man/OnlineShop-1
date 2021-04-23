using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopOnline.Data;
using ShopOnline.Model.CartModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Web.ViewComponents
{
    public class TotalProductOfCartViewComponent:ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public TotalProductOfCartViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int Id)
        {
            var product = await _context.Products.FindAsync(Id);
            var getall = HttpContext.Session.GetString("CartRequest");
            var total = new TotalProduct();
            if (getall == null)
            {
                total.Total = 0;
            }
            else
            {
                var listproductofCart = JsonConvert.DeserializeObject<List<CartItem>>(getall);
                total.Total = listproductofCart.Count();
            }
            return View(total);
        }
    }
}
