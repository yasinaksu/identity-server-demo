using IdentityServer.WebApi1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.WebApi1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [Authorize(Policy = "ReadProduct")]
        [HttpGet]
        public IActionResult GetProducts()
        {
            var productList = new List<Product>()
            {
                new Product{ Id = 1, Name = "Kalem", Price = 100, Stock = 500 },
                new Product{ Id = 2, Name = "Silgi", Price = 100, Stock = 500 },
                new Product{ Id = 3, Name = "Defter", Price = 100, Stock = 500 },
                new Product{ Id = 4, Name = "Kitap", Price = 100, Stock = 500 },
                new Product{ Id = 5, Name = "Bant", Price = 100, Stock = 500 }
            };

            return Ok(productList);
        }

        [Authorize(Policy ="UpdateOrCreate")]
        [HttpPost]
        public IActionResult UpdateProduct(int id)
        {
            return Ok($"{id} id değerli product güncellenmiştir");
        }

        [Authorize(Policy ="UpdateOrCreate")]
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            return Ok("Ürün eklendi");
        }
    }
}
