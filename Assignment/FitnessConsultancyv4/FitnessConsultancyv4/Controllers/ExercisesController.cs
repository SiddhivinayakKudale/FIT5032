using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FitnessConsultancyv4.Models;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using Newtonsoft.Json;

namespace FitnessConsultancyv4.Controllers
{
    public class ExercisesController : Controller
    {
        private Entities db = new Entities();

        // GET: Exercises
        public ActionResult Index()
        {
            return View(db.Exercises.ToList());
        }

        public ActionResult ViewRating(/*int exerciseId*/)
        {
            /*ViewBag.exerciseId = exerciseId;*/
            try
            {
                var ratingQuery = (from p in db.Comments 
                                    join e in db.Exercises on
                                    p.ExerciseId equals e.ExerciseId
                                   select new
                                   {
                                       rating = p.Rating,
                                       exerciseId = p.ExerciseId,
                                       exerciseCategory = e.ExerciseCategory

                                   });
                var ratingg = ratingQuery.ToList()
                                       .GroupBy(e => e.exerciseCategory)
                                       .Select(p => new { exerciseId = p.Key, rating = p.Average(x => x.rating)})
                                       .ToList();
               
                JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
                ViewBag.DataPoints = JsonConvert.SerializeObject((ratingg), _jsonSetting);
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
           /* return View(db.Comments.Where(m => m.ExerciseId == exerciseId).ToList());*/
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


        // GET: Exercises/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercise exercise = db.Exercises.Find(id);
            if (exercise == null)
            {
                return HttpNotFound();
            }
            return View(exercise);
        }

        // GET: Exercises/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Exercises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExerciseId,ExerciseName,ExerciseDesc,ExerciseCategory,ExerciseCalorieshr")] Exercise exercise)
        {
            if (ModelState.IsValid)
            {
                db.Exercises.Add(exercise);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(exercise);
        }

        // GET: Exercises/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercise exercise = db.Exercises.Find(id);
            if (exercise == null)
            {
                return HttpNotFound();
            }
            return View(exercise);
        }

        // POST: Exercises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExerciseId,ExerciseName,ExerciseDesc,ExerciseCategory,ExerciseCalorieshr")] Exercise exercise)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exercise).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exercise);
        }

        // GET: Exercises/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercise exercise = db.Exercises.Find(id);
            if (exercise == null)
            {
                return HttpNotFound();
            }
            return View(exercise);
        }

        // POST: Exercises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Exercise exercise = db.Exercises.Find(id);
            db.Exercises.Remove(exercise);
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
