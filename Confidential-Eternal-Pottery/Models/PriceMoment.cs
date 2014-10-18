﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ConfidentialEternalPottery.Models
{
    public class PriceMoment : IValidatableObject
    {
        [Key]
        public int PriceMomentId { get; set; }
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime From { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime To { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Price < 0)
            {
                yield return new ValidationResult("Price has to be positve.", new[] { "Price" });
            }
            if (To < From)
            {
                yield return new ValidationResult("To has to be after From", new[] { "To" });
            }
            if (From > To)
            {
                yield return new ValidationResult("From has to be before To", new[] { "From" });
            }
            if (To < DateTime.Now)
            {
                yield return new ValidationResult("To can't be in the past", new[] { "To" });
            }
            if (To == From)
            {
                yield return new ValidationResult("To and FROM can't be on the same day", new[] { "To", "From" });
            }
        }
    }
}
