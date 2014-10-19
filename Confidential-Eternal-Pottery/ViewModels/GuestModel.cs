using ConfidentialEternalPottery.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConfidentialEternalPottery.ViewModels
{
    public class GuestModel
    {
        [Required]
        [Display(Name = "Firstname")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Lastname")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Birthday")]
        public DateTime Dob { get; set; }
        public Genders Gender { get; set; }

        internal Guest getGuest()
        {
            Guest guest = new Guest();
            guest.FirstName = FirstName;
            guest.LastName = LastName;
            guest.Dob = Dob;
            guest.Gender = Gender;

            return guest;
        }
    }
}