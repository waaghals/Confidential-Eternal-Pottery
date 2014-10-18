using ConfidentialEternalPottery.Models;
using ConfidentialEternalPottery.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConfidentialEternalPottery.Controllers
{
    public class RoomController : Controller
    {
        //
        // GET: /Room/
        IRoomRepository roomRepo = new RoomRepository(new HotelContext());

        public ActionResult Index()
        {
            ViewBag.Rooms = roomRepo.getAll();
            return View();
        }
        [HttpPost]
        public ActionResult Delete(Room entity)
        {
            roomRepo.Delete(entity);
            return View();
        }

    }
}
