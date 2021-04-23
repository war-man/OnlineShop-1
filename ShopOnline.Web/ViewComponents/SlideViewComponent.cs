using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Data;
using ShopOnline.Web.ConnectAPI.ImplementationConnectAPI;
using ShopOnline.Web.ConnectAPI.InterfaceConnectAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Web.ViewComponents
{
    public class SlideViewComponent:ViewComponent
    {
       
        private readonly ISlideConnectAPI _slideConnectAPI;
        public SlideViewComponent(ISlideConnectAPI slideConnectAPI)
        {
            _slideConnectAPI = slideConnectAPI;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listSlide = await _slideConnectAPI.GetAllSlide();
            return View(listSlide);
        }
    }
}
