using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Booking.Dto
{
    public class LoginRequest
    {
        [Required]
        [StringLength(55)]
        [EmailAddress]
        [JsonProperty("email")]
        public string Email { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength = 8)]
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}