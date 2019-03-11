using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc1.Models;



namespace mvc1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
            
        {
            Student st = new Student();
            st.Id = 100;
            st.Name = "Roshan";
            st.Address = "Copenhagen";
            st.Phone = 12345678;
            st.Age = 56;
            return View(st);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}