using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mvctask5_2.Models;
using System.IO;

namespace mvctask5_2.Controllers
{
    public class EMPLsController : Controller
    {
        private mvctaskEntities db = new mvctaskEntities();

        // GET: EMPLs
        public ActionResult Index()
        {
            return View(db.EMPLs.ToList());
        }
        // public ActionResult search(string plece_enter_name)
        //{
        //   var Employees = db.Employees.Where(o =>o.first_name.StartsWith(plece_enter_name));
        //    return View("Index",Employees.ToList());
        //}

        public ActionResult search(string plece_enter_name, string searchBy)
        {
            if (searchBy == "first_name")
                return View("Index",db.EMPLs.Where(x => x.first_name == plece_enter_name || plece_enter_name == null).ToList());
            else if (searchBy == "last_name")
                return View("Index" ,db.EMPLs.Where(x => x.last_name == plece_enter_name || plece_enter_name == null).ToList());
            else
                return View("Index" ,db.EMPLs.Where(x => x.email.StartsWith(plece_enter_name) || plece_enter_name == null).ToList());

            //return View("Index", Employees.ToList());
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
        public ActionResult Create(EMPL eMPL, HttpPostedFileBase imgfile, HttpPostedFileBase cv)
        {

            if (ModelState.IsValid)
            {
                if (imgfile != null)
                {
                    //string fileName = Path.GetFileName(image.FileName);
                    string path = Server.MapPath("~/images/") + imgfile.FileName;
                    imgfile.SaveAs(path);
                    eMPL.img = imgfile.FileName;
                }

                if (cv != null)
                {
                    //string fileName = Path.GetFileName(cv.FileName);
                    string path = Server.MapPath("~/CV/") + cv.FileName;
                    cv.SaveAs(path);
                    eMPL.cv= cv.FileName;
                }
                db.EMPLs.Add(eMPL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eMPL);
            //if (ModelState.IsValid)
            //{
            //    string path = "";
            //    if (imgfile.FileName .Length > 0)
            //    {
            //        //path = "~/images/" + Path.GetFileName(imgfile.FileName);
            //        path = Path.GetFileName(imgfile.FileName);

            //        //path = "/images/"+ path.GetFileName(imgfile.FileName);
            //        //imgfile.SaveAs(Server.MapPath(path));
            //        imgfile.SaveAs(Path.Combine(Server.MapPath("~/images/"), imgfile.FileName));

            //    }
            //    eMPL.img = path;
            //    db.EMPLs.Add(eMPL);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //return View(eMPL);
        }

        public FileResult Download(string CV)
        {
            string name = "../CV/" + CV;
            string path = Server.MapPath(name);
            byte[] fileBytes = System.IO.File.ReadAllBytes(path);
            return File(fileBytes, "application.pdf", CV);

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
