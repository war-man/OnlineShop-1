using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopOnline.Web.ConnectAPI.InterfaceConnectAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Web.Areas.Admin.ViewComponents
{
    public class LanguageViewComponent:ViewComponent
    {
        private readonly ILanguageConnectAPI _languageConnectAPI;
        public LanguageViewComponent(ILanguageConnectAPI languageConnectAPI)
        {
            _languageConnectAPI = languageConnectAPI;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var list = await _languageConnectAPI.GetAll();
            ViewBag.ListLanguage = list.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            return View(list);
        }
    }
}
