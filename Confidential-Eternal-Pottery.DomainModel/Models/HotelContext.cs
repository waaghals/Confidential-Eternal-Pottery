using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ConfidentialEternalPottery.DomainModel.Models
{
    public class HotelContext : DbContext
    {
        public HotelContext()
            : base()
        {
            Database.SetInitializer<HotelContext>(new DatabaseInitializer());
        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
    public class DatabaseInitializer : CreateDatabaseIfNotExists<HotelContext>
    {
        protected override void Seed(HotelContext context)
        {
            var rooms = new List<Room> { 
                new Room{ Capacity = 3, Number = 1, MinimumPrice = (decimal)75.00 },
                new Room{ Capacity = 2, Number = 2, MinimumPrice = (decimal)50.00 },
                new Room{ Capacity = 5, Number = 3, MinimumPrice = (decimal)250.00 },
                new Room{ Capacity = 5, Number = 4, MinimumPrice = (decimal)500.00 },
                new Room{ Capacity = 2, Number = 5, MinimumPrice = (decimal)300.00 },
                new Room{ Capacity = 3, Number = 6, MinimumPrice = (decimal)450.00 },
                new Room{ Capacity = 2, Number = 7, MinimumPrice = (decimal)175.00 },
                new Room{ Capacity = 3, Number = 8, MinimumPrice = (decimal)250.00 },
                new Room{ Capacity = 5, Number = 9, MinimumPrice = (decimal)1000.00 },
                new Room{ Capacity = 5, Number = 10, MinimumPrice = (decimal)1500.00 } 
            };
            rooms.ForEach(r => context.Rooms.Add(r));
            context.SaveChanges();
        }
    }
}