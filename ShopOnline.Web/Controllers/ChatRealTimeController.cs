using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Data;
using ShopOnline.Data.Entity;
using ShopOnline.Model.MessageModel;
using ShopOnline.Web.ConnectAPI.InterfaceConnectAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Web.Controllers
{
    public class ChatRealTimeController : Controller
    {
        private readonly IUserConnectAPI _userConnectAPI;
        private readonly ApplicationDbContext _context;
        
        public ChatRealTimeController(ApplicationDbContext context, IUserConnectAPI userConnectAPI)
        {
            _userConnectAPI = userConnectAPI;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var user = User.Identity.Name;
            var currentUser = await _userConnectAPI.FindUserByName(user);
            ViewBag.CurrentUserName = currentUser.UserName;
            var listmessage = await _context.Messages.ToListAsync();
            return View(listmessage);
        }
        public async Task<IActionResult> Create(CreatMessage request)
        {
            var user = User.Identity.Name;
            var username = await _userConnectAPI.FindUserByName(user);
            var message = new Messages()
            {
                UserID = username.Id,
                UserName = user,
                Text = request.Text,
                When = DateTime.Now
            };
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index","ChatRealTime");
        }
    }
}
