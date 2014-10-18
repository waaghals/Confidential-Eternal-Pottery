using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConfidentialEternalPottery.Models
{
    public class Guest
    {
        public Guest()
        {
            Bookings = new HashSet<Booking>();
        }

        [Key]
        public int GuestId { get; set; }
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public DateTime Dob { get; set; }

        public Genders Gender { get; set; }

        public Address Address { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}