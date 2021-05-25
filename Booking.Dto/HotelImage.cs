using System;
using Newtonsoft.Json;

namespace Booking.Dto
{
    public class HotelImage
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("source")]
        public byte[] Source { get; set; }
    }
}