using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Booking.DataLayer.Tables.Hotels
{
  public class Apartment : BaseEntity<Guid>
  {
    public Guid HotelId { get; set; }

    [ForeignKey(nameof(HotelId))]
    public virtual Hotel Hotel { get; set; }

    public int RoomTypeId { get; set; }

    [ForeignKey(nameof(RoomTypeId))]
    public virtual ApartmentType ApartmentType { get; set; }

    [StringLength(50)]
    public string Name { get; set; }

    /// <summary>
    /// Price per night
    /// </summary>
    public decimal Price { get; set; }

    [StringLength(500)]
    public string Description { get; set; }

    public virtual ICollection<Bed> Beds { get; set; }

    public virtual ICollection<HotelImage> Images { get; set; }

    public Apartment()
    {
      Beds = new List<Bed>();
      Images = new List<HotelImage>();
    }
  }
}