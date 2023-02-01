using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace task31_1.Controllers
{
    public class aboutController : Controller
    {
        // GET: about
        public ActionResult Index()
        {
            return View();
        }
        public string about()
        {
            return ("haya");
        }

        public string contact()
        {
            return ("alkhateeb");
        }
        public ActionResult img() {
            string path = Server.MapPath("~/img/1.jpg");
            byte[] imageByteData = System.IO.File.ReadAllBytes(path);
            return File(imageByteData, "image/png" , "1.jpg");

        }

        public ActionResult Image()
        {
            return Content("<a href='/img/1.jpg' download><img src='..\\img\\1.jpg' width='500'><a>");

        }
        public string aa()
        {
            return ("<a href='https://localhost:44349/about/Download/'><img src='img/1.jpg'/></a>");


        }


        public FileResult Download()
        {
            var path = Server.MapPath("~/img/1.jpg");
            return File(path, "jpg", "1.jpg");

        }

    }
}