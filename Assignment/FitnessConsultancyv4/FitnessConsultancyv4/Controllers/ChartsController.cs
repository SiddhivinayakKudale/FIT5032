using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FitnessConsultancyv4.Models;
using Newtonsoft.Json;
using Rotativa;
using System.Timers;
using System.Threading;
using Microsoft.AspNet.Identity;

namespace FitnessConsultancyv4.Controllers
{
    public class ChartsController : Controller
    {
        private Entities db = new Entities();

        public ActionResult PrintViewToPdf()
        {
            //var aTimer = new System.Timers.Timer(100000);
            //Thread.Sleep(9000);
            var report = new ActionAsPdf("Index");
            //Thread.Sleep(9000);
            return report;
        }



        // GET: Charts
        public ActionResult Index()
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
                                       .Select(p => new { category = p.Key , calories = p.Sum(x => Int32.Parse(x.calories))})
                                      
                                       .ToList();       
                /*db.Exercises.GroupBy*/
                var q1 = db.UserExercises.Where(m => m.AspNetUserId == currentUserId);
                //var query = from st in db.UserExercises join rt in db.Exercises on  st.ExerciseExerciseId == rt.ExerciseId;
                var query = from st in db.Exercises where st.ExerciseId == 5 select st;
                JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
                ViewBag.DataPoints =   JsonConvert.SerializeObject((person), _jsonSetting);
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
        }
        //JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };

        public ActionResult barchart()
        {
            return View();
        }
    }
}