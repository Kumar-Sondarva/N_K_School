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
    public class TeacherSubjectsController : Controller
    {
        private SchoolDbModel db = new SchoolDbModel();
        // GET: TeacherSubjects
        public ActionResult Index()
        {
            var TeacherSubject = db.TeacherSubjects.Include(t => t.Teacher).Include(s => s.Subject);
            TeacherSubject = TeacherSubject.OrderBy(ts => ts.Subject.SubjectName);


            return View(TeacherSubject.ToList());
        }

        public ActionResult RemoveTeacherSubject(int? t,int? s)
        {
            if(t == null || s == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //TeacherSubject ts = db.TeacherSubjects.Where(x => (x.TeacherID == t) || (x.SubjectID == s));
            TeacherSubject ts = db.TeacherSubjects.Find(t, s);
            if(ts == null)
            {
                return HttpNotFound();
            }
            db.Entry(ts).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AddTeacherSubject()
        {
            ViewBag.TeacherID = new SelectList(db.Teachers, "TeacherId","FirstName");
            ViewBag.Subjects = db.Subjects;
            return View();
        }

        [HttpPost]
        public ActionResult AddTeacherSubject(int TeacherID,int?[] SubjectIDS)
        {
            if (SubjectIDS == null)
            {
                ViewBag.TeacherID = new SelectList(db.Teachers, "TeacherId", "FirstName");
                ViewBag.Subjects = db.Subjects;
                return View();
            }
            foreach (int SubjectID in SubjectIDS)
            {
                var temp = db.TeacherSubjects.Where(x => (x.TeacherID == TeacherID && x.SubjectID == SubjectID));
                if(temp.ToList().Count() == 0)
                {
                    TeacherSubject ts = new TeacherSubject();
                    ts.SubjectID = SubjectID;
                    ts.TeacherID = TeacherID;
                    if (ModelState.IsValid)
                    {
                        db.TeacherSubjects.Add(ts);
                        db.SaveChanges();
                    }
                }
                
                
            }
            return RedirectToAction("Index");
        }
    }
}