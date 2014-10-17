using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConfidentialEternalPottery.Models
{
    public class Address
    {

        public Address()
        {
            Bookings = new HashSet<Booking>();
        }

        public virtual ICollection<Booking> Bookings { get; set; }
        public int AddressId { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
    }
}
