using ShopOnline.Application.Page;
using ShopOnline.Model.PageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Web.ConnectAPI.InterfaceConnectAPI
{
    public interface IPageConnectAPI
    {
        Task<PagedResult<PageViewModel>> GetAllPagePaging(PageRequest request);
        Task<bool> CreatPage(CreatPage request);
        Task<bool> DeletePage(int Id);
        Task<bool> UpdatePage(UpdatePage request);
        Task<PageViewModel> FindPageById(int Id);
    }
}
