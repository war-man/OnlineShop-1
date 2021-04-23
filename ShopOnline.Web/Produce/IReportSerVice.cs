using ShopOnline.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Web.Produce
{
    public interface IReportSerVice
    {
        Task<IEnumerable<RevenueReportViewModel>> GetReportAsync(string fromDate, string toDate);
        Task<IEnumerable<Product>> GetAllProduct();
        Task<IEnumerable<RevenueReportViewModel>>GetTest(string fromDate, string toDate);
    }
}
