using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ShopOnline.Data.Entity;
using ShopOnline.Model.FunctionModel;
using ShopOnline.Model.ImageUserModel;
using ShopOnline.Model.LanguageModel;
using ShopOnline.Model.MessageModel;
using ShopOnline.Model.PageModel;
using ShopOnline.Model.PermissionModel;
using ShopOnline.Model.ProductCategoryModel;
using ShopOnline.Model.ProductImageModel;
using ShopOnline.Model.ProductModel;
using ShopOnline.Model.ReViewProductModel;
using ShopOnline.Model.RoleModel;
using ShopOnline.Model.SlideModel;
using ShopOnline.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.AutoMapper
{
    public class AutoMapping: Profile
    {
        public AutoMapping()
        {
            CreateMap<IdentityUser, UserViewModel>().ReverseMap();
           

            CreateMap<IdentityRole, RoleViewModel>().ReverseMap();
           

            CreateMap<Product, ProductViewModel>().ReverseMap();
            

            CreateMap<Function, FunctionViewModel>().ReverseMap();
            

            CreateMap<Permission, PermissionViewModel>().ReverseMap();
           

            CreateMap<ProductCategory, ProductCategoryViewModel>().ReverseMap();
            

            CreateMap<ProductColor, ProductColorViewModel>().ReverseMap();
         

            CreateMap<ProductImage, ProductImageViewModel>().ReverseMap();
            

            CreateMap<ProductSize, ProductSizeViewModel>().ReverseMap();
           

            CreateMap<ProductQuantity, ProductQuantityViewModel>().ReverseMap();
           

            CreateMap<WholePrice, WholePriceViewModel>().ReverseMap();
           


            CreateMap<Permission, PermissionViewModel>().ReverseMap();
          

            CreateMap<Slide, SlideViewModel>().ReverseMap();
           

            CreateMap<ReviewProduct, ReViewProductViewModel>().ReverseMap();
            


            CreateMap<Announcement, AnnouncementViewModel>().ReverseMap();
            

            CreateMap<Page, PageViewModel>().ReverseMap();
           

            CreateMap<ImageUser, ImageUserViewModel>().ReverseMap();
            

            CreateMap<Language, LanguageViewModel>().ReverseMap();
            
        }
    }
}
