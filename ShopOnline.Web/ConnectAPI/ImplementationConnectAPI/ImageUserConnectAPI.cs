using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ShopOnline.Data;
using ShopOnline.Model.ImageUserModel;
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
    public class ImageUserConnectAPI :IImageUserConnectAPI
    {
        private readonly IConfiguration _configuration;

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApplicationDbContext _context;
        public ImageUserConnectAPI(IConfiguration configuration,IHttpClientFactory httpClientFactory, ApplicationDbContext context)
        {
            _context = context;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            
        }
        public async Task<bool> CreateImageUser(CreateImageUser request)
        {
            var json = JsonConvert.SerializeObject(request);
            var jsonstring = new StringContent(json, Encoding.UTF8, "application/json");
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri(_configuration["URLAPI:Url"]);
            var post = await creat.PostAsync("api/ImageUser/CreateImageUser", jsonstring);
            return post.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteImageUser(int Id)
        {
            var json = JsonConvert.SerializeObject(Id);
            var jsonstring = new StringContent(json, Encoding.UTF8, "application/json");
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri(_configuration["URLAPI:Url"]);
            var post = await creat.PostAsync("api/ImageUser/DeleteImageUser", jsonstring);
            return post.IsSuccessStatusCode;
        }

        public async Task<List<ImageUserViewModel>> GetAll()
        {
         
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri(_configuration["URLAPI:Url"]);
            var post = await creat.GetAsync("api/ImageUser/GetAllImageUser");
            var readpost = await post.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<List<ImageUserViewModel>>(readpost);
            return product;
        }

        public async Task<List<ImageUserViewModel>> GetListProductImageByUserName(string UserName)
        {
            var json = JsonConvert.SerializeObject(UserName);
            var jsonstring = new StringContent(json, Encoding.UTF8, "application/json");
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri(_configuration["URLAPI:Url"]);
            var post = await creat.PostAsync("api/ImageUser/GetListProductImageByUserName",jsonstring);
            var readpost = await post.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<List<ImageUserViewModel>>(readpost);
            return product;
        }
    }
}
