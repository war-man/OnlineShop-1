using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Web.ViewComponents
{
    public class MegaMenuViewComponent:ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public MegaMenuViewComponent(ApplicationDbContext context)
        {
            _context = context;
            
        }
        public  async Task<IViewComponentResult> InvokeAsync()
        {
            var listmenu = await _context.TopCategories.ToListAsync();
            return View(listmenu);
        }
    }
}
