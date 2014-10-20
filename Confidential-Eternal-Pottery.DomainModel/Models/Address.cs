using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ConfidentialEternalPottery.DomainModel.Models
{
    public class Address
    {

        [Key, ForeignKey("Booking")]
        public int AddressId { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }

        public int BookingId { get; set; }
        public virtual Booking Booking { get; set; }
    }
}
