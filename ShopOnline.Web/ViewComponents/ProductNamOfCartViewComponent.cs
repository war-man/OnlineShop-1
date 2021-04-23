using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ShopOnline.Data;
using ShopOnline.Model.CartModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Web.ViewComponents
{
    public class ProductNamOfCartViewComponent:ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public ProductNamOfCartViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var list = new List<CartItem>();
            var product = await _context.Products.ToListAsync();

            var getall = HttpContext.Session.GetString("CartRequest");
            if (getall == null)
            {
                list = null;
            }
            else
            {
                var listproduct = JsonConvert.DeserializeObject<List<CartItem>>(getall);
                list = listproduct;
            }

            return View(list);
        }    
    }
}
