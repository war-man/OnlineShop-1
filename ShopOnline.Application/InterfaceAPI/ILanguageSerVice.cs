using ShopOnline.Model.LanguageModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Application.InterfaceAPI
{
    public interface ILanguageSerVice
    {
        Task<List<LanguageViewModel>> GetAll();
    }
}
