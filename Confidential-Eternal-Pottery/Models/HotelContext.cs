using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace ConfidentialEternalPottery.Models
{
    public class HotelContext : DbContext
    {
        public HotelContext()
            : base()
        {
            Database.SetInitializer(
                            new DropCreateDatabaseIfModelChanges<HotelContext>()); 
            // Database.SetInitializer<HotelContext>(new CreateDatabaseIfNotExists<HotelContext>());
            //Database.SetInitializer<HotelContext>(null);
        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public DbSet<Guest> Guest { get; set; }
    }
}