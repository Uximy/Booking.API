using System.Collections.Generic;
using System.Threading.Tasks;
using Booking.Dto;

namespace Booking.BusinessLayer.Abstract
{
    public interface IApartamentService
    {
        Task<IEnumerable<Apartment>> GetApataments();
    }
}