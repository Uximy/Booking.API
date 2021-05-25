using AutoMapper;
using Booking.Dto;
using Domain = Booking.DataLayer.Tables;

namespace Booking.BusinessLayer.MapperProfiles
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<Country, Domain.Dictionaries.Country>()
                .ReverseMap();
            CreateMap<City, Domain.Dictionaries.City>()
                .ReverseMap();
            CreateMap<Apartment, Domain.Hotels.Apartment>()
                .ReverseMap();
            CreateMap<Check, Domain.Bookings.Check>()
                .ReverseMap();
            CreateMap<Company, Domain.Companies.Company>()
                .ReverseMap();
            CreateMap<Hotel, Domain.Hotels.Hotel>()
                .ReverseMap();
            CreateMap<Order, Domain.Bookings.Order>()
                .ReverseMap();
            CreateMap<Service, Domain.Hotels.Service>()
                .ReverseMap();
            CreateMap<HotelImage, Domain.Hotels.HotelImage>()
                .ReverseMap();
        }
    }
}