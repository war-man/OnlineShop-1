using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ShopOnline.Data;
using ShopOnline.Model.LanguageModel;
using ShopOnline.Web.ConnectAPI.ConnectComponent;
using ShopOnline.Web.ConnectAPI.InterfaceConnectAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ShopOnline.Web.ConnectAPI.ImplementationConnectAPI
{
    public class LanguageConnectAPI :ILanguageConnectAPI
    {
        private readonly IConfiguration _configuration;

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApplicationDbContext _context;
        public LanguageConnectAPI(IConfiguration configuration, IHttpClientFactory httpClientFactory, ApplicationDbContext context)
        {
            _context = context;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<List<LanguageViewModel>> GetAll()
        {
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri(_configuration["URLAPI:Url"]);
            var post = await creat.GetAsync("api/Language/GetAll");
            var readpost = await post.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<List<LanguageViewModel>>(readpost);
            return product;
        }
    }
}
