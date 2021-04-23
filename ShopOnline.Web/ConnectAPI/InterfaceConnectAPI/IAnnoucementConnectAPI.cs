using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Web.ConnectAPI.InterfaceConnectAPI
{
    public interface IAnnoucementConnectAPI
    {
         Task<bool> DeleteAnnnoucement(int Id);
         Task<bool> DeleteAllAnn();
    }
}
