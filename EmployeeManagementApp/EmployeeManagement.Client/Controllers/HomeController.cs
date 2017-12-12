using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagement.Client.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return PartialView();
        }

        public ActionResult Search()
        {
            return PartialView();
        }

        //public ActionResult Employee()
        //{
        //    return PartialView("Employee");
        //}

        public ActionResult Employee()
        {
            ViewBag.Message = "Your application description page.";

            return PartialView();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return PartialView();
        }
    }
}