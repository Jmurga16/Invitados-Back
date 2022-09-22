using Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace Invitados.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DniController : Controller
    {

        private readonly IConfiguration _config;
        static HttpClient MyHttpClient = new HttpClient();

        public DniController(IConfiguration configuration)
        {
            _config = configuration;
        }

        [HttpGet]
        public IActionResult GetDNI(string paramDni)
        {

            var baseUrl = _config["ApiPeruDev:UrlApi"];
            var token = _config["ApiPeruDev:token"];
            string stateInfo = "";

            MyHttpClient.DefaultRequestHeaders.Clear();

            MyHttpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", token));

            HttpResponseMessage response = MyHttpClient.GetAsync(baseUrl + "dni/" + paramDni).Result;
            if (response.IsSuccessStatusCode)
            {
                stateInfo = response.Content.ReadAsStringAsync().Result;
            }
            
            return Ok(stateInfo);
        }

    }
}
