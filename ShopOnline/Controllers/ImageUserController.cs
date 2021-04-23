using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Application.InterfaceAPI;
using ShopOnline.Model.ImageUserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageUserController : ControllerBase
    {
        private readonly IImageUserSerVice _imageUserSerVice;
        public ImageUserController(IImageUserSerVice imageUserSerVice)
        {
            _imageUserSerVice = imageUserSerVice;
        }
        [HttpPost("CreateImageUser")]
        public async Task<IActionResult> Create([FromBody]CreateImageUser request)
        {

            var find = await _imageUserSerVice.CreateImageUser(request.Images,request.UserName);
            return Ok();
        }
        [HttpPost("DeleteImageUser")]
        public async Task<IActionResult> Delete([FromBody]int Id)
        {
            var find =await  _imageUserSerVice.DeleteImageUser(Id);
            return Ok();
        }
        [HttpGet("GetAllImageUser")]
        public async Task<IActionResult> GetAll()
        {
            var find = await _imageUserSerVice.GetAllImageUser();
            return Ok(find);
        }
        [HttpPost("GetListProductImageByUserName")]
        public async Task<IActionResult> GetListProductImageByUserName([FromBody]string UserName)
        {
            var find = await _imageUserSerVice.GetListProductImageByUserName(UserName);
            return Ok(find);
        }
    }
}
