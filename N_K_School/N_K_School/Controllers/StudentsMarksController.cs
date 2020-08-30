using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using N_K_School.Models;
using System.Net;
using System.Data.Entity;
using Newtonsoft.Json;

namespace N_K_School.Controllers
{
    public class StudentsMarksController : Controller
    {
        private SchoolDbModel db = new SchoolDbModel();

        // GET: StudentsMarks
        public ActionResult Index(int? err)
        {
            if(err ==1)
            {
                ViewBag.Err = "Some Thing Went Wrong";
            }
            return View();
        }


        public ActionResult View_8th_Student_Marks(int? std, int? ExamNo)
        {
            var Students = db.Students.Where(x => (int)x.CurrentStandard == std).ToList();
            if(Students.Count() ==0)
            {
                return RedirectToAction("Index", new { err = 1 });
            }
            List<Std8_Marks> Marks = new List<Std8_Marks>();

            foreach (Student s in Students)
            {
                IEnumerable<Std8_Marks> mark = db.Std8_Marks.Where(x => x.ExamNo == ExamNo && x.StudentID == s.StudentID);
                if(mark.Count() != 0)
                {
                    Marks.Add(mark.Last());
                }
                
            }
            if (Marks.Count() == 0)
            {
                return RedirectToAction("Index", new { err = 1 });
            }

            return View(Marks);

        }

        public ActionResult View_9th_Student_Marks(int? std, int? ExamNo)
        {
            var Students = db.Students.Where(x => (int)x.CurrentStandard == std).ToList();
            if (Students.Count() == 0)
            {
                return RedirectToAction("Index", new { err = 1 });
            }
            List<Std9_Marks> Marks = new List<Std9_Marks>();

            foreach (Student s in Students)
            {
                IEnumerable<Std9_Marks> mark = db.Std9_Marks.Where(x => x.ExamNo == ExamNo && x.StudentID == s.StudentID);
                if (mark.Count() != 0)
                {
                    Marks.Add(mark.Last());
                }

            }
            if (Marks.Count() == 0)
            {
                return RedirectToAction("Index", new { err = 1 });
            }

            return View(Marks);

        }

        public ActionResult View_10th_Student_Marks(int? std, int? ExamNo)
        {
            var Students = db.Students.Where(x => (int)x.CurrentStandard == std).ToList();
            if (Students.Count() == 0)
            {
                return RedirectToAction("Index", new { err = 1 });
            }
            List<Std10_Marks> Marks = new List<Std10_Marks>();

            foreach (Student s in Students)
            {
                IEnumerable<Std10_Marks> mark = db.Std10_Marks.Where(x => x.ExamNo == ExamNo && x.StudentID == s.StudentID);
                if (mark.Count() != 0)
                {
                    Marks.Add(mark.Last());
                }

            }
            if (Marks.Count() == 0)
            {
                return RedirectToAction("Index", new { err = 1 });
            }

            return View(Marks);

        }

        public ActionResult Add_8th_Marks(int? std, int? ExamNo)
        {
            ViewBag.Students = db.Students.Where(x => (int)x.CurrentStandard == std).ToList();
            ViewBag.ExamNo = ExamNo;
            return View();
        }

        [HttpPost]
        public ActionResult Add_8th_Marks(List<Std8_Marks> list, int ExamNo)
        {
            List<int> SIds = new List<int>();
            foreach (var i in list)
            {
                db.Std8_Marks.Add(i);
                SIds.Add(i.StudentID);
            }
            db.SaveChanges();
            return RedirectToAction("Std8_MarksList", new { ExamNo = ExamNo, SIds = JsonConvert.SerializeObject(SIds.ToList()) });
        }

        public ActionResult Std8_MarksList(int? ExamNo, string SIds)
        {
            if (ExamNo == null)
            {
                return HttpNotFound("ExamNo");
            }
            if (SIds != null)
            {
                List<int> StudentIds = JsonConvert.DeserializeObject<List<int>>(SIds);
                ViewBag.SIds = SIds;

                List<Std8_Marks> Marks = new List<Std8_Marks>();
                foreach (var i in StudentIds)
                {
                    IEnumerable<Std8_Marks> mark = db.Std8_Marks.Where(x => x.ExamNo == ExamNo && x.StudentID == i);
                    Marks.Add(mark.Last());
                }

                return View(Marks);
            }
            else
            {
                //return HttpNotFound("SIds is Empty");
                return View(db.Std8_Marks.ToList());
            }

        }

        public ActionResult Edit_8th_Marks(int? id, string SIds)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.SIds = SIds;
            Std8_Marks marks = db.Std8_Marks.Find(id);
            if (marks == null)
            {

                return HttpNotFound();
            }
            return View(marks);
        }

