using Microsoft.AspNetCore.Mvc;
using ShopOnline.Model.ImageUserModel;
using ShopOnline.Web.ConnectAPI.InterfaceConnectAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Web.Areas.Admin.Controllers
{
    public class ImageUserController : Controller
    {
        private readonly IImageUserConnectAPI _imageUserConnectAPI;
        public ImageUserController(IImageUserConnectAPI imageUserConnectAPI)
        {
            _imageUserConnectAPI = imageUserConnectAPI;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> CreateImageUser(CreateImageUser request)
        {
            var create = await _imageUserConnectAPI.CreateImageUser(request);
            return Json(new
            {
                status = true
            });
        }
        public async Task<IActionResult> GetAllImageUser()
        {
            var getall = await _imageUserConnectAPI.GetAll();
            return Json(new
            {
                status = true,
                data = getall
            });
        }
        public async Task<IActionResult> DeleteImageUser(int Id)
        {
            var delete = await _imageUserConnectAPI.DeleteImageUser(Id);
            return Json(new
            {
                status = true
            });
        }
        public async Task<IActionResult> GetListProductImageByUserName(string UserName)
        {
            var list = await _imageUserConnectAPI.GetListProductImageByUserName(UserName);
            return Json(new
            {
                status = true,
                data = list
            });
        }
    }
}
