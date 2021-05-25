using System;
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
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public partial class HotelsController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelsController(IApartamentService apartamentService,
            IHotelService hotelService)
        {
            _apartamentService = apartamentService;
            _hotelService = hotelService;
        }

        [Authorize(Roles = "admin,client,moderator")]
        [HttpGet("retrieve-hotels")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommonReply<Hotel>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply<Hotel>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply<Hotel>))]
        public async Task<IActionResult> RetrieveHotels()
        {
            var hotels = await _hotelService.GetHotelsAsync();
            return Ok(new CommonReply<IEnumerable<Hotel>>(hotels));
        }

        [Authorize(Roles = "admin, moderator")]
        [HttpPost("create-hotel")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommonReply<Hotel>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply<Hotel>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply<Hotel>))]
        public async Task<IActionResult> AddHotel([FromBody] Hotel hotel)
        {
            await Task.Yield();
            var id = await _hotelService.CreateHotelAsync(hotel);
            return Ok(new CommonReply<Guid>(id));
        }

        [Authorize(Roles = "admin,moderator")]
        [HttpPut("edit-hotel")]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(CommonReply<Hotel>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply<Hotel>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply<Hotel>))]
        public async Task<IActionResult> EditHotel([FromBody] Hotel hotel)
        {
            var editedHotel = await _hotelService.EditHotelAsync(hotel);
            return Ok(new CommonReply<Hotel>(editedHotel));
        }
    }
}