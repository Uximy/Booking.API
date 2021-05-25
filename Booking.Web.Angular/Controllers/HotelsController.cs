using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Booking.Dto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Booking.Web.Angular.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelsController : ControllerBase
    {
        private readonly HttpClient _client;

        public HotelsController(HttpClient client)
        {
            _client = client;
        }
        
        [HttpGet]
        public async Task<IEnumerable<Hotel>> Get()
        {
            var response = await _client.GetAsync("/api/hotel/getHotels");
            var content = await response.Content.ReadAsStringAsync();
            var hotels = JsonConvert.DeserializeObject<IEnumerable<Hotel>>(content);
            return hotels;
        }
    }
}