using Newtonsoft.Json;

namespace Booking.Dto
{
    public class City
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("country_id")]
        public int CountryId { get; set; }

        [JsonProperty("country")]
        public Country Country { get; set; }
    }
}