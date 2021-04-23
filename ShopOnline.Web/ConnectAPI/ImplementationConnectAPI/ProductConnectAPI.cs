using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ShopOnline.Application.Page;
using ShopOnline.Data;
using ShopOnline.Model.ProductModel;
using ShopOnline.Web.ConnectAPI.ConnectComponent;
using ShopOnline.Web.ConnectAPI.InterfaceConnectAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Web.ConnectAPI.ImplementationConnectAPI
{
    public class ProductConnectAPI : BaseConnetAPI<ProductViewModel>,IProductConnectAPI
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApplicationDbContext _context;
        public ProductConnectAPI(IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            ApplicationDbContext context) :base(httpClientFactory,configuration,context)
        {
            _context = context;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<bool> CreatProduct(CreatProduct request)
        {
            var json = JsonConvert.SerializeObject(request);
            var jsonstring = new StringContent(json, Encoding.UTF8, "application/json");
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri(_configuration["URLAPI:Url"]);
            var post = await creat.PostAsync("api/Product/CreatProduct", jsonstring);
            
            return post.IsSuccessStatusCode;
        }

        public async Task<bool> CreatProductQuantity(CreatProductQuantityViewModel request)
        {
            var json = JsonConvert.SerializeObject(request);
            var jsonstring = new StringContent(json, Encoding.UTF8, "application/json");
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri(_configuration["URLAPI:Url"]);
            var post = await creat.PostAsync("api/Product/CreatProductQuantity", jsonstring);
            return post.IsSuccessStatusCode;
        }

        public async Task<bool> CreatWholePrice(CreatWholePriceViewModel request)
        {
            var json = JsonConvert.SerializeObject(request);
            var jsonstring = new StringContent(json, Encoding.UTF8, "application/json");
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri(_configuration["URLAPI:Url"]);
            var post = await creat.PostAsync("api/Product/CreatWholePrice", jsonstring);
            return post.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteProduct(int Id)
        {
            var json = JsonConvert.SerializeObject(Id);
            var jsonstring = new StringContent(json, Encoding.UTF8, "application/json");
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri(_configuration["URLAPI:Url"]);
            var post = await creat.PostAsync("api/Product/DeleteProduct", jsonstring);
            return post.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteWholePrice(int Id)
        {
            var json = JsonConvert.SerializeObject(Id);
            var jsonstring = new StringContent(json, Encoding.UTF8, "application/json");
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri(_configuration["URLAPI:Url"]);
            var post = await creat.PostAsync("api/Product/DeleteWholePrice", jsonstring);
            return post.IsSuccessStatusCode;
        }

        public async Task<ProductColorViewModel> FindColorById(int Id)
        {
            var json = JsonConvert.SerializeObject(Id);
            var jsonstring = new StringContent(json, Encoding.UTF8, "application/json");
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri(_configuration["URLAPI:Url"]);
            var post = await creat.PostAsync("api/Product/FindColorById", jsonstring);
            var readpost = await post.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<ProductColorViewModel>(readpost);
            return product;
        }

        public async Task<ProductViewModel> FindProductById(int Id)
        {
            var json = JsonConvert.SerializeObject(Id);
            var jsonstring = new StringContent(json, Encoding.UTF8, "application/json");
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri(_configuration["URLAPI:Url"]);
            var post = await creat.PostAsync("api/Product/FindProductById", jsonstring);
            var readpost = await post.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<ProductViewModel>(readpost);
            return product;
        }

        public async Task<ProductSizeViewModel> FindProductSizeById(int Id)
        {
            var json = JsonConvert.SerializeObject(Id);
            var jsonstring = new StringContent(json, Encoding.UTF8, "application/json");
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri(_configuration["URLAPI:Url"]);
            var post = await creat.PostAsync("api/Product/FindSizeById", jsonstring);
            var readpost = await post.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<ProductSizeViewModel>(readpost);
            return product;
        }

        public async Task<List<ProductColorViewModel>> GetAllColor()
        {
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri(_configuration["URLAPI:Url"]);
            var post = await creat.GetAsync("api/Product/GetAllColor");
            var readpost = await post.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<List<ProductColorViewModel>>(readpost);
            return product;
        }

        public async Task<List<ProductViewModel>> GetAllProduct()
        {
            var list = await GetAll("api/Product/GetAllProduct");
            return list;
        }

        public async Task<PagedResult<ProductViewModel>> GetAllProductPaging(PageRequest request) // Dev successfull
        {
            var product = await GetAllPaging("api/Product/GetAllProductPaging", request);
            return product;
        }

        public async Task<PagedResult<ProductViewModel>> GetAllProductPagingPart2(RequestBase request)
        {
            var json = JsonConvert.SerializeObject(request);
            var jsonstring = new StringContent(json, Encoding.UTF8, "application/json");
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri(_configuration["URLAPI:Url"]);
            var post = await creat.PostAsync("api/Product/GetAllProductPagingPart2", jsonstring);
            var readpost = await post.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<PagedResult<ProductViewModel>>(readpost);
            return product;
        }

        public async Task<List<ProductQuantityViewModel>> GetAllProductQuantityByProductId(int Id)
        {
            var json = JsonConvert.SerializeObject(Id);
            var jsonstring = new StringContent(json, Encoding.UTF8, "application/json");
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri(_configuration["URLAPI:Url"]);
            var post = await creat.PostAsync("api/Product/GetAllProductQuantityByProductId", jsonstring);
            var readpost = await post.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<List<ProductQuantityViewModel>>(readpost);
            return product;
        }

        public async Task<List<ProductSizeViewModel>> GetAllSize()
        {
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri(_configuration["URLAPI:Url"]);
            var post = await creat.GetAsync("api/Product/GetAllSize");
            var readpost = await post.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<List<ProductSizeViewModel>>(readpost);
            return product;
        }

        public async Task<List<WholePriceViewModel>> GetAllWholePriceByProductId(int Id)
        {
            var json = JsonConvert.SerializeObject(Id);
            var jsonstring = new StringContent(json, Encoding.UTF8, "application/json");
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri(_configuration["URLAPI:Url"]);
            var post = await creat.PostAsync("api/Product/GetAllWholePriceByProductId", jsonstring);
            var readpost = await  post.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<List<WholePriceViewModel>>(readpost);
            return product;
        }

        public async void ImportExcel(CreatExel request)
        {
            var json = JsonConvert.SerializeObject(request);
            var jsonstring = new StringContent(json, Encoding.UTF8, "application/json");
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri(_configuration["URLAPI:Url"]);
            await creat.PostAsync("api/Product/ImportEx", jsonstring);      
        }

        public async Task<ProductViewModel> ProductDetail(int Id)
        {
            var json = JsonConvert.SerializeObject(Id);
            var jsonstring = new StringContent(json, Encoding.UTF8, "application/json");
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri(_configuration["URLAPI:Url"]);
            var post = await creat.PostAsync("api/Product/ProductDetail", jsonstring);
            var readpost = await post.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<ProductViewModel>(readpost);
            return product;
        }

        public async Task<List<ProductViewModel>> ProductSeo(int Id)
        {
            var json = JsonConvert.SerializeObject(Id);
            var jsonstring = new StringContent(json, Encoding.UTF8, "application/json");
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri(_configuration["URLAPI:Url"]);
            var post = await creat.PostAsync("api/Product/ProductSeo", jsonstring);
            var readpost = await post.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<List<ProductViewModel>>(readpost);
            return product;
        }
    }
}
