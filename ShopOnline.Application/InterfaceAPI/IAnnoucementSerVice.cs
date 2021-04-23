
using ShopOnline.Model.MessageModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Application.InterfaceAPI
{
    public interface IAnnoucementSerVice
    {
        Task<int> DeleteAnn(int Id);
        Task<int> DeleteAllAnn();
        Task<List<AnnouncementViewModel>> GetAllAnnoucement();
    }
    
}
