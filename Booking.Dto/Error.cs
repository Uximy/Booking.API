using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Booking.Dto
{
    public class Error
    {
        /// <summary>HTTP status code associated</summary>
        [JsonProperty("status", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        /// <summary>A short summary of the error</summary>
        [JsonProperty("title", Required = Required.Always)]
        [Required(AllowEmptyStrings = true)]
        public string Title { get; set; }

        /// <summary>Explanation of the error</summary>
        [JsonProperty("detail", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Detail { get; set; }
    }
}