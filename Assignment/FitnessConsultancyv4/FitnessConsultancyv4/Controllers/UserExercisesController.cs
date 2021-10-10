using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FitnessConsultancyv4.Models;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
namespace FitnessConsultancyv4.Controllers
{
    public class UserExercisesController : Controller
    {
        private Entities db = new Entities();

        public UserExercisesController()
        {
            //showComment1();
        }

        // GET: UserExercises
        public ActionResult Index()
        {
            /*var userExercises = db.UserExercises.Include(u => u.AspNetUser).Include(u => u.Exercise);
            return View(userExercises.ToList());*/
            string currentUserId = User.Identity.GetUserId();
            string currentUserName = User.Identity.GetUserName();
            return View(db.UserExercises.Where(m => m.AspNetUserId == currentUserId).ToList());
        }


        [HttpPost]
        [ValidateInput(false)]
        public FileResult ExportHTML(string ExportData)
        {
            using (MemoryStream stream = new System.IO.MemoryStream())
            {
                StringReader reader = new StringReader(ExportData);
                Document PdfFile = new Document(PageSize.A4);
                PdfWriter writer = PdfWriter.GetInstance(PdfFile, stream);
                PdfFile.Open();
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, PdfFile, reader);
                PdfFile.Close();
                return File(stream.ToArray(), "application/pdf", "ExportData.pdf");
            }
        }


        /*public ActionResult showComment1()
        {
            // return View();
            try
            {
                string currentUserId = User.Identity.GetUserId();
                var personQuery = (from p in db.Exercises
                                   join e in db.UserExercises
                                   on p.ExerciseId equals e.ExerciseExerciseId
                                   where e.AspNetUserId == currentUserId
                                   select new
                                   {
                                       category = p.ExerciseCategory,
                                       calories = p.ExerciseCalorieshr,
                                   });

                var person = personQuery.ToList()
                                       .GroupBy(p => p.category)
                                       .Select(p => new { category = p.Key, calories = p.Sum(x => Int32.Parse(x.calories)) })

                                       .ToList();
                *//*db.Exercises.GroupBy*//*
                var q1 = db.UserExercises.Where(m => m.AspNetUserId == currentUserId);
                //var query = from st in db.UserExercises join rt in db.Exercises on  st.ExerciseExerciseId == rt.ExerciseId;
                var query = from st in db.Exercises where st.ExerciseId == 5 select st;
                JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
                ViewBag.DataPoints = JsonConvert.SerializeObject((person), _jsonSetting);
                // ViewBag.DataPoints = JsonConvert.SerializeObject((db.Exercises.Select(p => new { p.ExerciseCategory, p.ExerciseCalorieshr }), _jsonSetting);
                return View();
            }
            catch (System.Data.Entity.Core.EntityException)
            {
                return View("Error");
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return View("Error");
            }
        }*/





        public ActionResult showComment(int exerciseId)
        {
            ViewBag.exerciseId = exerciseId;
            return View(db.Comments.Where(m => m.ExerciseId == exerciseId).ToList());
        }

        [HttpPost]
        public ActionResult AddComment(int exerciseId, int rating, string exerciseComment)
        {
            Comments obj = new Comments();
            obj.ExerciseId = exerciseId;
            obj.Rating = rating;
            obj.CommentDescription = exerciseComment;
            obj.CommentedOn = DateTime.Now;
            db.Comments.Add(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
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
                UserExercise userExercise = new UserExercise();
                userExercise.ExerciseExerciseId = ExerciseId;
                userExercise.AspNetUserId = Id;
                db.UserExercises.Add(userExercise);
                db.SaveChanges();
            }
            //return View(aspNetUserExercises.ToList());
            return RedirectToAction("Index");
            // return View();
        }





        // GET: UserExercises/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserExercise userExercise = db.UserExercises.Find(id);
            if (userExercise == null)
            {
                return HttpNotFound();
            }
            return View(userExercise);
        }

        // GET: UserExercises/Create
        public ActionResult Create()
        {
            ViewBag.AspNetUserId = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.ExerciseExerciseId = new SelectList(db.Exercises, "ExerciseId", "ExerciseName");
            return View();
        }

        // POST: UserExercises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserExerciseId,AspNetUserId,ExerciseExerciseId")] UserExercise userExercise)
        {
            if (ModelState.IsValid)
            {
                db.UserExercises.Add(userExercise);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AspNetUserId = new SelectList(db.AspNetUsers, "Id", "Email", userExercise.AspNetUserId);
            ViewBag.ExerciseExerciseId = new SelectList(db.Exercises, "ExerciseId", "ExerciseName", userExercise.ExerciseExerciseId);
            return View(userExercise);
        }

        // GET: UserExercises/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserExercise userExercise = db.UserExercises.Find(id);
            if (userExercise == null)
            {
                return HttpNotFound();
            }
            ViewBag.AspNetUserId = new SelectList(db.AspNetUsers, "Id", "Email", userExercise.AspNetUserId);
            ViewBag.ExerciseExerciseId = new SelectList(db.Exercises, "ExerciseId", "ExerciseName", userExercise.ExerciseExerciseId);
            return View(userExercise);
        }

        // POST: UserExercises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserExerciseId,AspNetUserId,ExerciseExerciseId")] UserExercise userExercise)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userExercise).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AspNetUserId = new SelectList(db.AspNetUsers, "Id", "Email", userExercise.AspNetUserId);
            ViewBag.ExerciseExerciseId = new SelectList(db.Exercises, "ExerciseId", "ExerciseName", userExercise.ExerciseExerciseId);
            return View(userExercise);
        }

        // GET: UserExercises/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserExercise userExercise = db.UserExercises.Find(id);
            if (userExercise == null)
            {
                return HttpNotFound();
            }
            return View(userExercise);
        }

        // POST: UserExercises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserExercise userExercise = db.UserExercises.Find(id);
            db.UserExercises.Remove(userExercise);
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
