using ConfidentialEternalPottery.DomainModel.Models;
using ConfidentialEternalPottery.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConfidentialEternalPottery.DomainModel.Repositories;
namespace ConfidentialEternalPottery.Controllers
{
    [Authorize]
    public class GuestController : Controller
    {
        private HotelContext db = new HotelContext();

        public ActionResult Edit(int id)
        {
            IGuestRepository repo = new GuestRepository(db);
            Guest guest = repo.FindById(id);

            if(guest == null)
            {
                return HttpNotFound();
            }

            return View(guest);
        }

        [HttpPost]
        public ActionResult Edit(Guest guest)
        {
            if (ModelState.IsValid)
            {
                IGuestRepository repo = new GuestRepository(db);
                repo.Update(guest);
                return RedirectToAction("GuestsForBooking", "Booking", new { id = guest.BookingId });
            }
            return View(guest);
        }

    }
}
