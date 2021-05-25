using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Booking.BusinessLayer.Abstract;
using Booking.Dto;
using Booking.DataLayer.Contexts;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Booking.BusinessLayer.Services
{
    public class CountryService : ICountryService
    {
        private readonly BookingContext _context;
        private readonly IMapper _mapper;

        public CountryService(BookingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<City>> GetCities()
        {
            var domainCities = await _context.Cities.ToListAsync();
            var dtoCities = _mapper.Map<IEnumerable<City>>(domainCities);
            return dtoCities;
        }

        public async Task<IEnumerable<Country>> GetCountries()
        {
            var domainCounties = await _context.Countries.ToListAsync();
            var dtoCounties = _mapper.Map<IEnumerable<Country>>(domainCounties);
            return dtoCounties;
        }
    }
}