using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Application.Page;
using ShopOnline.Data;
using ShopOnline.Data.Entity;
using ShopOnline.Model.MessageModel;
using ShopOnline.Model.PermissionModel;
using ShopOnline.Model.RoleModel;
using ShopOnline.Web.ConnectAPI.InterfaceConnectAPI;
using ShopOnline.Web.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly IPermissionConnectAPI _permissionConnectAPI;
        private readonly IRoleConnectAPI _roleConnectAPI;
        public RoleController(IRoleConnectAPI roleConnectAPI, IPermissionConnectAPI permissionConnectAPI, IHubContext<ChatHub> hubContext, IMapper mapper, ApplicationDbContext context)
        {
            _context = context;
            _mapper = mapper;
            _permissionConnectAPI = permissionConnectAPI;
            _roleConnectAPI = roleConnectAPI;
            _hubContext = hubContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetAllRolePaging(string keyword,int pageIndex,int pageSize)
        {
            var request = new PageRequest()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Keyword = keyword
            };
            var listrole = await _roleConnectAPI.GetAllRolePaging(request);
            return new OkObjectResult(listrole);

        }
        public async Task<IActionResult> DeleteRoleById(string Id)
        {
            var role = await _roleConnectAPI.DeleteRole(Id);
            return Json(new
            {
                status = true
            });
        }
        public async Task<IActionResult> GetAllRole()
        {
            var listrole = await _roleConnectAPI.GetAllRole();
            return Json(new
            {
                status = true,
                data = listrole
            });
        }
        public async Task<IActionResult> GetPermissionFromRole(string RoleName)
        {
            var listpermission = await _permissionConnectAPI.GetListPermissionFromRole(RoleName);
            return Json(new
            {
                status = true,
                data = listpermission
            });
        }
        public async Task<IActionResult> UpdatPermission(List<UpdatePerMission> Value, string roleName)
        {
            var request = new CreatPermissionViewModel()
            {
                ListCreat = Value,
                RoleName = roleName,
            };
            var creat = await _permissionConnectAPI.CreatPermission(request);
            return Json(new
            {
                status = true,

            });
        }
        public async Task<IActionResult> CreatRole(UpdateRole request)
        {
            var creat = await _roleConnectAPI.CreatRole(request);
            var annount = new AnnouncementViewModel()
            {
                UserName = User.Identity.Name,
                Content = "Creat Role",
                DateCreated=DateTime.Now,
                DeCripstion="Successfull"
            };
            var ann = _mapper.Map<AnnouncementViewModel, Announcement>(annount);
            _context.Announcements.Add(ann);
            await  _context.SaveChangesAsync();
            await _hubContext.Clients.All.SendAsync("ReceiveMessage",annount);
            return Json(new
            {
                status = true,
            });
        }
    }
}
