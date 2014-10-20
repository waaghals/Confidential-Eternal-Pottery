using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ConfidentialEternalPottery.DomainModel.Models
{
    public class Guest
    {
        [Key]
        public int GuestId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Dob { get; set; }

        public Genders Gender { get; set; }

        public int BookingId { get; set; }
        public virtual Booking Booking { get; set; }
    }
}