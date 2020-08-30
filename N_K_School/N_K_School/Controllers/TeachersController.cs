using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;
using N_K_School.Models;
using N_K_School.CustomFilters;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;


namespace N_K_School.Controllers
{
    public class TeachersController : Controller
    {
        private SchoolDbModel db = new SchoolDbModel();
        
        // GET: Teachers
        [AuthLog(Roles = "Clerk")]
        public ActionResult Index()
        {
            return View(db.Teachers.ToList());
        }

        [AuthLog(Roles = "Clerk")]
        public ActionResult TeachersList()
        {
            return View(db.Teachers.ToList());
        }

        [AuthLog(Roles = "Principal")]
        public ActionResult RemoveTeacher(int? tid)
        {
            if(tid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tsub = db.TeacherSubjects.Where(x => x.TeacherID == tid).ToList();
            if(tsub.Count() != 0)
            {
               
                return RedirectToAction("PrincipleTeachersList",new { err = 1});
            }
            Teacher t = db.Teachers.Find(tid);
            if(t == null)
            {
                return Content("Sorry ,Something went wrong");
            }
            using (var context = new ApplicationDbContext())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                //roles = (from r in roleManager.Roles select r.Name).ToList();

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                var user = userManager.FindByName(t.Email.ToString());
                if (user == null)
                    throw new Exception("User not found!" + "oooo" + t.Email + ";;;;"  );

                if (userManager.IsInRole(user.Id, "Teacher"))
                {
                    userManager.RemoveFromRole(user.Id, "Teacher");
                    context.SaveChanges();

                    //  ViewBag.ResultMessage = "Role removed from this user successfully !";
                }
                else
                {
                    return RedirectToAction("PrincipleTeachersList", new { err = 2 });
                    //return Content("Error");
                }
            }
            db.Entry(t).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("PrincipleTeachersList");
        }

        [AuthLog(Roles = "Principal")]
        public ActionResult PrincipleTeachersList(int? err)
        {
            if(err ==1)
            {
                ViewBag.ErrorTeacher = "Teacher is assigned some subject first remove them and then try.";
            }else if(err == 2)
            {
                ViewBag.ErrorTeacher = "Teacher is class teacher first remove that!";
            }
            return View(db.Teachers.ToList());
        }

        [AuthLog(Roles = "Clerk")]
        public ActionResult TeacherDetails(int? tid)
        {
            if(tid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher t = db.Teachers.Find(tid); 
            if(t == null)
            {
                return HttpNotFound();
            }
            return View(t);
        }

        [AuthLog(Roles = "Clerk")]
        public ActionResult TeacherEdit(int? tid)
        {
            if(tid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher t = db.Teachers.Find(tid);
            if(t == null)
            {
                return HttpNotFound();
            }
            return View(t);
        }

        [AuthLog(Roles = "Clerk")]
        [HttpPost]
        public ActionResult TeacherEdit(Teacher t)
        {
            if(ModelState.IsValid)
            {
                db.Entry(t).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("TeacherDetails", new { tid = t.TeacherID });
            }
            return View();
        }

        //[AuthLog(Roles = "Clerk")]
        //public ActionResult AddTeacher()
        //{
        //    return View();
        //}

        //[AuthLog(Roles = "Clerk")]
        //[HttpPost]
        //public async  Task<ActionResult> AddTeacher(Teacher t)
        //{
        //    RegisterViewModel model = new RegisterViewModel();
        //    model.Email = t.Email;
        //    model.Password = t.Email;
        //    model.ConfirmPassword = model.Password;

        //    if (ModelState.IsValid)
        //    {
        //        var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
        //        var result = await UserManager.CreateAsync(user, model.Password);
        //        if (result.Succeeded)
        //        {

        //            //Assign Role to user Here 
        //            await this.UserManager.AddToRoleAsync(user.Id, model.Name);
        //            //Ends Here


        //            await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

        //            return RedirectToAction("Index", "Home");
        //        }
        //        db.Teachers.Add(t);
        //        db.SaveChanges();

        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}
    }
}