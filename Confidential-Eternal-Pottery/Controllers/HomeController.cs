using ConfidentialEternalPottery.Filters;
using ConfidentialEternalPottery.Models;
using ConfidentialEternalPottery.Repositories;
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
            HotelContext db = new HotelContext();
            IRoomRepository repo = new RoomRepository(db);

            List<Room> rooms = repo.FindAll();

            ViewBag.Model = rooms;
            return View();
        }
    }
}
