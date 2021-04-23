using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ShopOnline.Application.Page;
using ShopOnline.Model.PageModel;
using ShopOnline.Web.ConnectAPI.InterfaceConnectAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Web.ConnectAPI.ImplementationConnectAPI
{
    public class PageConnectAPI : IPageConnectAPI
    {
        private readonly IConfiguration _configuration;

        private readonly IHttpClientFactory _httpClientFactory;
        public PageConnectAPI(IConfiguration configuration,IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<bool> CreatPage(CreatPage request)
        {

            var json = JsonConvert.SerializeObject(request);
            var jsonstring = new StringContent(json, Encoding.UTF8, "application/json");
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri(_configuration["URLAPI:Url"]);
            var post = await creat.PostAsync("api/Page/CreatPage",jsonstring);
            return post.IsSuccessStatusCode;
        }

        public async Task<bool> DeletePage(int Id)
        {
            var json = JsonConvert.SerializeObject(Id);
            var jsonstring = new StringContent(json, Encoding.UTF8, "application/json");
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri(_configuration["URLAPI:Url"]);
            var post = await creat.PostAsync("api/Page/DeletePage", jsonstring);
            return post.IsSuccessStatusCode;
        }

        public async Task<PageViewModel> FindPageById(int Id)
        {
            var json = JsonConvert.SerializeObject(Id);
            var jsonstring = new StringContent(json, Encoding.UTF8, "application/json");
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri(_configuration["URLAPI:Url"]);
            var post = await creat.PostAsync("api/Page/FindPageById", jsonstring);
            var readpost = await post.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<PageViewModel>(readpost);
            return product;
        }

        public async Task<PagedResult<PageViewModel>> GetAllPagePaging(PageRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var jsonstring = new StringContent(json, Encoding.UTF8, "application/json");
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri(_configuration["URLAPI:Url"]);
            var post = await creat.PostAsync("api/Page/GetAllPagePaging",jsonstring);
            var readpost = await post.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<PagedResult<PageViewModel>>(readpost);
            return product;
        }

        public async Task<bool> UpdatePage(UpdatePage request)
        {
            var json = JsonConvert.SerializeObject(request);
            var jsonstring = new StringContent(json, Encoding.UTF8, "application/json");
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri(_configuration["URLAPI:Url"]);
            var post = await creat.PostAsync("api/Page/UpdatePage", jsonstring);
            return post.IsSuccessStatusCode;
        }
    }
}
