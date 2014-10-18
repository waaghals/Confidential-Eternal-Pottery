using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ConfidentialEternalPottery.Models
{
    public class PriceMoment
    {
        [Key]
        public int PriceMomentId { get; set; }
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }

        public decimal Price { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }
    }
}
