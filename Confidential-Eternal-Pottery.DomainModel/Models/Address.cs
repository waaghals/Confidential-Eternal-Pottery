using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ConfidentialEternalPottery.DomainModel.Models
{
    public class Address
    {

        public Address()
        {
            Bookings = new HashSet<Booking>();
        }

        public virtual ICollection<Booking> Bookings { get; set; }
        [Key]
        public int AddressId { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
    }
}
