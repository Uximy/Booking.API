using AutoMapper;
using Booking.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Api.Controllers.Dictionaries
{
    [ApiController]
    [Route("api/[controller]/dictionaries")]
    [Produces("application/json")]
    public partial class DictionariesController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public DictionariesController(ICountryService countryService)
        {
            _countryService = countryService;
        }
    }
}