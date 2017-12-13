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
            ViewBag.Title = "Search";
            ViewBag.Message = "Please search for an employee.";

            return PartialView();
        }

        public ActionResult Employee()
        {
            ViewBag.Title = "Employee";
            ViewBag.Message = "Add Employee Information Application page";

            return PartialView();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return PartialView();
        }
    }
}