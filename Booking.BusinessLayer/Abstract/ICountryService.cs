using System.Collections.Generic;
using System.Threading.Tasks;
using Booking.Dto;

namespace Booking.BusinessLayer.Abstract
{
  public interface ICountryService
  {
        Task<IEnumerable<Country>> GetCountries();
        Task<IEnumerable<City>> GetCities();
  }
}