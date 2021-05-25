using System.Collections.Generic;
using System.Threading.Tasks;
using Booking.Api.Responses;
using Booking.BusinessLayer.Abstract;
using Booking.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Api.Controllers.Hotels
{
    public partial class HotelsController
    {
        private readonly IApartamentService _apartamentService;

        [Authorize(Roles = "admin,client,moderator")]
        [HttpGet("retrieve-apartments")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommonReply<Apartment>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply<Apartment>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply<Apartment>))]
        public async Task<IActionResult> RetrieveApartaments()
        {
            var apartments = await _apartamentService.GetApataments();
            return Ok(new CommonReply<IEnumerable<Apartment>>(apartments));
        }
    }
}