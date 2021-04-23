using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Application.InterfaceAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageSerVice _languageSerVice;
        public LanguageController(ILanguageSerVice languageSerVice)
        {
            _languageSerVice = languageSerVice;
        }    
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var list = await _languageSerVice.GetAll();
            return Ok(list);
        } 
    }
}
