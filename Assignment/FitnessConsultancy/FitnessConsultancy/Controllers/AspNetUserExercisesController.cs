using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FitnessConsultancy.Models;
using Microsoft.AspNet.Identity;

namespace FitnessConsultancy.Controllers
{
    public class AspNetUserExercisesController : Controller
    {
        private Entities db = new Entities();

        // GET: AspNetUserExercises
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            string currentUserName = User.Identity.GetUserName();
            return View(db.AspNetUserExercises.Where(m => m.AspNetUserId == currentUserId).ToList()); 
            var aspNetUserExercises = db.AspNetUserExercises.Include(a => a.AspNetUser).Include(a => a.Exercise).Where(m => m.AspNetUserId == currentUserId).ToList();
           //return View(aspNetUserExercises.ToList());
        }

        public ActionResult CreateExerciseUser()
        {
            ViewBag.ExerciseId = new SelectList(db.Exercises, "ExerciseId", "ExerciseName");
            ViewBag.AspNetUsers = db.AspNetUsers;
            return View();
        }

        public ActionResult CreateUserExercise()
        {
            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.Exercises = db.Exercises;
            return View();
        }

        [HttpPost]
        public ActionResult CreateUserExercise(string Id, int[] ExerciseIds)
        {
            //var aspNetUserExercises = db.AspNetUserExercises.Include(a => a.AspNetUser).Include(a => a.Exercise);
            
            foreach (int ExerciseId in ExerciseIds)
            {
                AspNetUserExercise userExercise = new AspNetUserExercise();
                userExercise.ExerciseExerciseId = ExerciseId;
                userExercise.AspNetUserId = Id;
                db.AspNetUserExercises.Add(userExercise);
                db.SaveChanges();
            }
            //return View(aspNetUserExercises.ToList());
            return RedirectToAction("Index");
        }



        [HttpPost]
        public ActionResult CreateExerciseUser(int ExerciseId, string[] UserIds)
        {
            foreach (string UserId in UserIds)
            {
                AspNetUserExercise userExercise = new AspNetUserExercise();
                userExercise.ExerciseExerciseId = ExerciseId;
                userExercise.AspNetUserId = UserId;
                //empProject.AspNetUserId = UserId;
                db.AspNetUserExercises.Add(userExercise);
                //db.EmployeeProjects.Add(empProject);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        // GET: AspNetUserExercises/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUserExercise aspNetUserExercise = db.AspNetUserExercises.Find(id);
            if (aspNetUserExercise == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUserExercise);
        }

        // GET: AspNetUserExercises/Create
        public ActionResult Create()
        {
            ViewBag.AspNetUserId = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.ExerciseExerciseId = new SelectList(db.Exercises, "ExerciseId", "ExerciseName");
            return View();
        }

        // POST: AspNetUserExercises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AspNetUserId,ExerciseExerciseId")] AspNetUserExercise aspNetUserExercise)
        {
            if (ModelState.IsValid)
            {
                db.AspNetUserExercises.Add(aspNetUserExercise);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AspNetUserId = new SelectList(db.AspNetUsers, "Id", "Email", aspNetUserExercise.AspNetUserId);
            ViewBag.ExerciseExerciseId = new SelectList(db.Exercises, "ExerciseId", "ExerciseName", aspNetUserExercise.ExerciseExerciseId);
            return View(aspNetUserExercise);
        }

        // GET: AspNetUserExercises/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUserExercise aspNetUserExercise = db.AspNetUserExercises.Find(id);
            if (aspNetUserExercise == null)
            {
                return HttpNotFound();
            }
            ViewBag.AspNetUserId = new SelectList(db.AspNetUsers, "Id", "Email", aspNetUserExercise.AspNetUserId);
            ViewBag.ExerciseExerciseId = new SelectList(db.Exercises, "ExerciseId", "ExerciseName", aspNetUserExercise.ExerciseExerciseId);
            return View(aspNetUserExercise);
        }

        // POST: AspNetUserExercises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AspNetUserId,ExerciseExerciseId")] AspNetUserExercise aspNetUserExercise)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aspNetUserExercise).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AspNetUserId = new SelectList(db.AspNetUsers, "Id", "Email", aspNetUserExercise.AspNetUserId);
            ViewBag.ExerciseExerciseId = new SelectList(db.Exercises, "ExerciseId", "ExerciseName", aspNetUserExercise.ExerciseExerciseId);
            return View(aspNetUserExercise);
        }

        // GET: AspNetUserExercises/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUserExercise aspNetUserExercise = db.AspNetUserExercises.Find(id);
            if (aspNetUserExercise == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUserExercise);
        }

        // POST: AspNetUserExercises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AspNetUserExercise aspNetUserExercise = db.AspNetUserExercises.Find(id);
            db.AspNetUserExercises.Remove(aspNetUserExercise);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
