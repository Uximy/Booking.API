using Booking.DataLayer.Tables.Dictionaries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Booking.DataLayer.Tables.Companies;

namespace Booking.DataLayer.Tables.Hotels
{
    public class Hotel : BaseEntity<Guid>
    {
        public Guid CompanyId { get; set; }
        
        [ForeignKey(nameof(CompanyId))]
        public virtual Company Company { get; set; }
        
        [StringLength(128)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [StringLength(1000)]
        public string AdditionalInfo { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        public double? Lat { get; set; }

        public double? Lng { get; set; }

        [Range(0, 5)]
        public double Rate { get; set; }
        
        public int CityId { get; set; }
        
        [ForeignKey(nameof(CityId))]
        public virtual City City { get; set; }

        public virtual ICollection<Apartment> Rooms { get; set; }

        public virtual ICollection<HotelImage> Images { get; set; }
        
        public virtual ICollection<Service> Services { get; set; }

        public Hotel()
        {
            Rooms = new List<Apartment>();
            Images = new List<HotelImage>();
            Services = new List<Service>();
        }
    }
}