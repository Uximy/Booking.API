using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Booking.Dto;

namespace Booking.BusinessLayer.Abstract
{
    public interface IHotelService
    {
        Task<IEnumerable<Hotel>> GetHotelsAsync();
        Task<Guid> CreateHotelAsync(Hotel hotel);
        Task<Hotel> EditHotelAsync(Hotel hotel);
        
        Task<IEnumerable<Service>> GetServicesAsync(Guid hotelId);
        Task<Service> CreateServiceAsync(Service service);
        Task<Service> EditServiceAsync(Service service);
    }
}