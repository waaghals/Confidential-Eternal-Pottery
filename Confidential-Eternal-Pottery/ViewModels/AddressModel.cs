using ConfidentialEternalPottery.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConfidentialEternalPottery.ViewModels
{



    public class AddressModel
    {
        private Address address;
        public AddressModel()
        {
            address = new Address();
        }

        public AddressModel(Address Address)
        {
            address = Address;
        }

        [Required]
        public string Street { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Zip { get; set; }

        internal Address getAddress()
        {
            address.Street = Street;
            address.Number = Number;
            address.Zip = Zip;
            address.City = City;
            return address;
        }
    }
}