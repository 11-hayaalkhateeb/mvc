﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using task6_2.Models;

namespace task6_2.Controllers
{
    public class EMPLsController : Controller
    {
        private mvctaskEntities1 db = new mvctaskEntities1();

        // GET: EMPLs
        public ActionResult Index()
        {
            return View(db.EMPLs.ToList());
        }
        public PartialViewResult last()
        {
            var order =db.Orders.OrderByDescending(x => x.orderdate).First();
             return PartialView("_Order" ,order);
        }

        // GET: EMPLs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPL eMPL = db.EMPLs.Find(id);
            if (eMPL == null)
            {
                return HttpNotFound();
            }
            return View(eMPL);
        }

        // GET: EMPLs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EMPLs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,first_name,last_name,email,phone,age,jop_title,gender,img,cv")] EMPL eMPL)
        {
            if (ModelState.IsValid)
            {
                db.EMPLs.Add(eMPL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eMPL);
        }

        // GET: EMPLs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPL eMPL = db.EMPLs.Find(id);
            if (eMPL == null)
            {
                return HttpNotFound();
            }
            return View(eMPL);
        }

        // POST: EMPLs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,first_name,last_name,email,phone,age,jop_title,gender,img,cv")] EMPL eMPL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eMPL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eMPL);
        }

        // GET: EMPLs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPL eMPL = db.EMPLs.Find(id);
            if (eMPL == null)
            {
                return HttpNotFound();
            }
            return View(eMPL);
        }

        // POST: EMPLs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EMPL eMPL = db.EMPLs.Find(id);
            db.EMPLs.Remove(eMPL);
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
