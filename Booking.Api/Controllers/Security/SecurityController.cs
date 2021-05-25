using System.Threading.Tasks;
using Booking.BusinessLayer.Abstract;
using Booking.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Api.Controllers.Security
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class SecurityController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public SecurityController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserManagerResponse))]
        public async Task<IActionResult> Login([FromBody] LoginRequest login)
        {
            var userResponse = await _authenticationService.LoginAsync(login);
            return Ok(userResponse);
        }
        
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserManagerResponse))]
        public async Task<IActionResult> Register([FromBody] RegisterRequest register)
        {
            var userResponse = await _authenticationService.RegisterAsync(register);
            return Ok(userResponse);
        }
    }
}