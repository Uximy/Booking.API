using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Booking.BusinessLayer.Abstract;
using Booking.DataLayer.Contexts;
using Booking.Dto;
using Microsoft.EntityFrameworkCore;

namespace Booking.BusinessLayer.Services
{
    public class ApartamentService : IApartamentService
    {
        private readonly BookingContext _context;

        private readonly IMapper _mapper;

        public ApartamentService(BookingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Apartment>> GetApataments()
        {
            IEnumerable<DataLayer.Tables.Hotels.Apartment> apartments = await _context.Apartments.ToListAsync();

            var dtoCountries = _mapper.Map<IEnumerable<Apartment>>(apartments);
            return dtoCountries;
        }
    }
}