using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Application.InterfaceAPI;
using ShopOnline.Data;
using ShopOnline.Data.Entity;
using ShopOnline.ImplementationAPI.BaseImplementationAPI;
using ShopOnline.Model.ImageUserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.ImplementationAPI
{
    public class ImageUserSerVice : BaseImplement<ImageUser>, IImageUserSerVice
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public ImageUserSerVice(ApplicationDbContext context, IMapper mapper):base(context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<int> CreateImageUser(string[] images, string UserName)
        {
            var listimage = _context.ImageUsers.Where(x => x.UserName == UserName).ToList();
            foreach(var img in listimage)
            {
                _context.ImageUsers.Remove(img);
            }    
            foreach(var image in images)
            {
                var imageUser = new ImageUser()
                {
                    UserName = UserName,
                    Decripstion = "",
                    PathImage = image
                };
                _context.ImageUsers.Add(imageUser);
            }
            return await _context.SaveChangesAsync();
        }
        public async Task<int> DeleteImageUser(int Id)
        {
            return await Delete(Id);
        }
        public async Task<List<ImageUserViewModel>> GetAllImageUser()
        {
            var listimageUser = await GetAll();
            var listimageUserViewModel = _mapper.Map<List<ImageUser>, List<ImageUserViewModel>>(listimageUser);
            return listimageUserViewModel;
        }
        public async Task<List<ImageUserViewModel>> GetListProductImageByUserName(string UserName)
        {
            var listimage = await _context.ImageUsers.Where(x => x.UserName == UserName).ToListAsync();
            var listimageViewModel = _mapper.Map<List<ImageUser>, List<ImageUserViewModel>>(listimage);
            return listimageViewModel;
        }
    }
}
