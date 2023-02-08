﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using logintestMVC.Models;

namespace logintestMVC.Controllers
{
    public class catsController : Controller
    {
        private MVC7FEBEntities db = new MVC7FEBEntities();

        // GET: cats
        public ActionResult Index()
        {
            return View(db.cats.ToList());
        }
        public ActionResult home_page1()
        {
            return View(db.cats.ToList());
        }
        [Authorize(Roles ="admin")]
        public ActionResult dashboard()
        {
            return View(db.cats.ToList());
        }

        public PartialViewResult cata()
        {
            var z = db.IMAGES.ToList();
            return PartialView("_images", z);
        }
        public ActionResult moreproudect1()
        {

            var z = db.IMAGES.ToList();
            return PartialView("_images", z);
        }
        
        //public PartialViewResult setionone()
        //{
        //    var z= db.IMAGES.ToList();
        //    return PartialView("_images", z);
        //}

        // GET: cats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cat cat = db.cats.Find(id);
            if (cat == null)
            {
                return HttpNotFound();
            }
            return View(cat);
        }

        // GET: cats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: cats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,img,description,price")] cat cat)
        {
            if (ModelState.IsValid)
            {
                db.cats.Add(cat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cat);
        }

        // GET: cats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cat cat = db.cats.Find(id);
            if (cat == null)
            {
                return HttpNotFound();
            }
            return View(cat);
        }

        // POST: cats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,img,description,price")] cat cat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cat);
        }

        // GET: cats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cat cat = db.cats.Find(id);
            if (cat == null)
            {
                return HttpNotFound();
            }
            return View(cat);
        }

        // POST: cats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cat cat = db.cats.Find(id);
            db.cats.Remove(cat);
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
