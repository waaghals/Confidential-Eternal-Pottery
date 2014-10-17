using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConfidentialEternalPottery.Models
{
    public class PriceMoment
    {
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }

        public decimal Price { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }
    }
}
