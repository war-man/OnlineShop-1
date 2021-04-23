using Microsoft.EntityFrameworkCore;
using ShopOnline.Application.InterfaceAPI;
using ShopOnline.Data;
using ShopOnline.Model.MessageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.ImplementationAPI
{
    public class AnnoucementSerVice : IAnnoucementSerVice
    {
        private readonly ApplicationDbContext _context;
        public AnnoucementSerVice(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> DeleteAllAnn()
        {
            var listann =await _context.Announcements.ToListAsync();
            foreach(var ann in listann)
            {
                _context.Announcements.Remove(ann);
            }
            return await  _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAnn(int Id)
        {
            var ann  = await _context.Announcements.FindAsync(Id);
            _context.Announcements.Remove(ann);
           return await _context.SaveChangesAsync();
        }

        public Task<List<AnnouncementViewModel>> GetAllAnnoucement()
        {
            throw new NotImplementedException();
        }
    }
}
