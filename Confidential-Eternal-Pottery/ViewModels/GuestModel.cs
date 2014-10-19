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
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }
   
        public Genders Gender { get; set; }

        internal Guest getGuess()
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