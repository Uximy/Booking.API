using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Booking.Dto
{
    public class RegisterRequest
    {
        [Required]
        [StringLength(55)]
        [EmailAddress]
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("city_id")]
        public int CityId { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength = 8)]
        [JsonProperty("password")]
        public string Password { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength = 8)]
        [JsonProperty("confirm_password")]
        public string ConfirmPassword { get; set; }
    }
}