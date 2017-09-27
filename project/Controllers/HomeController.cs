
using Project.Models;
using Projects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Student model)
        {
            var a= new StudentContext();

            if (string.IsNullOrEmpty(model.StudentName))
            {
                ModelState.AddModelError("Student_Name", "Name is required");
            }
            if (string.IsNullOrEmpty(model.StudentAge))
            {
                ModelState.AddModelError("Student_Age", "Age is required");
            }
            if (string.IsNullOrEmpty(model.Email))
            {
                ModelState.AddModelError("Email", "Email is required");
            }
            if (string.IsNullOrEmpty(model.Qualification))
            {
                ModelState.AddModelError("Qualification", "This field is required");
            }
            if (ModelState.IsValid)
            {
                a.Students.Add(model);
                a.SaveChanges();
                return RedirectToAction("List");
            }
            return View();
        }

        public ActionResult List()
        {
            var a= new StudentContext();


            var st = from s in a.Students
                     select s;
            return View(st);
        }
    }
}