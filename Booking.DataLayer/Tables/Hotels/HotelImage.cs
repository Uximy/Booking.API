using System;

namespace Booking.DataLayer.Tables.Hotels
{
    public class HotelImage : BaseEntity<Guid>
    {
        public byte[] Source { get; set; }
    }
}