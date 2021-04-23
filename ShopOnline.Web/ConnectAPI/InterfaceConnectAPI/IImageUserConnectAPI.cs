using ShopOnline.Model.ImageUserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Web.ConnectAPI.InterfaceConnectAPI
{
    public interface IImageUserConnectAPI
    {
        Task<List<ImageUserViewModel>> GetAll();
        Task<bool> DeleteImageUser(int Id);
        Task<bool> CreateImageUser(CreateImageUser request);
        Task<List<ImageUserViewModel>> GetListProductImageByUserName(string UserName);
    }
}
