using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using ShopOnline.Data;
using ShopOnline.Model.Enum;
using ShopOnline.Model.ProductModel;
using ShopOnline.Web.ConnectAPI.InterfaceConnectAPI;
using ShopOnline.Web.Produce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Web.Controllers
{
    public class TestController : Controller
    {
        private IMemoryCache _cache;
        private readonly ApplicationDbContext _context;
        private readonly IReportSerVice _reportSerVice;
        private readonly IProductConnectAPI _productConnectAPI;
        public TestController(ApplicationDbContext context, IMemoryCache cache, IReportSerVice reportSerVice, IProductConnectAPI productConnectAPI)
        {
            _productConnectAPI = productConnectAPI;
            _reportSerVice = reportSerVice;
            _cache = cache;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAllProduct()
        {
            var cacheEntry = _cache.GetOrCreate(CacheKeys.Entry, entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromSeconds(3);
                return _context.Products.ToList();
            });
            return View(_context.Products.ToList());
        }
        // Test Connect Proc GetAllProduct in asp.net core MVC
        public async Task<IActionResult> GetAll()
        {
            var listproduct = await _reportSerVice.GetAllProduct();
            return View(listproduct);
        }
        [HttpGet]
        public IActionResult Creat()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Creat(CreatProduct request)
        {
            var create = await _productConnectAPI.CreatProduct(request);
            return RedirectToAction("Index", "Home");
        }
       
    }
}
