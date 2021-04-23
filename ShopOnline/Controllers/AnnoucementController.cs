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
    public class AnnoucementController : ControllerBase
    {
        private readonly IAnnoucementSerVice _annoucementSerVice;
        public AnnoucementController(IAnnoucementSerVice annoucementSerVice)
        {
            _annoucementSerVice = annoucementSerVice;
        }
        [HttpPost("DeleteAnn")]
        public async Task<IActionResult> DeleteAnn([FromBody]int Id)
        {
            var delete = await _annoucementSerVice.DeleteAnn(Id);
            return Ok();
        }
        [HttpGet("DeleteAllAnn")]
        public async Task<IActionResult> DeleteAllAnn()
        {
            var delete = await _annoucementSerVice.DeleteAllAnn();
            return Ok();
        }
    }
}
