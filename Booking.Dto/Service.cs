using System;
using Newtonsoft.Json;

namespace Booking.Dto
{
    public class Service
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("hotel_id")]
        public Guid HotelId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }
    }
}