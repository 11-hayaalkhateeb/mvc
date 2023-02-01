using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace task31_1.Controllers
{
    public class HayaController : Controller
    {
        // GET: Haya
        public ActionResult Index()
        {
            return View();
        }

        public string fname()
        {
            return ("haya");
        }
        public dynamic price()
        {
            return (20.5);
        }
        public string lname()
        {
            return ("alkhateeb");
        }
        public int age()
        {
            return (27);
        }

       
    }
}