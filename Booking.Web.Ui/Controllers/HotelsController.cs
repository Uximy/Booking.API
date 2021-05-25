using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace Booking.Web.Ui.Controllers {
  [ApiController]
  [Route("api/[controller]")]
  public class HotelsController : ControllerBase {
    private readonly HttpClient _client;

    public HotelsController(HttpClient client) {
      _client = client;
    }

    [HttpGet("gethotels")]
    public async Task<string> GetHotels() {
      _client.BaseAddress = new Uri("https://localhost:44397");
      var response = await _client.GetAsync("/api/hotel/getHotels");
      var content = await response.Content.ReadAsStringAsync();
      return content;
    }
  }
}
