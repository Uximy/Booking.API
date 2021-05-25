using System.Collections.Generic;
using System.Threading.Tasks;
using Booking.Api.Responses;
using Booking.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Api.Controllers.Dictionaries
{
    public partial class DictionariesController
    {
        [Authorize(Roles = "admin,moderator")]
        [HttpGet("retrieve-countries")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommonReply<Country>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply<Country>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply<Country>))]
        public async Task<IActionResult> RetrieveCountries()
        {
            var countries = await _countryService.GetCountries();
            return Ok(new CommonReply<IEnumerable<Country>>(countries));
        }
    }
}