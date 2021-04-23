using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Memory;
using ShopOnline.Application.Page;
using ShopOnline.Model.Enum;
using ShopOnline.Model.MessageModel;
using ShopOnline.Model.UserModel;
using ShopOnline.Web.Authorization;
using ShopOnline.Web.ConnectAPI.InterfaceConnectAPI;
using ShopOnline.Web.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private IMemoryCache _cache;
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserConnectAPI _userConnectAPI;
        public UserController(IUserConnectAPI  userConnectAPI, IHostingEnvironment hostingEnvironment, IAuthorizationService authorizationService, IMemoryCache cache, IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
            _cache = cache;
            _authorizationService = authorizationService;
            _hostingEnvironment = hostingEnvironment;
            _userConnectAPI = userConnectAPI;
        }
        public async Task<IActionResult> Index()
        {
            var author =  await _authorizationService.AuthorizeAsync(User, "User", Operations.Read);
            if (author.Succeeded == false)
                return RedirectToAction("Login", "Login", "Admin");
            return View();
        }
        public async Task<IActionResult> GetAllUserPaging(string keyword,int pageIndex,int pageSize)
        {
            var request = new PageRequest()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Keyword = keyword
            };
            var listuser = await _userConnectAPI.GetAllUserPaging(request);
            return new OkObjectResult(listuser);
        }
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var creat = await _userConnectAPI.Register(request);
            var annount = new AnnouncementViewModel()
            {
                UserName = User.Identity.Name,
                DeCripstion = "User Create " + request.UserName,
                Content = "Creat Role",
                DateCreated = DateTime.Now,
            };
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", annount);
            return Json(new
            {
                status = true,
            });
        }
        public async Task<IActionResult> GetListRoleOfUserByUserName(string UserName)
        {
            var user = await _userConnectAPI.FindUserByName(UserName);
            var listrole = await _userConnectAPI.GetListRoleOfUserByUserName(UserName);
            return Json(new
            {
                status = true,
                data = listrole,
                data1=user
            });
        }
        public async Task<IActionResult> DeleteUserByUserName(string UserName)
        {
           
            var username = await _userConnectAPI.DeleteUserByUserName(UserName);
            return Json(new
            {
                status = true
            });
        }
        public async Task<IActionResult> UpdateUser(UpdateUser request)
        {
            var update = await _userConnectAPI.UpdateUser(request);
            return Json(new
            {
                status = true
            });
        }
    }
}
