using System.Collections.Generic;
using System.Threading.Tasks;
using Booking.Api.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using City = Booking.Dto.City;

namespace Booking.Api.Controllers.Dictionaries
{
    public partial class DictionariesController
    {
        [Authorize(Roles = "admin,moderator")]
        [HttpGet("retrieve-cities")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommonReply<City>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply<City>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply<City>))]
        public async Task<IActionResult> RetrieveCities()
        {
            var cities = await _countryService.GetCities();
            return Ok(new CommonReply<IEnumerable<City>>(cities));
        }
    }
}