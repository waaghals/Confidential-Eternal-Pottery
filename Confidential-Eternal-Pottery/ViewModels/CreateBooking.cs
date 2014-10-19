using ConfidentialEternalPottery.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConfidentialEternalPottery.ViewModels
{
    public class CreateBooking
    {
        public CreateBooking()
        {
            Guests = new List<GuestModel>();
        }

        public byte NumGuest { get; set; }
        public Room Room { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime From { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime To { get; set; }

        public IList<GuestModel> Guests { get; set; }
        [Required]
        public AddressModel Address { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public decimal Price { get; set; }
        [Required]
        public string BackAccount { get; set; }

        public Booking getBooking()
        {
            Booking booking = new Booking();
            booking.BillingAddress = Address.getAddress();
            booking.BillingAddress.Booking = booking;
            booking.Email = Email;
            booking.From = From;
            booking.To = To;
            booking.Room = Room;
            booking.Price = Room.CurrentPrice();
            
            foreach(GuestModel guest in Guests)
            {
                booking.Guests.Add(guest.getGuess());
            }

            return booking;
        }
    }
}