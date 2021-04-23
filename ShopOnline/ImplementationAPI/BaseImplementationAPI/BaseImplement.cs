using Microsoft.EntityFrameworkCore;
using ShopOnline.Application.Page;
using ShopOnline.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.ImplementationAPI.BaseImplementationAPI
{
    public class BaseImplement<T> where T:class
    {
        private readonly ApplicationDbContext _context;
        public BaseImplement(ApplicationDbContext context)
        {
            _context = context;
        }
        private readonly DbSet<T> table = null;
        public async Task<List<T>> GetAll()
        {
            var list = await table.ToListAsync();
            return list;
        }
        public async Task<int> Delete(int Id)
        {
            var find = await table.FindAsync(Id);
            table.Remove(find);
            return await _context.SaveChangesAsync();
        }
        public async Task<T> FindById(int Id)
        {
            var find = await table.FindAsync(Id);
            return find;
        }
    }
}
