using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConfidentialEternalPottery.Models;
using ConfidentialEternalPottery.ViewModels;
using ConfidentialEternalPottery.Repositories;

namespace ConfidentialEternalPottery.Controllers
{
    public class BookingController : Controller
    {
        private HotelContext db = new HotelContext();

        public ActionResult Index()
        {
            var bookings = db.Bookings.Include(b => b.Room);
            return View(bookings.ToList());
        }

        public ActionResult Details(int id = 0)
        {
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }


        public ActionResult SetDate(int id)
        {
            IRoomRepository repo = new RoomRepository(db);
            Room room = repo.FindById(id);
            if(room == null)
            {
                return HttpNotFound();
            }
            return View(new CreateBooking() { Room = room });
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddGuests(CreateBooking booking)
        {
            Session["booking"] = booking;
            return View(Session["booking"]);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult View(CreateBooking booking)
        {
            Session["booking"] = booking;
            return View(Session["booking"]);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Confirm(CreateBooking booking)
        {
            if (ModelState.IsValid)
            {
                db.Bookings.Add(booking.getBooking());
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(booking);
        }

        public ActionResult Edit(int id = 0)
        {
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoomId = new SelectList(db.Rooms, "RoomId", "RoomId", booking.RoomId);
            return View(booking);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoomId = new SelectList(db.Rooms, "RoomId", "RoomId", booking.RoomId);
            return View(booking);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}