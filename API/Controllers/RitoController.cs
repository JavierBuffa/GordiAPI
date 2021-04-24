using System.Net.Http;
using System.Threading.Tasks;
using API.DTOs;
using API.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace API.Controllers
{
    public class RitoController : BaseApiController
    {
        public HttpClient client { get; set; }
        private readonly IConfiguration _config;

        public RitoController(IConfiguration config)
        {
            _config = config;
            client = new HttpClient();
        }
 
        [HttpGet("{summoner}")]
        public async Task<SummonerDTO> GetProductAsync(string summoner)
        {
            string url = _config.GetSection("RiotApiUrl").Value + summoner.Replace(" ","%20");
            string key = _config.GetSection("RiotApiKey").Value;
            string ritoResponse = null;
            client.DefaultRequestHeaders.Add("X-Riot-Token", key);
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                ritoResponse = await response.Content.ReadAsStringAsync();
            }
            return JsonConvert.DeserializeObject<SummonerDTO>(ritoResponse, new DateTimeConverter());
        }
    }
}