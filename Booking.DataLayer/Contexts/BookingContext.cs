using System;
using Booking.DataLayer.Tables.Archives;
using Booking.DataLayer.Tables.Bookings;
using Booking.DataLayer.Tables.Companies;
using Booking.DataLayer.Tables.Dictionaries;
using Booking.DataLayer.Tables.Hotels;
using Booking.DataLayer.Tables.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Booking.DataLayer.Contexts
{
    public class BookingContext : IdentityDbContext<ApplicationUser, ApplicationUserRole, Guid>
    {
        public BookingContext(DbContextOptions<BookingContext> options)
            : base(options)
        {
        }

        #region Companies

        public DbSet<Company> Companies { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(
                    "Server=tcp:sep-192.database.windows.net,1433;" +
                    "Initial Catalog=booking-sep192;Persist Security Info=False;" +
                    "User ID=sep-192-admin;Password=!CthdthysqCthdth7;" +
                    "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        #region Archives

        public DbSet<AuthenticationArchive> AuthenticationArchives { get; set; }
        public DbSet<BookingArchive> BookingArchives { get; set; }

        #endregion

        #region Bookings

        public DbSet<Check> Checks { get; set; }
        public DbSet<Order> Orders { get; set; }

        #endregion

        #region Dictionaries

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }

        #endregion

        #region Hotels

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Bed> Beds { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<HotelImage> Images { get; set; }

        #endregion

        #region Users

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }

        #endregion
    }
}