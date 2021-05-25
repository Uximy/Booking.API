using System;
using Newtonsoft.Json;

namespace Booking.Dto
{
    public class Check
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("order_id")]
        public Guid OrderId { get; set; }

        [JsonProperty("order")]
        public Order Order { get; set; }
    }
}