using ConfidentialEternalPottery.DomainModel.Models;
using ConfidentialEternalPottery.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConfidentialEternalPottery.ViewModels
{
    public class CreatePriceMoment
    {
        public CreatePriceMoment(Room entity)
        {
            From = DateTime.Now.Date;
            To = DateTime.Now.Date.AddDays(1);
            Room = entity;
            Price = Room.MinimumPrice;
        }
        public CreatePriceMoment() { }
        [Key]
        public int PriceMomentId { get; set; }
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime From { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime To { get; set; }

        public PriceMoment getPriceMoment()
        {
            PriceMoment moment = new PriceMoment();
            moment.From = From;
            moment.To = To;
            moment.Price = Price;
            moment.Room = Room;
            moment.RoomId = RoomId;
            return moment;
        }
    }
}