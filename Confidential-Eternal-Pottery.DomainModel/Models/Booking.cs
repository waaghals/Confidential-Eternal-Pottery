using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ConfidentialEternalPottery.DomainModel.Models
{
    public class Booking
    {
        public Booking()
        {
            Addresses = new HashSet<Address>();
            Guests = new HashSet<Guest>();
        }
        [Key]
        public int BookingId { get; set; }
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }

        public virtual ICollection<Guest> Guests { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string Email { get; set; }

        public decimal Price { get; set; }
        public string BackAccount { get; set; }
    }
}
