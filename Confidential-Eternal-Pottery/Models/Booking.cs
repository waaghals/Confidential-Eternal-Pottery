using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConfidentialEternalPottery.Models
{
    public class Booking
    {
        public Booking()
        {
            Guests = new HashSet<Guest>();
        }

        public int RoomId { get; set; }
        public virtual Room Room { get; set; }

        public int GuestId { get; set; }
        public virtual Guest Guest { get; set; }

        public int BillingAddressId { get; set; }
        public virtual Address BillingAddress { get; set; }

        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string Email { get; set; }


        public virtual ICollection<Guest> Guests { get; set; }
        public decimal Price { get; set; }
        public string BackAccount { get; set; }
    }
}
