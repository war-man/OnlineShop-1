using ShopOnline.Model.ImageUserModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Application.InterfaceAPI
{
    public interface IImageUserSerVice
    {
        Task<List<ImageUserViewModel>> GetAllImageUser();
        Task<int> CreateImageUser(string[] images, string UserName);
        Task<int> DeleteImageUser(int Id);
        Task<List<ImageUserViewModel>> GetListProductImageByUserName(string UserName);
    }    
    
}
