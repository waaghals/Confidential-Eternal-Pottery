using ConfidentialEternalPottery.Filters;
using ConfidentialEternalPottery.DomainModel;
using ConfidentialEternalPottery.DomainModel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConfidentialEternalPottery.DomainModel.Models;
using ConfidentialEternalPottery.Repositories;

namespace ConfidentialEternalPottery.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HotelContext db = new HotelContext();
            IRoomRepository repo = new RoomRepository(db);

            List<Room> rooms = repo.FindAll();

            return View(rooms);
        }
    }
}
