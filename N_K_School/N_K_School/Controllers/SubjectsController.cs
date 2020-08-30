using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;
using N_K_School.Models;
using N_K_School.CustomFilters;

namespace N_K_School.Controllers
{
    [AuthLog(Roles = "Principal")]
    public class SubjectsController : Controller
    {
        private SchoolDbModel db = new SchoolDbModel();

        // GET: Subjects
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SubjectList()
        {
            return View(db.Subjects.ToList());
        }
        public ActionResult AddSubject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSubject(Subject s)
        {
            if(ModelState.IsValid)
            {
                db.Subjects.Add(s);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }
    }
}