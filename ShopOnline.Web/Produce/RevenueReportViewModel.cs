using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Web.Produce
{
    public class RevenueReportViewModel
    {
        public DateTime Date { get; set; }
        public decimal Revenue { get; set; }

        public decimal Profit { get; set; }
    }
}
