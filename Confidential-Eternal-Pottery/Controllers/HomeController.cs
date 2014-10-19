using ConfidentialEternalPottery.Filters;
using ConfidentialEternalPottery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConfidentialEternalPottery.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            List<Room> room2;
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            using (var db = new HotelContext())
            {
                // BookRoom and save a new Blog 
                Room room = new Room() { Capacity = 3, Number = 20, MinimumPrice = (decimal) 100.00 };
                db.Rooms.Add(room);
                room2 = db.Rooms.ToList<Room>();
                ViewBag.Model = room2;
                db.SaveChanges();
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
