using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ConfidentialEternalPottery.Models
{
    public class HotelContext : DbContext
    {
        public HotelContext()
            : base()
        {
            Database.SetInitializer<HotelContext>(new CreateDatabaseIfNotExists<HotelContext>());
            //Database.SetInitializer<HotelContext>(null);
        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}