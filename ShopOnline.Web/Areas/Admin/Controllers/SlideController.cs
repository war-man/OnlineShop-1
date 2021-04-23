using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using ShopOnline.Model.MessageModel;
using ShopOnline.Model.SlideModel;
using ShopOnline.Web.ConnectAPI.InterfaceConnectAPI;
using ShopOnline.Web.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SlideController : Controller
    {
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly ISlideConnectAPI _slideConnectAPI;
        public SlideController(ISlideConnectAPI slideConnectAPI, IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
            _slideConnectAPI = slideConnectAPI;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetAllSlide()
        {
            var list = await _slideConnectAPI.GetAllSlide();
            return Json(new
            {
                status = true,
                data = list
            });
        }
        public async Task<IActionResult> CreatSlide(CreatSlide request)
        {
            var creat = await _slideConnectAPI.CreatSlide(request);
            if (creat == true)
            {
                var annount = new AnnouncementViewModel()
                {
                    UserName = User.Identity.Name,
                    DeCripstion = "slide create successfull " + request.Name,
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
    }
}
