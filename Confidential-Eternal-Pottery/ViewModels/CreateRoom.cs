using ConfidentialEternalPottery.DomainModel;
using ConfidentialEternalPottery.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConfidentialEternalPottery.ViewModels
{
    public class CreateRoom
    {
        public CreateRoom()
        {
            Bookings = new HashSet<Booking>();
            Prices = new HashSet<PriceMoment>();
        }
        [Key]
        public int RoomId { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        [Required]

        public byte Capacity { get; set; }
        [Required]

        public int Number { get; set; }
        [Required]

        public decimal MinimumPrice { get; set; }
        public virtual ICollection<PriceMoment> Prices { get; set; }

        public Room getRoom()
        {
            Room room = new Room();
            room.Number = Number;
            room.Capacity = Capacity;
            room.MinimumPrice = MinimumPrice;
            foreach (PriceMoment moment in Prices)
            {
                room.Prices.Add(moment);
            }
            return room;
        }

    }
}