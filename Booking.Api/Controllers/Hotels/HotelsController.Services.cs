using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Booking.Api.Responses;
using Booking.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Api.Controllers.Hotels
{
    public partial class HotelsController
    {
        [Authorize(Roles = "admin,client,moderator")]
        [HttpGet("retrieve-hotel-services")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommonReply<Service>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply<Service>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply<Service>))]
        public async Task<IActionResult> RetrieveHotelServices(Guid hotelId)
        {
            var services = await _hotelService.GetServicesAsync(hotelId);
            return Ok(new CommonReply<IEnumerable<Service>>(services));
        }

        [Authorize(Roles = "admin,moderator")]
        [HttpPost("create-hotel-service")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommonReply<Service>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply<Service>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply<Service>))]
        public async Task<IActionResult> CreateNewService([FromBody] Service service)
        {
            var createdService = await _hotelService.CreateServiceAsync(service);
            return Ok(new CommonReply<Service>(createdService));
        }

        [Authorize(Roles = "admin,moderator")]
        [HttpPut("edit-hotel-service")]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(CommonReply<Service>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply<Service>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply<Service>))]
        public async Task<IActionResult> UpdateService([FromBody] Service service)
        {
            var editedService = await _hotelService.EditServiceAsync(service);
            return Ok(new CommonReply<Service>(editedService));
        }
    }
}