using Microsoft.AspNetCore.Mvc;
using ShopOnline.Data;
using ShopOnline.Model.ChartModel;
using ShopOnline.Web.Produce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        private readonly IReportSerVice _reportSerVice;
        private readonly ApplicationDbContext _context;
        public ChartController(ApplicationDbContext context, IReportSerVice reportSerVice)
        {
            _reportSerVice = reportSerVice;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> StoreChart()
        {
            var chart = await _reportSerVice.GetTest(null, null);
            return Json(new
            {
                status = true,
                data = chart
            });
        }
        public async Task<IActionResult> GetAllChart()
        {
            var list = await _reportSerVice.GetTest(null,null);
            return Json(new
            {
                status = true,
                data =list
            });
        }
    }
}
