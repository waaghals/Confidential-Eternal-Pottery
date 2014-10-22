using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConfidentialEternalPottery.DomainModel.Models
{
    public class Room : IValidatableObject
    {
        public Room()
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
        [Display(Name = "Room number")]
        public int Number { get; set; }
        [Required]
        [Display(Name = "Minimal price")]        public decimal MinimumPrice { get; set; }
        public virtual ICollection<PriceMoment> Prices { get; set; }

        public decimal Price { get { return CurrentPrice(); } }
        public decimal CurrentPrice()
        {
            // Find all pricemoments where their timewindow is around date.
            return PriceOnDate(DateTime.Now);
        }

        public decimal PriceOnDate(DateTime date)
        {
            // Find all pricemoments where their timewindow is around date.
            IEnumerable<PriceMoment> inRange = Prices.Where(m => (m.From - date).TotalDays < 1 && (m.To - date).TotalDays > 1);

            // When no time windows around date where found return the minimum price
            if (!inRange.Any())
            {
                return MinimumPrice;
            }

            // Find the window with the latest end date
            PriceMoment latest = inRange.OrderByDescending(m => m.To).First();
            return latest.Price;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Number < 0 && Number > 255)
            {
                yield return new ValidationResult("Number has to be between 0 and 1000", new[] { "Number" });
            }
            if (MinimumPrice < 0)
            {
                yield return new ValidationResult("MinimumPrice has to be positve.", new[] { "MiniumPrice" });
            }
            if (!(Capacity == 2 || Capacity == 3 || Capacity == 5))
            {
                yield return new ValidationResult("Capacity can only be 2, 3 or 5.", new[] { "Capacity" });
            }
        }
    }
}