using System.Collections.Generic;

namespace Booking.DataLayer.Tables.Dictionaries
{
    public class Country
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<City> Cities { get; set; }

        public Country()
        {
            Cities = new List<City>();
        }
    }
}