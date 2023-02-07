using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_TASK_7_2.Models;

namespace MVC_TASK_7_2.Controllers
{
    public class IMAGEsController : Controller
    {
        private MVC7FEBEntities db = new MVC7FEBEntities();

        // GET: IMAGEs
        public ActionResult Index()
        {
            return View(db.IMAGES.ToList());
        }
        public ActionResult ss()
        {
            return View(db.IMAGES.ToList());
        }


        // GET: IMAGEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IMAGE iMAGE = db.IMAGES.Find(id);
            if (iMAGE == null)
            {
                return HttpNotFound();
            }
            return View(iMAGE);
        }

        // GET: IMAGEs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IMAGEs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,img")] IMAGE iMAGE)
        {
            if (ModelState.IsValid)
            {
                db.IMAGES.Add(iMAGE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(iMAGE);
        }

        // GET: IMAGEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IMAGE iMAGE = db.IMAGES.Find(id);
            if (iMAGE == null)
            {
                return HttpNotFound();
            }
            return View(iMAGE);
        }

        // POST: IMAGEs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,img")] IMAGE iMAGE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iMAGE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(iMAGE);
        }

        // GET: IMAGEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IMAGE iMAGE = db.IMAGES.Find(id);
            if (iMAGE == null)
            {
                return HttpNotFound();
            }
            return View(iMAGE);
        }

        // POST: IMAGEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IMAGE iMAGE = db.IMAGES.Find(id);
            db.IMAGES.Remove(iMAGE);
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
