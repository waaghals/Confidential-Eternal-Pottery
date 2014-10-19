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
using System.Collections;

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
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(new CreateBooking() { Room = room, Price = room.CurrentPrice() });

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddGuests(CreateBooking booking)
        {
            Session["CurrentGuest"] = 0;
            Session["booking"] = booking;
            GuestModel guest = new GuestModel();
            return View(guest);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddGuest(GuestModel guest)
        {
            CreateBooking booking = (CreateBooking)Session["booking"];
            booking.Guests.Add(guest);
            Session["booking"] = booking;

            if (((int)Session["CurrentGuest"] + 1) >= booking.NumGuest)
            {
                return RedirectToAction("ViewBooking");
            }
            Session["CurrentGuest"] = (int)Session["CurrentGuest"] + 1;

            return View(new GuestModel());
        }

        public ActionResult ViewBooking()
        {
            CreateBooking booking = (CreateBooking)Session["booking"];
            return View(booking);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Confirm(CreateBooking entity)
        {
            CreateBooking booking = (CreateBooking)Session["booking"];
            booking.BankAccount = entity.BankAccount;
            Booking realBooking = booking.getBooking();

            //Set the room from the room id
            IRoomRepository repo = new RoomRepository(db);
            Room room = repo.FindById(booking.Room.RoomId);
            booking.Room = room;

            IBookingRepository bookingRepo = new BookingRepository(db);
            bookingRepo.Create(realBooking);
            db.Entry<Booking>(realBooking).State = EntityState.Added;
            foreach (GuestModel guest in booking.Guests)
            {
                var realGuest = guest.getGuest();
                realGuest.Booking = realBooking;
                db.Guest.Add(realGuest);
                db.Entry<Guest>(realGuest).State = EntityState.Added;
            }
            db.Addresses.Add(realBooking.BillingAddress);
            db.SaveChanges();
            return RedirectToAction("Index");

            // return View(booking);
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