using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Application.Page;
using ShopOnline.Data;
using ShopOnline.Model.ProductModel;
using ShopOnline.Web.ConnectAPI.InterfaceConnectAPI;
using ShopOnline.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IReViewProductConnectAPI _reViewProductConnectAPI;
        private readonly IProductImageConnectAPI _productImageConnectAPI;
        private readonly IProductConnectAPI _productConnectAPI;
        public ProductController(IProductConnectAPI productConnectAPI, IProductImageConnectAPI productImageConnectAPI, IReViewProductConnectAPI reViewProductConnectAPI, ApplicationDbContext context)
        {
            _context = context;
            _reViewProductConnectAPI = reViewProductConnectAPI;
            _productImageConnectAPI = productImageConnectAPI;
            _productConnectAPI = productConnectAPI;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("/Product/ProductDetail/{Id}")]
        public async Task<IActionResult> ProductDetail(int Id)
        {
            var listcolor = await _productConnectAPI.GetAllColor();
            ViewBag.ListColor = listcolor.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            var listsize = await _productConnectAPI.GetAllSize();
            ViewBag.ListSize = listsize.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            ViewBag.ListReView = await _reViewProductConnectAPI.GetReViewOfProductById(Id);
            var user = User.Identity.Name;
            ViewBag.CheckUser = user;
            var product  = await _productConnectAPI.ProductDetail(Id);
            var listImage = await _productImageConnectAPI.GetListProductImageByProductId(Id);
            ViewBag.ListImage = listImage;
            ViewBag.ListBestSeo = await _productConnectAPI.ProductSeo(3); // Related products 
            return View(product);
        }
        [Route("Product/QuickViewDetail/{Id}")]
        public async Task<IActionResult> QuickViewDetail(int Id)
        {
            var product = await _productConnectAPI.ProductDetail(Id);
            return View(product);
        }
        public async Task<IActionResult> GetAllProductWeb(string keyword ,int pageSize, int pageIndex=1)
        {
            if(pageSize==0)
            {
                pageSize = 3;
            }    
            var request = new PageRequest()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Keyword = keyword,
            };
            var productList = new ProductListViewModel();
           
            var listproduct = await _productConnectAPI.GetAllProductPaging(request);
            productList.ListProduct = listproduct;
            return View(productList); 
        }
        [Route("Product/Search")]
        public async Task<IActionResult> Search(string keyword,int pageIndex=1,int pageSize=5)
        {
            var productList = new ProductListViewModel();
            var request = new PageRequest()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Keyword = keyword
            };
            productList.Keyword = keyword;
            productList.PageSize = pageSize;
            productList.ListProduct = await _productConnectAPI.GetAllProductPaging(request);
            return View(productList);
        }
        public async Task<IActionResult> FindProductPart2(RequestBase request)
        {
            var listproduct = await _productConnectAPI.GetAllProductPagingPart2(request);
            var listproductViewModelPart2 = new ProductListViewModelPart2();
            listproductViewModelPart2.ListProduct = listproduct;
            listproductViewModelPart2.PageSize = request.PageSize;
            listproductViewModelPart2.ColorId = request.ColorId;
            listproductViewModelPart2.SizeId = request.SizeId;
            listproductViewModelPart2.FromPrice = request.FromPrice;
            listproductViewModelPart2.ToPrice = request.ToPrice;
            return View(listproductViewModelPart2);
        }

    }
}
