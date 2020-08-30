using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;
using N_K_School.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace N_K_School.Controllers
{
    public class ClassTeachersController : Controller
    {
        private SchoolDbModel db = new SchoolDbModel();
        // GET: ClassTeachers
        public ActionResult Index()
        {
            var ct = db.ClassTeachers.Include(t => t.Teacher);
            return View(ct.ToList());
        }

        [HttpPost]
        public ActionResult EditClassTeacher(ClassTeacher ct)
        {
            ViewBag.TeacherID = new SelectList(db.Teachers, "TeacherId", "FirstName");
            Teacher t= db.Teachers.Find(ct.TeacherID);
            ViewBag.OldTeacherEmail = t.Email;
            return View(ct);
        }

        [HttpPost]
        public ActionResult EditClassTeacher1(ClassTeacher ct,String OldClassTeacher)
        {
            int standard = (int)ct.Standards;
            String Stn;
            if (standard == 0)
            {
                Stn = "Class_Teacher_8th";
            }
            else if (standard == 1)
            {
                Stn = "Class_Teacher_9th";
            }
            else
            {
                Stn = "Class_Teacher_10th";
            }
            Teacher t = db.Teachers.Find(ct.TeacherID);
            if(ModelState.IsValid)
            {
                db.Entry(ct).State = EntityState.Modified;
                db.SaveChanges();
                
                //List<string> roles;
                List<string> users;
                using (var context = new ApplicationDbContext())
                {
                    var roleStore = new RoleStore<IdentityRole>(context);
                    var roleManager = new RoleManager<IdentityRole>(roleStore);

                    //roles = (from r in roleManager.Roles select r.Name).ToList();

                    var userStore = new UserStore<ApplicationUser>(context);
                    var userManager = new UserManager<ApplicationUser>(userStore);

                    users = (from u in userManager.Users select u.UserName).ToList();
                    String err = "";
                   
                    foreach (var us in users)
                    {
                        err += "::" + us;
                    }
                    // remove old class teacher
                    var user = userManager.FindByName(OldClassTeacher.ToString());
                    if (user == null)
                        throw new Exception("User not found!" + "oooo"+OldClassTeacher+ ";;;;"+ err);

                    if (userManager.IsInRole(user.Id, Stn))
                    {
                        userManager.RemoveFromRole(user.Id, Stn);
                        context.SaveChanges();

                      //  ViewBag.ResultMessage = "Role removed from this user successfully !";
                    }
                    else
                    {
                        ViewBag.ResultMessage = "This user doesn't belong to selected role.";
                    }

                    // remove old teacher
                    user = userManager.FindByName(t.Email);
                    if (user == null)
                        throw new Exception("User not found!");

                    if (userManager.IsInRole(user.Id, "Teacher"))
                    {
                        userManager.RemoveFromRole(user.Id, "Teacher");
                        context.SaveChanges();

                        //  ViewBag.ResultMessage = "Role removed from this user successfully !";
                    }
                    else
                    {
                        ViewBag.ResultMessage = "This user doesn't belong to selected role.";
                    }

                //}
                //Update 
                //using (var context = new ApplicationDbContext())
                //{
                  //  var roleStore = new RoleStore<IdentityRole>(context);
                  //  var roleManager = new RoleManager<IdentityRole>(roleStore);

                  //  var userStore = new UserStore<ApplicationUser>(context);
                  //  var userManager = new UserManager<ApplicationUser>(userStore);

                  //  users = (from u in userManager.Users select u.UserName).ToList();

                    user = userManager.FindByName(t.Email);
                    if (user == null)
                        throw new Exception("User not found!" + t.Email);

                    var role = roleManager.FindByName(Stn);
                    if (role == null)
                        throw new Exception("Role not found!");

                    if (userManager.IsInRole(user.Id, role.Name))
                    {
                        ViewBag.ResultMessage = "This user already has the role specified !";
                    }
                    else
                    {
                        userManager.AddToRole(user.Id, role.Name);
                        //userManager.Update(user);
                        context.SaveChanges();

                        ViewBag.ResultMessage = "Username added to the role succesfully !";
                    }

                    // old ClassTeacher--> Teacher
                    user = userManager.FindByName(OldClassTeacher);
                    if (user == null)
                        throw new Exception("User not found!" + OldClassTeacher);

                    role = roleManager.FindByName("Teacher");
                    if (role == null)
                        throw new Exception("Role not found!");

                    if (userManager.IsInRole(user.Id, "Teacher"))
                    {
                        ViewBag.ResultMessage = "This user already has the role specified !";
                    }
                    else
                    {
                        userManager.AddToRole(user.Id, "Teacher");
                        //userManager.Update(user);
                        context.SaveChanges();

                        ViewBag.ResultMessage = "Username added to the role succesfully !";
                    }

                    //                    roles = (from r in roleManager.Roles select r.Name).ToList();
                }
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult MyCreate()
        {
            ViewBag.TeacherID = new SelectList(db.Teachers, "TeacherId", "FirstName");
            return View();
        }

        [HttpPost]
        public ActionResult MyCreate(ClassTeacher ct)
        {
            db.ClassTeachers.Add(ct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}