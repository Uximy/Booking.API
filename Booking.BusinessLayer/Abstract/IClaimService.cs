using System.Threading.Tasks;
using Booking.DataLayer.Tables.Users;
using Booking.Dto;

namespace Booking.BusinessLayer.Abstract
{
    public interface IClaimService
    {
        Task<UserManagerResponse> GetClaims(ApplicationUser user, params string[] roles);
    }
}