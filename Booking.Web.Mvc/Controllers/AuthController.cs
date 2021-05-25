using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Booking.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Booking.Web.Mvc.Controllers
{
    public class AuthController : Controller
    {
        private readonly HttpClient _client;
        private readonly ILogger<AuthController> _logger;

        public AuthController(ILogger<AuthController> logger,
            HttpClient client)
        {
            _logger = logger;
            _client = client;
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View(new LoginRequest());
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginRequest login)
        {
            var body = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/api/security/login", body);
            var content = await response.Content.ReadAsStringAsync();
            var userManagerResponse = JsonConvert.DeserializeObject<UserManagerResponse>(content);
            HttpContext.Session.SetString("Token", userManagerResponse.Token);
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}