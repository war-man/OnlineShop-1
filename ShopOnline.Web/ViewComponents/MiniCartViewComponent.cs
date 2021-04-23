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
    public class MiniCartViewComponent:ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public MiniCartViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(int Id)
        {
            var product = await _context.Products.FindAsync(Id);
            var list = new List<CartItem>();
            var getall = HttpContext.Session.GetString("CartRequest");
            if(getall!=null)
            {
                var listcart = JsonConvert.DeserializeObject<List<CartItem>>(getall);
                list = listcart;
            }
            else
            {
                list = null;
            }
            return View(list);
        }
    }
}
