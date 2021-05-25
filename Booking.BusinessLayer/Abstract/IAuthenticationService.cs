using System.Threading.Tasks;
using Booking.Dto;

namespace Booking.BusinessLayer.Abstract
{
    public interface IAuthenticationService
    {
        Task<UserManagerResponse> RegisterAsync(RegisterRequest request);
        Task<UserManagerResponse> LoginAsync(LoginRequest request);
    }
}