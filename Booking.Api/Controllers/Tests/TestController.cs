using System.Collections.Generic;
using System.Threading.Tasks;
using Booking.BusinessLayer.Abstract;
using Booking.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Booking.Api.Controllers.Tests
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class TestController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public TestController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet("check-service")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> CheckService()
        {
            Log.Information("Test controller start");
            await Task.Yield();
            return Ok("Service is working!");
        }
    }
}