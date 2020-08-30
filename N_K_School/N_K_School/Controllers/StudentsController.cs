using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;
using N_K_School.Models;
using N_K_School.CustomFilters;
using iTextSharp.text;
using iTextSharp.text.pdf;
namespace N_K_School.Controllers
{
    
    public class StudentsController : Controller
    {
        private SchoolDbModel db = new SchoolDbModel();
        // GET: Students
        [AuthLog(Roles = "Clerk")]
        public ActionResult Index()
        {
            return View();
        }

        [AuthLog(Roles = "Clerk")]
        public ActionResult StudentDetails(int? stid)
        {
            if (stid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student st = db.Students.Find(stid);
            if(st == null)
            {
                return HttpNotFound();
            }
            return View(st);
        }

        [AuthLog(Roles = "Clerk")]
        public ActionResult StudentEdit(int? stid)
        {
            if (stid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student st = db.Students.Find(stid);
            if (st == null)
            {
                return HttpNotFound();
            }

            return View(st);
        }

        [AuthLog(Roles = "Clerk")]
        [HttpPost]
        public ActionResult StudentEdit(Student st)
        {
            if(ModelState.IsValid)
            {
                db.Entry(st).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("StudentDetails","Students",new { stid = st.StudentID});
            }
            return View();
        }

        [AuthLog(Roles = "Clerk")]
        public ActionResult StudentList(int? sid)
        {
            if(sid == null)
            {
                return Content("sid null");
            }

            var list = db.Students.Where(x => (int)x.CurrentStandard == sid);
            return View(list.ToList());
        }

        [AuthLog(Roles = "Clerk")]
        public ActionResult AddStudent()
        {
            return View();
        }

        [AuthLog(Roles = "Clerk")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddStudent(Student st)
        {
            st.CurrentStandard = st.EnteredStandard;
            st.DateOfAdmission = DateTime.Now.Date.ToString();
            
            //db.Students.Add(st);
            //db.SaveChanges();
            if (ModelState.IsValid)
            {
                db.Students.Add(st);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            return View();
        }

        /// <summary>
        /// //////////
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewResult(int? err)
        {
            if(err == 1)
            {
                ViewBag.Err = "Something went Wrong";
            }
            return View();
        }

        [HttpPost]
        public ActionResult ShowResult(int StudentId, Standard Standard, ExamNo ExamNo)
        {
            //Student st = db.Students.Find(StudentId);
            //ViewBag.student = st;
            // int exn=0;
            //if(ExamNo == ExamNo.First_Exam)
            // {
            //     exn = 1;
            // }
            //else if(ExamNo == ExamNo.Second_Exam)
            // {
            //     exn = 2;
            // }
            // else
            // {
            //     exn = 3;
            // }
            if (Standard == Standard.Standard_8th)
            {
                return RedirectToAction("View_8th_Marks", new { sid = StudentId, ExamNo = ExamNo.ToString() });
            }
            else if (Standard == Standard.Standard_9th)
            {
                return RedirectToAction("View_9th_Marks", new { sid = StudentId, ExamNo = ExamNo.ToString() });
            }
            else if (Standard == Standard.Standard_10th)
            {
                return RedirectToAction("View_10th_Marks", new { sid = StudentId, ExamNo = ExamNo.ToString() });
            }
            return View();
        }

        public ActionResult View_8th_Marks(int sid, ExamNo ExamNo)
        {
            ViewBag.ExamNo = ExamNo;
            Student st = db.Students.Find(sid);
            if (st == null)
            {
                return RedirectToAction("ViewResult", new { err = 1 });
            }
            ViewBag.student = st;
            int ex = (int)ExamNo;
            var marks = db.Std8_Marks.Where(x => (x.StudentID == sid) && (x.ExamNo == ex)).ToList();
            // Console.WriteLine("marks"+marks);
            //Console.ReadLine();
            if (marks.Count() == 0)
            {
                return RedirectToAction("ViewResult",new { err = 1 });
            }
            return View(marks.Last());
        }

        [HttpPost]
        public ActionResult View_8th_Marks(int? SId, Std8_Marks mark)
        {
            if (SId == null)
            {
                return HttpNotFound("Sid not Found " + mark.Std8Id);
            }

            Student st = db.Students.Find(SId);
            Std8_Marks marks = db.Std8_Marks.Find(mark.Std8Id);

            Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 15);
            PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            PdfPTable table = new PdfPTable(2);
            table.WidthPercentage = 100;
            table.HorizontalAlignment = 0;
            table.SpacingBefore = 20f;
            table.SpacingAfter = 30f;

            table.AddCell("Student GR No ");
            table.AddCell(st.StudentID.ToString());


            String Name = st.FirstName + " " + st.MiddleName + " " + st.LastName;
            table.AddCell("StudentName");
            table.AddCell(Name);

            table.AddCell("Exam");
            table.AddCell((((ExamNo)marks.ExamNo).ToString()));

            table.AddCell("English");
            table.AddCell(marks.English.ToString());

            table.AddCell("Maths");
            table.AddCell(marks.Maths.ToString());

            table.AddCell("Science");
            table.AddCell(marks.Science.ToString());

            table.AddCell("Social Science");
            table.AddCell(marks.SocialScience.ToString());

            pdfDoc.Add(table);

            pdfWriter.CloseStream = false;
            pdfDoc.Close();
            Response.Buffer = true;
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Result.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();

            return View();
        }

        public ActionResult View_9th_Marks(int sid, ExamNo ExamNo)
        {
            ViewBag.ExamNo = ExamNo;
            Student st = db.Students.Find(sid);
            if (st == null)
            {
                return RedirectToAction("ViewResult", new { err = 1 });
            }
            ViewBag.student = st;
            int ex = (int)ExamNo;
            var marks = db.Std9_Marks.Where(x => (x.StudentID == sid) && (x.ExamNo == ex)).ToList();
            if (marks.Count() == 0)
            {
                return RedirectToAction("ViewResult", new { err = 1 });
            }
            return View(marks.Last());
        }

        [HttpPost]
        public ActionResult View_9th_Marks(int? SId, Std9_Marks mark)
        {
            if (SId == null)
            {
                return RedirectToAction("ViewResult", new { err = 1 });
            }

            Student st = db.Students.Find(SId);
            Std9_Marks marks = db.Std9_Marks.Find(mark.Std9Id);

            Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 15);
            PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            PdfPTable table = new PdfPTable(2);
            table.WidthPercentage = 100;
            table.HorizontalAlignment = 0;
            table.SpacingBefore = 20f;
            table.SpacingAfter = 30f;

            table.AddCell("Student GR No ");
            table.AddCell(st.StudentID.ToString());

            String Name = st.FirstName + " " + st.MiddleName + " " + st.LastName;
            table.AddCell("StudentName");
            table.AddCell(Name);

            table.AddCell("Exam");
            table.AddCell((((ExamNo)marks.ExamNo).ToString()));

            table.AddCell("English");
            table.AddCell(marks.English.ToString());

            table.AddCell("Maths");
            table.AddCell(marks.Maths.ToString());

            table.AddCell("Science");
            table.AddCell(marks.Science.ToString());

            table.AddCell("Social Science");
            table.AddCell(marks.SocialScience.ToString());

            pdfDoc.Add(table);

            pdfWriter.CloseStream = false;
            pdfDoc.Close();
            Response.Buffer = true;
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Result.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();

            return View();
        }

        public ActionResult View_10th_Marks(int sid, ExamNo ExamNo)
        {
            ViewBag.ExamNo = ExamNo;
            Student st = db.Students.Find(sid);
            if (st == null)
            {
                return RedirectToAction("ViewResult", new { err = 1 });
            }
            ViewBag.student = st;
            int ex = (int)ExamNo;
            var marks = db.Std10_Marks.Where(x => (x.StudentID == sid) && (x.ExamNo == ex)).ToList();
            if (marks.Count() == 0)
            {
                return RedirectToAction("ViewResult", new { err = 1 });
            }
            return View(marks.Last());
        }

        [HttpPost]
        public ActionResult View_10th_Marks(int? SId, Std10_Marks mark)
        {
            if (SId == null)
            {
                return HttpNotFound("Sid not Found " + mark.Std10Id);
            }

            Student st = db.Students.Find(SId);
            Std10_Marks marks = db.Std10_Marks.Find(mark.Std10Id);

            Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 15);
            PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            PdfPTable table = new PdfPTable(2);
            table.WidthPercentage = 100;
            table.HorizontalAlignment = 0;
            table.SpacingBefore = 20f;
            table.SpacingAfter = 30f;

            table.AddCell("Student GR No ");
            table.AddCell(st.StudentID.ToString());

            String Name = st.FirstName + " " + st.MiddleName + " " + st.LastName;
            table.AddCell("StudentName");
            table.AddCell(Name);

            table.AddCell("Exam");
            table.AddCell((((ExamNo)marks.ExamNo).ToString()));

            table.AddCell("English");
            table.AddCell(marks.English.ToString());

            table.AddCell("Maths");
            table.AddCell(marks.Maths.ToString());

            table.AddCell("Science");
            table.AddCell(marks.Science.ToString());

            table.AddCell("Social Science");
            table.AddCell(marks.SocialScience.ToString());

            pdfDoc.Add(table);

            pdfWriter.CloseStream = false;
            pdfDoc.Close();
            Response.Buffer = true;
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Result.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();

            return View();
        }

       

    }
}