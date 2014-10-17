using System;
using System.Collections.Generic;
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
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public DateTime Dob { get; set; }

        public Genders Gender { get; set; }

        public Address Address { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}