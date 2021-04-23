using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ShopOnline.Application.Page;
using ShopOnline.Data;
using ShopOnline.Model.ProductModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Web.ConnectAPI.ConnectComponent
{
    public class BaseConnetAPI<T> where T : class
    {

        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApplicationDbContext _context;
        public BaseConnetAPI(IHttpClientFactory httpClientFactory, IConfiguration configuration, ApplicationDbContext context)
        {
            _context = context;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<List<T>> GetAll(string url)
        {
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri(_configuration["URLAPI:Url"]);
            var post = await creat.GetAsync(url);
            var readpost = await post.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<List<T>>(readpost);
            return product;
        }
        public async Task<PagedResult<T>> GetAllPaging(string url, PageRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var jsonstring = new StringContent(json, Encoding.UTF8, "application/json");
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri(_configuration["URLAPI:Url"]);
            var post = await creat.PostAsync(url, jsonstring);
            var readpost = await post.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<PagedResult<T>>(readpost);
            return product;
        }
        public async Task<T> FindById(string url, int Id)
        {
            var json = JsonConvert.SerializeObject(Id);
            var jsonstring = new StringContent(json, Encoding.UTF8, "application/json");
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri(_configuration["URLAPI:Url"]);
            var post = await creat.PostAsync(url, jsonstring);
            var readpost = await post.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<T>(readpost);
            return product;
        }
        public async Task<bool> Delete(string url, int Id)
        {
            var json = JsonConvert.SerializeObject(Id);
            var jsonstring = new StringContent(json, Encoding.UTF8, "application/json");
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri(_configuration["URLAPI:Url"]);
            var post = await creat.PostAsync(url, jsonstring);
            return post.IsSuccessStatusCode;
        }
        public async Task<bool> DeleteAll(string url)
        {
            var creat = _httpClientFactory.CreateClient();
            creat.BaseAddress = new Uri(_configuration["URLAPI:Url"]);
            var post = await creat.GetAsync(url);
            var readpost = await post.Content.ReadAsStringAsync();
            return post.IsSuccessStatusCode;
        }
    }
}
