
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ShopOnline.Model.ProductModel;
using ShopOnline.Web.Produce;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Web.Controllers
{
    public class ConnectController : Controller
    {
        private readonly IConfiguration _configuration;
        public ConnectController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
