using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using ShopOnline.Application.Page;
using ShopOnline.Data;
using ShopOnline.Model.MessageModel;
using ShopOnline.Model.PageModel;
using ShopOnline.Web.ConnectAPI.InterfaceConnectAPI;
using ShopOnline.Web.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PageController : Controller
    {
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly ApplicationDbContext _context;
        private readonly IPageConnectAPI _pageConnectAPI;
        public PageController(IPageConnectAPI pageConnectAPI,ApplicationDbContext context, IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
            _context = context;
            _pageConnectAPI = pageConnectAPI;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("Admin/ViewPage/{Alias}")]
        public IActionResult ViewPage(string Alias)
        {
            var page = _context.Pages.Where(x => x.Alias == Alias).Take(1);
            return View(page);
        }
        public async Task<IActionResult> UpdatePage(UpdatePage request)
        {
            var page = await _pageConnectAPI.UpdatePage(request);
            return Json(new
            {
                status = true
            });
        }
        public async Task<IActionResult> GetAllPaging(PageRequest request)
        {
            var listpage = await _pageConnectAPI.GetAllPagePaging(request);
            return new OkObjectResult(listpage);
        }
        public async Task<IActionResult> DeletePage(int Id)
        {
            var page = await _pageConnectAPI.DeletePage(Id);
            return Json(new
            {
                status = true
            });
        }
        public async Task<IActionResult> CreatPage(CreatPage request)
        {
            var page = await _pageConnectAPI.CreatPage(request);
            if (page == true)
            {
                var annount = new AnnouncementViewModel()
                {
                    UserName = User.Identity.Name,
                    DeCripstion = "User Create " + request.Alias,
                    Content = "Creat Role",
                    DateCreated = DateTime.Now,
                };
                await _hubContext.Clients.All.SendAsync("ReceiveMessage", annount);
            }
            return Json(new
            {
                status = true
            });
        }
        public async Task<IActionResult> FindPageById(int Id)
        {
            var page = await _pageConnectAPI.FindPageById(Id);
            return Json(new
            {
                status = true,
                data = page
            });
        }
    }
}
