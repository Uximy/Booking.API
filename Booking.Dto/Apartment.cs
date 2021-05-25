using System;
using Newtonsoft.Json;

namespace Booking.Dto
{
    public class Apartment
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("hotel_id")]
        public Guid HotelId { get; set; }

        [JsonProperty("hotel")]
        public Hotel Hotel { get; set; }

        [JsonProperty("apartment_type_id")]
        public int RoomTypeId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}