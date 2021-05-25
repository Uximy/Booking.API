using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Booking.BusinessLayer.Abstract;
using Booking.DataLayer.Tables.Users;
using Booking.Dto;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Booking.BusinessLayer.Services
{
    public class ClaimService : IClaimService
    {
        private readonly IConfiguration _configuration;

        public ClaimService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<UserManagerResponse> GetClaims(ApplicationUser user, params string[] roles)
        {
            await Task.Yield();

            var claims = new List<Claim>
            {
                new Claim("Email", user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]);
            var secret = new SymmetricSecurityKey(key);
            var signingCredentials = new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);

            var tokenOption = new JwtSecurityToken(
                issuer: _configuration["AuthSettings:Issuer"],
                audience: _configuration["AuthSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(1)
                    .AddMinutes(Convert.ToDouble(_configuration["AuthSettings:ExpiredInMinutes"])),
                signingCredentials: signingCredentials);
            
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOption);

            return new UserManagerResponse(token: tokenString, success: true, expiredDate: tokenOption.ValidTo);
        }
    }
}