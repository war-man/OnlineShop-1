﻿using ShopOnline.Application.Page;
using ShopOnline.Model.PageModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Application.InterfaceAPI
{
    public interface IPageSerVice
    {
        Task<PagedResult<PageViewModel>> GetAllPagePaging(PageRequest request);
        Task<int> CreatPage(CreatPage request);
        Task<int> DeletePage(int Id);
        Task<int> UpdatePage(UpdatePage request);
        Task<PageViewModel> FindPageById(int Id);
    }
}
