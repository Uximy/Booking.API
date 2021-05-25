using System;
using Newtonsoft.Json;

namespace Booking.Dto
{
    public class Order
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("user_id")]
        public Guid ApplicationUserId { get; set; }

        [JsonProperty("person_count")]
        public int PersonCount { get; set; }

        [JsonProperty("apartment_id")]
        public Guid ApartmentId { get; set; }

        [JsonProperty("check_in")]
        public DateTimeOffset CheckIn { get; set; }

        [JsonProperty("check_out")]
        public DateTimeOffset CheckOut { get; set; }

        [JsonProperty("total_price")]
        public decimal TotalPrice { get; set; }
    }
}