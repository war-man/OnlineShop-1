using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ShopOnline.Data;
using ShopOnline.Data.Entity;
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
    public class AnnoucementConnectAPI : BaseConnetAPI<Product>, IAnnoucementConnectAPI
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApplicationDbContext _context;
        public AnnoucementConnectAPI(IHttpClientFactory httpClientFactory,IConfiguration configuration, ApplicationDbContext context) :base(httpClientFactory,configuration,context)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> DeleteAllAnn()
        {
            var post = await DeleteAll("api/Annoucement/DeleteAllAnn");
            return post;
        }

        public async Task<bool> DeleteAnnnoucement(int Id)
        {
            var json = JsonConvert.SerializeObject(Id);
            var jsonstring = new StringContent(json, Encoding.UTF8, "application/json");
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri(_configuration["URLAPI:Url"]);
            var post = await creat.PostAsync("api/Annoucement/DeleteAnn", jsonstring);
            return post.IsSuccessStatusCode;
        }
        
    }
}
