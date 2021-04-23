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
    public class TotalPriceProductViewComponent: ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public TotalPriceProductViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(int Id)
        {
            var product = await _context.Products.FindAsync(Id);
            var total = new TotalPriceCart();
            var getall = HttpContext.Session.GetString("CartRequest");
            if (getall == null)
            {
                total.TotalPrice = 0;
            }
            else
            {
                var listcart = JsonConvert.DeserializeObject<List<CartItem>>(getall);
                
                foreach (var cart in listcart)
                {
                    total.TotalPrice += (cart.ProductViewModel.LastPrice)*(cart.Quantity);
                }
            }
            return View(total);
        }
    }
}
