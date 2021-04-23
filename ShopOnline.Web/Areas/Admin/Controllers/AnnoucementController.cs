using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopOnline.Data;
using ShopOnline.Application.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopOnline.Data.Entity;
using ShopOnline.Web.ConnectAPI.InterfaceConnectAPI;

namespace ShopOnline.Web.Areas.Admin.Controllers
{
    public class AnnoucementController : Controller
    {
        private readonly IAnnoucementConnectAPI _annoucementConnectAPI;
        private readonly ApplicationDbContext _context;
        public AnnoucementController(ApplicationDbContext context, IAnnoucementConnectAPI annoucementConnectAPI)
        {
            _annoucementConnectAPI = annoucementConnectAPI;
            _context = context;
        }    
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAllAnn()
        {
            var list = _context.Announcements.ToList();
            return new OkObjectResult(list);
        } 
        public async Task<IActionResult> DeleteAllAnn()
        {
            var deleteAll = await _annoucementConnectAPI.DeleteAllAnn();
            return Json(new
            {
                status = true
            });
        }
        public async Task<IActionResult> DeleteAnn(int Id)
        {
            var delete =await _annoucementConnectAPI.DeleteAnnnoucement(Id);
            if(delete==true)
            {
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false
                });
            }
        }
      
    }
}
