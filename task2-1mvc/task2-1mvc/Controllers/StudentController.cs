using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using task2_1mvc.Models;

namespace task2_1mvc.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            List<Student> st = new List<Student>();
            st.Add(new Student { id = 1, Name = "haya", Major = "mis", Faculity = "zzz" });
            st.Add(new Student { id = 2, Name = "lujain", Major = "cis", Faculity = "zzz" });
            st.Add(new Student { id = 3, Name = "rama", Major = "bf", Faculity = "zzz" });
            st.Add(new Student { id = 4, Name = "rahma", Major = "software enginering", Faculity = "zzz" });
            st.Add(new Student { id = 5, Name = "batool", Major = "", Faculity = "zzz" });
            st.Add(new Student { id = 6, Name = "ayah", Major = "", Faculity = "zzz" });


            return View(st);
        }
    }
}