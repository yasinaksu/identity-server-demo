using IdentityModel.Client;
using IdentityServer.MvcWebClient.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace IdentityServer.MvcWebClient.Controllers
{
    public class ProductController : Controller
    {
        private readonly IConfiguration _configuration;
        public ProductController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            List<Product> products = null;
            var httpClient = new HttpClient();
            var discoveryEndpoint = await httpClient.GetDiscoveryDocumentAsync("https://localhost:5001");

            if (discoveryEndpoint.IsError)
            {
                //loglama 
            }
            var clientCredentialsTokenRequest = new ClientCredentialsTokenRequest();
            clientCredentialsTokenRequest.ClientId = _configuration.GetSection("Client:ClientId").Value;
            clientCredentialsTokenRequest.ClientSecret = _configuration.GetSection("Client:ClientSecret").Value;
            clientCredentialsTokenRequest.Address = discoveryEndpoint.TokenEndpoint;

            var token =  await httpClient.RequestClientCredentialsTokenAsync(clientCredentialsTokenRequest);

            //https://localhost:5003
            //https://localhost:5007

            httpClient.SetBearerToken(token.AccessToken);

            var response = await httpClient.GetAsync("https://localhost:5007/api/products/getproducts");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                products = JsonConvert.DeserializeObject<List<Product>>(content);
            }

            return View(products);
        }
    }
}
