using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booking.BusinessLayer.Abstract;
using Booking.DataLayer.Contexts;
using Booking.DataLayer.Tables.Users;
using Booking.Dto;
using Microsoft.AspNetCore.Identity;
using Serilog;

namespace Booking.BusinessLayer.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly BookingContext _context;
        private readonly IClaimService _claimService;

        public AuthenticationService(UserManager<ApplicationUser> userManager, 
            BookingContext context, IClaimService claimService)
        {
            _userManager = userManager;
            _context = context;
            _claimService = claimService;
        }

        public async Task<UserManagerResponse> RegisterAsync(RegisterRequest request)
        {
            Log.Information(nameof(RegisterAsync) + " started");
            if (request is null)
            {
                Log.Error("Register request is null", request);
                throw new ArgumentNullException($"Register request is null");
            }

            if (request.Password != request.ConfirmPassword)
            {
                return new UserManagerResponse("Пароли не совпадают", false);
            }

            var identityUser = new ApplicationUser
            {
                Email = request.Email,
                UserName = request.Email,
                CityId = request.CityId
            };

            var registerResult = await _userManager.CreateAsync(identityUser, request.Password);

            if (registerResult.Succeeded)
            {
                Log.Information($"User registered!", identityUser.UserName);
                await _userManager.AddToRoleAsync(identityUser, "client");
                Log.Information("User set role client");
                return await _claimService.GetClaims(identityUser, "client");
            }

            StringBuilder errors = new StringBuilder();
            if (registerResult.Errors is not null)
            {
                foreach (var error in registerResult.Errors)
                {
                    errors.Append(error.Description);
                }
            }
            Log.Information(nameof(RegisterAsync) + " finished");
            return new UserManagerResponse(errors.ToString(), false);
        }

        public async Task<UserManagerResponse> LoginAsync(LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user is null)
            {
                return new UserManagerResponse("Пользователь с таким электронным адресом не найден", false);
            }

            var passPasswordValidation = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!passPasswordValidation)
            {
                return new UserManagerResponse("Логин или пароль введены неверно", false);
            }

            var roles = await _userManager.GetRolesAsync(user);

            return await _claimService.GetClaims(user, roles.ToArray());
        }
    }
}