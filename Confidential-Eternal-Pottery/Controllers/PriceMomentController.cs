using ConfidentialEternalPottery.Filters;
using ConfidentialEternalPottery.Models;
using ConfidentialEternalPottery.Repositories;
using ConfidentialEternalPottery.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConfidentialEternalPottery.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
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
            return View(roomRepo.FindById(roomId));
        }

        public ActionResult Delete(int priceMomentId, int roomId)
        {
            roomRepo.RemovePriceMomentById(priceMomentId, roomId);
            return RedirectToAction("Index", "PriceMoment", new { roomId = roomId });
        }

        public ActionResult Update(int priceMomentId)
        {
            PriceMoment entity = priceMomentRepo.FindById(priceMomentId);
            // Everything IS set here
            return View(entity);
        }

        public ActionResult Create(int roomId)
        {
            Room entity = roomRepo.FindById(roomId);
            return View(new CreatePriceMoment(entity));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(PriceMoment entity)
        {
            // This doesn't get called
            Room room = roomRepo.FindById(entity.RoomId);
            entity.Room = room;
            if (ModelState.IsValid)
            {
                roomRepo.Update(room);
                priceMomentRepo.Update(entity);
                return RedirectToAction("Index", "PriceMoment", new { roomId = entity.RoomId });
            }
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreatePriceMoment entity)
        {
            PriceMoment moment = entity.getPriceMoment();
            Room room = roomRepo.FindById(entity.RoomId);
            moment.Room = room;
            if (ModelState.IsValid && this.TryValidateModel(moment))
            {
                moment.Room = room;
                room.Prices.Add(moment);
                roomRepo.Update(room);
                return RedirectToAction("Index", "PriceMoment", new { roomId = moment.Room.RoomId });
            }
            entity.Room = room;
            return View(entity);
        }
    }
}
