using ShopOnline.Application.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Data.Compon
{
    public class BasePaging<T> where T:class
    {
        private readonly ApplicationDbContext _context;
        
        public BasePaging(ApplicationDbContext context)
        {
            _context = context;
        }
        public PagedResult<T> GetAllPaging(List<T> entity,PageRequest request)
        {
            var total = entity.Count();
            var vt = entity.Skip((request.PageIndex - 1) * (request.PageSize)).Take(request.PageSize).ToList();
            var page = new PagedResult<T>()
            {
                Items = vt,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                TotalRecords = total
            };
            return page;
        }
        
    }
}
