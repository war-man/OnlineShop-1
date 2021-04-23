using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ShopOnline.Model.ProductImageModel;
using ShopOnline.Web.ConnectAPI.InterfaceConnectAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Web.ConnectAPI.ImplementationConnectAPI
{
    public class ProductImageConnectAPI : IProductImageConnectAPI
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        public ProductImageConnectAPI(IHttpClientFactory httpClientFactory,IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }    
        public async Task<bool> CreatProductImage(CreatProductImage request)
        {
            var json = JsonConvert.SerializeObject(request);
            var jsonstring = new StringContent(json, Encoding.UTF8, "application/json");
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress =new Uri(_configuration["URLAPI:Url"]);
            var post = await creat.PostAsync("api/ProductImage/CreatProductImage", jsonstring);
            return post.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteProductImage(int Id)
        {
            var json = JsonConvert.SerializeObject(Id);
            var jsonstring = new StringContent(json, Encoding.UTF8, "application/json");
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress =new Uri(_configuration["URLAPI:Url"]);
            var post = await creat.PostAsync("api/ProductImage/DeleteProductImage", jsonstring);
            return post.IsSuccessStatusCode;
        }

        public async Task<List<ProductImageViewModel>> GetAllProductImage()
        {
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress =new Uri(_configuration["URLAPI:Url"]);
            var post = await creat.GetAsync("api/ProductImage/GetAllProductImage");
            var readpost = await post.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<List<ProductImageViewModel>>(readpost);
            return product;
        }

        public async Task<List<ProductImageViewModel>> GetListProductImageByProductId(int Id)
        {
            var json = JsonConvert.SerializeObject(Id);
            var jsonstring = new StringContent(json, Encoding.UTF8, "application/json");
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress =new Uri(_configuration["URLAPI:Url"]);
            var post = await creat.PostAsync("api/ProductImage/GetListProductImageByProductId", jsonstring);
            var readpost = await post.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<List<ProductImageViewModel>>(readpost);
            return product;
        }
    }
}
