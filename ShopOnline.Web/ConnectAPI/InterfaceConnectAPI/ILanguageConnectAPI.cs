using ShopOnline.Model.LanguageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Web.ConnectAPI.InterfaceConnectAPI
{
    public interface ILanguageConnectAPI
    {
         Task<List<LanguageViewModel>> GetAll();
    }
}
