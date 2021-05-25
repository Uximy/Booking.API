using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Booking.Api.Responses;
using Booking.BusinessLayer.Abstract;
using Booking.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Api.Controllers.Companies
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [Authorize(Roles = "admin,client,moderator")]
        [HttpGet("retrieve-companies")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommonReply<Company>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply<Company>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply<Company>))]
        public async Task<IActionResult> RetrieveCompanies()
        {
            var companies = await _companyService.GetCompanies();
            return Ok(new CommonReply<IEnumerable<Company>>(companies));
        }

        [Authorize(Roles = "admin,moderator")]
        [HttpPost("create-company")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommonReply<Company>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply<Company>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply<Company>))]
        public async Task<IActionResult> AddCompany([FromBody] Company company)
        {
            await Task.Yield();
            var id = _companyService.AddCompany(company);
            return Ok(new CommonReply<Guid>(id));
        }

        [Authorize(Roles = "admin,moderator")]
        [HttpPut("edit-company")]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(CommonReply<Company>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply<Company>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply<Company>))]
        public async Task<IActionResult> EditCompany([FromBody] Company company)
        {
            var editedCompany = await _companyService.EditCompany(company);
            return Ok(new CommonReply<Company>(editedCompany));
        }
    }
}