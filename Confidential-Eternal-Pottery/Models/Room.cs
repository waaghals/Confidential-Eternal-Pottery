using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConfidentialEternalPottery.Models
{
    public class Room
    {
        public Room()
        {
            Bookings = new HashSet<Booking>();
            Prices = new HashSet<PriceMoment>();
        }
        [Key]
        public int RoomId { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public byte Capacity { get; set; }
        [Display(Name = "Room number")]
        public int Number { get; set; }
        [Display(Name = "Minimal price")]
        public decimal MinimumPrice { get; set; }
        public virtual ICollection<PriceMoment> Prices { get; set; }

        public decimal CurrentPrice()
        {
            // Find all pricemoments where their timewindow is around now.
            DateTime now = new DateTime();
            IEnumerable<PriceMoment> inRange = Prices.Where(m => m.From < now && m.To > now);

            // When no time windows around now where found return the minimum price
            if (!inRange.Any())
            {
                return MinimumPrice;
            }

            // Find the window with the latest end date
            PriceMoment latest = inRange.OrderByDescending(m => m.To).First();
            return latest.Price;
        }

    }
}