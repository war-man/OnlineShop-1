using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ShopOnline.Data;
using ShopOnline.Data.Entity;
using ShopOnline.Model.ChatModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Web.Controllers
{
    public class ChatController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ChatController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> GetAllChat(int Id)
        {
            var getall = HttpContext.Session.GetString("ConfirmRequet");
            if (getall == null)
            {
                Id = 0;
            }
            else
            {
                var IdRq = JsonConvert.DeserializeObject<int>(getall);
                Id = IdRq;
            }
            var listchat = await _context.Chats.Where(x => x.RoomId == Id).ToListAsync();
            var list = listchat.OrderBy(x => x.DateCreated);
            return Json(new
            {
                status = true,
                data = list
            });
        }
        public IActionResult StartRoom()
        {
            return View();
        }
        public async Task<IActionResult> DeleteChat(int Id)
        {
            var chat = _context.Chats.Remove(await _context.Chats.FindAsync(Id));
            await _context.SaveChangesAsync();
            return Json(new
            {
                status = true
            });
        }
        public async Task<IActionResult> CreateRoom(int roomId)
        {
            var room = new Room()
            {
                RoomId = roomId
            };
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
            return Json(new
            {
                status = true
            });
        }
        public async Task<IActionResult> CreateChat(CreateChat request)
        {
            var chat = new Chat()
            {
                UserName = request.UserName,
                Content = request.Content,
                DateCreated = DateTime.Now
            };
            _context.Chats.Add(chat);
            await _context.SaveChangesAsync();
            return Json(new
            {
                status = true
            });
        }
        [Route("Chat/ConfirmRoom/{Id}")]
        public IActionResult Index(int Id)
        {
            var listRoom = _context.Rooms.Where(x => x.RoomId == Id).ToList();
            if (listRoom == null)
            {
                return RedirectToAction("NotFindRoomWithId", "Chat");
            }
            var room = new Room()
            {
                RoomId = Id
            };
            return View(room);
        }
        public IActionResult NotFindRoomWithId()
        {
            return View();
        }
    }
}
