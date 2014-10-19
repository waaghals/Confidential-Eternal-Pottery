﻿using ConfidentialEternalPottery.Models;
using ConfidentialEternalPottery.ViewModels;
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
            return View(roomRepo.FindAll(null));
        }
        [HttpGet]
        public ActionResult Delete(int roomId)
        {
            return View(roomRepo.FindById(roomId));
        }

        public ActionResult Update(int roomId)
        {
            ViewBag.Model = roomRepo.FindById(roomId);
            return View();
        }

        public ActionResult Create()
        {
            return View(new CreateRoom());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Room room)
        {
            roomRepo.DeleteById(room.RoomId);
            return RedirectToAction("Index", "Room");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
