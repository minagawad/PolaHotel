﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PolaHotel.Models;

namespace PolaHotel.Controllers
{
    public class Room_CategoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Room_Category
        public ActionResult Index()
        {
            return View(db.Room_Categories.ToList());
        }

        // GET: Room_Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room_Category room_Category = db.Room_Categories.Find(id);
            if (room_Category == null)
            {
                return HttpNotFound();
            }
            return View(room_Category);
        }

        // GET: Room_Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Room_Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Category_Name")] Room_Category room_Category)
        {
            if (ModelState.IsValid)
            {
                db.Room_Categories.Add(room_Category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(room_Category);
        }

        // GET: Room_Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room_Category room_Category = db.Room_Categories.Find(id);
            if (room_Category == null)
            {
                return HttpNotFound();
            }
            return View(room_Category);
        }

        // POST: Room_Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Category_Name")] Room_Category room_Category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(room_Category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(room_Category);
        }

        // GET: Room_Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room_Category room_Category = db.Room_Categories.Find(id);
            if (room_Category == null)
            {
                return HttpNotFound();
            }
            return View(room_Category);
        }

        // POST: Room_Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Room_Category room_Category = db.Room_Categories.Find(id);
            db.Room_Categories.Remove(room_Category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
