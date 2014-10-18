using ConfidentialEternalPottery.Models;
using ConfidentialEternalPottery.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConfidentialEternalPottery.Controllers
{
    public class PriceMomentController : Controller
    {
        //
        // GET: /PriceMoment/
        IRoomRepository roomRepo;
        IPriceMomentRepository priceMomentRepo;
        public PriceMomentController()
        {
            HotelContext context = new HotelContext();
            priceMomentRepo = new PriceMomentRepository(context);
            roomRepo = new RoomRepository(context);
        }
        public ActionResult Index(int roomId)
        {
            ViewBag.Model = roomRepo.FindById(roomId);
            return View();
        }

        public ActionResult Delete(int priceMomentId, int roomId)
        {
            roomRepo.RemovePriceMomentById(priceMomentId, roomId);
            return RedirectToAction("Index", "PriceMoment", new { roomId = roomId });
        }

        public ActionResult Update(int priceMomentId)
        {
            PriceMoment entity = priceMomentRepo.FindById(priceMomentId);
            ViewBag.Model = entity;

            // todo
            return View(entity);
        }

        public ActionResult Create(int roomId)
        {
            Room entity = roomRepo.FindById(roomId);
            PriceMoment moment = new PriceMoment();
            ViewBag.Model = entity;
            moment.Room = entity;
            return View(moment);
        }

        [HttpPost]
        public ActionResult Update(PriceMoment entity)
        {
            if (ModelState.IsValid)
            {
                Room room = roomRepo.FindById(entity.RoomId);
                roomRepo.Update(room);
                entity.Room = room;
                priceMomentRepo.Update(entity);
                return RedirectToAction("Index", "PriceMoment", new { roomId = entity.RoomId});
            }
            ViewBag.Model = entity;
            return View(entity);
        }

        [HttpPost]
        public ActionResult Create(PriceMoment entity)
        {
            if (ModelState.IsValid)
            {
                Room room = roomRepo.FindById(entity.RoomId);
                room.Prices.Add(entity);
                roomRepo.Update(room);
                return RedirectToAction("Index", "PriceMoment", new { roomId = entity.Room.RoomId });
            }
            ViewBag.Model = entity;
            return View(entity);
        }
    }
}
