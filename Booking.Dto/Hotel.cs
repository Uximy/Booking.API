using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Booking.Dto
{
    public class Hotel
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("company_id")]
        public Guid CompanyId { get; set; }

        [JsonProperty("company")]
        public Company Company { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("additional_id")]
        public string AdditionalInfo { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("lat")]
        public double? Lat { get; set; }

        [JsonProperty("lng")]
        public double? Lng { get; set; }

        [JsonProperty("rate")]
        public double Rate { get; set; }

        [JsonProperty("city_id")]
        public int CityId { get; set; }

        [JsonProperty("city")]
        public City City { get; set; }

        [JsonProperty("apartments")]
        public ICollection<Apartment> Apartments { get; set; }
    }
}