        [HttpPost]
        public ActionResult Edit_8th_Marks(Std8_Marks marks, int ExamNo, string SIds)
        {
            if (ModelState.IsValid)
            {
                db.Entry(marks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Std8_MarksList", new { ExamNo = ExamNo, SIds = SIds });
            }
            return View();
        }

        public ActionResult Add_9th_Marks(int? std, int? ExamNo)
        {
            ViewBag.Students = db.Students.Where(x => (int)x.CurrentStandard == std).ToList();
            ViewBag.ExamNo = ExamNo;
            return View();
        }

        [HttpPost]
        public ActionResult Add_9th_Marks(List<Std9_Marks> list, int ExamNo)
        {
            List<int> SIds = new List<int>();
            foreach (var i in list)
            {
                db.Std9_Marks.Add(i);
                SIds.Add(i.StudentID);
            }
            db.SaveChanges();
            return RedirectToAction("Std9_MarksList", new { ExamNo = ExamNo, SIds = JsonConvert.SerializeObject(SIds.ToList()) });
        }

        public ActionResult Std9_MarksList(int? ExamNo, string SIds)
        {
            if (ExamNo == null)
            {
                return HttpNotFound("ExamNo");
            }
            if (SIds != null)
            {
                List<int> StudentIds = JsonConvert.DeserializeObject<List<int>>(SIds);
                ViewBag.SIds = SIds;

                List<Std9_Marks> Marks = new List<Std9_Marks>();
                foreach (var i in StudentIds)
                {
                    IEnumerable<Std9_Marks> mark = db.Std9_Marks.Where(x => x.ExamNo == ExamNo && x.StudentID == i);
                    Marks.Add(mark.Last());
                }

                return View(Marks);
            }
            else
            {
                //return HttpNotFound("SIds is Empty");
                return View(db.Std9_Marks.ToList());
            }
        }

        public ActionResult Edit_9th_Marks(int? id, string SIds)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.SIds = SIds;
            Std9_Marks marks = db.Std9_Marks.Find(id);
            if (marks == null)
            {
                return HttpNotFound();
            }
            return View(marks);
        }

        [HttpPost]
        public ActionResult Edit_9th_Marks(Std9_Marks marks, int ExamNo, string SIds)
        {
            if (ModelState.IsValid)
            {
                db.Entry(marks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Std9_MarksList", new { ExamNo = ExamNo, SIds = SIds });
            }
            return View();
        }

        public ActionResult Add_10th_Marks(int? std, int? ExamNo)
        {
            ViewBag.Students = db.Students.Where(x => (int)x.CurrentStandard == std).ToList();
            ViewBag.ExamNo = ExamNo;
            return View();
        }

        [HttpPost]
        public ActionResult Add_10th_Marks(List<Std10_Marks> list, int ExamNo)
        {
            List<int> SIds = new List<int>();
            foreach (var i in list)
            {
                db.Std10_Marks.Add(i);
                SIds.Add(i.StudentID);
            }
            db.SaveChanges();
            return RedirectToAction("Std10_MarksList", new { ExamNo = ExamNo, SIds = JsonConvert.SerializeObject(SIds.ToList()) });
        }

        public ActionResult Std10_MarksList(int? ExamNo, string SIds)
        {
            if (ExamNo == null)
            {
                return HttpNotFound("ExamNo");
            }
            if (SIds != null)
            {
                List<int> StudentIds = JsonConvert.DeserializeObject<List<int>>(SIds);
                ViewBag.SIds = SIds;

                List<Std10_Marks> Marks = new List<Std10_Marks>();
                foreach (var i in StudentIds)
                {
                    IEnumerable<Std10_Marks> mark = db.Std10_Marks.Where(x => x.ExamNo == ExamNo && x.StudentID == i);
                    Marks.Add(mark.Last());
                }

                return View(Marks);
            }
            else
            {
                //return HttpNotFound("SIds is Empty");
                return View(db.Std10_Marks.ToList());
            }
        }

        public ActionResult Edit_10th_Marks(int? id, string SIds)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.SIds = SIds;
            Std10_Marks marks = db.Std10_Marks.Find(id);
            if (marks == null)
            {
                return HttpNotFound();
            }
            return View(marks);
        }

        [HttpPost]
        public ActionResult Edit_10th_Marks(Std10_Marks marks, int ExamNo, string SIds)
        {
            if (ModelState.IsValid)
            {
                db.Entry(marks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Std10_MarksList", new { ExamNo = ExamNo, SIds = SIds });
            }
            return View();
        }
    }
}