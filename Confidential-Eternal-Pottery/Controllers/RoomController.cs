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
            ViewBag.Rooms = roomRepo.FindAll(null);
            return View();
        }

        public ActionResult Delete(int roomId)
        {
            roomRepo.DeleteById(roomId);
            return RedirectToAction("Index", "Room");
        }

        public ActionResult Update(int roomId)
        {

            ViewBag.Model = roomRepo.FindById(roomId);
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Room entity)
        {
            if (ModelState.IsValid)
            {
                roomRepo.Create(entity);
                return RedirectToAction("Index", "Room");
            }
            return View(entity);
        }

        [HttpPost]
        public ActionResult Update(Room entity)
        {
            if (ModelState.IsValid)
            {
                roomRepo.Update(entity);
                return RedirectToAction("Index", "Room");
            }
            ViewBag.Model = entity;
            return View(entity);
        }


    }
}
