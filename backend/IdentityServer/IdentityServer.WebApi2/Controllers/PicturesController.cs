using IdentityServer.WebApi2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.WebApi2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PicturesController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public IActionResult GetPictures()
        {
            var pictures = new List<Picture>()
            {
                new Picture{ Id = 1, Name = "Doğa resmi", Url = "dogaresmi.jpg" },
                new Picture{ Id = 2, Name = "Fil resmi", Url = "filresmi.jpg" },
                new Picture{ Id = 3, Name = "Aslan resmi", Url = "aslanresmi.jpg" },
                new Picture{ Id = 4, Name = "Fare resmi", Url = "fareresmi.jpg" },
                new Picture{ Id = 5, Name = "Köpek resmi", Url = "köpekresmi.jpg" }
            };
            return Ok(pictures);
        }
    }
}
