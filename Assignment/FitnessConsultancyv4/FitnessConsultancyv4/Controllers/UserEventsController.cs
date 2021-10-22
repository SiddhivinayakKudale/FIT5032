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

namespace FitnessConsultancyv4.Controllers
{
    public class UserEventsController : Controller
    {
        private Entities db = new Entities();

        // GET: UserEvents
        public ActionResult Index()
        {
            var userEvents = db.UserEvents.Include(u => u.AspNetUser).Include(u => u.Event);
           // string currentUserId = User.Identity.GetUserId();
            //return View(db.UserEvents.Where(m => m.AspNetUserId == currentUserId).ToList());
            return View(userEvents.ToList());
        }

        public ActionResult DisplayUserEvents()
        {
            string currentUserId = User.Identity.GetUserId();
            return View(db.UserEvents.Where(m => m.AspNetUserId == currentUserId).ToList()); 
            //return View(db.Events.ToList());
        }

        // GET: UserEvents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserEvent userEvent = db.UserEvents.Find(id);
            if (userEvent == null)
            {
                return HttpNotFound();
            }
            return View(userEvent);
        }

        // GET: UserEvents/Create
        public ActionResult Create()
        {
            ViewBag.AspNetUserId = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.EventEventId = new SelectList(db.Events, "EventId", "EventName");
            return View();
        }

        // POST: UserEvents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserEventId,AspNetUserId,EventEventId")] UserEvent userEvent)
        {
            if (ModelState.IsValid)
            {
                db.UserEvents.Add(userEvent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AspNetUserId = new SelectList(db.AspNetUsers, "Id", "Email", userEvent.AspNetUserId);
            ViewBag.EventEventId = new SelectList(db.Events, "EventId", "EventName", userEvent.EventEventId);
            return View(userEvent);
        }

        // GET: UserEvents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserEvent userEvent = db.UserEvents.Find(id);
            if (userEvent == null)
            {
                return HttpNotFound();
            }
            ViewBag.AspNetUserId = new SelectList(db.AspNetUsers, "Id", "Email", userEvent.AspNetUserId);
            ViewBag.EventEventId = new SelectList(db.Events, "EventId", "EventName", userEvent.EventEventId);
            return View(userEvent);
        }

        // POST: UserEvents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserEventId,AspNetUserId,EventEventId")] UserEvent userEvent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userEvent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AspNetUserId = new SelectList(db.AspNetUsers, "Id", "Email", userEvent.AspNetUserId);
            ViewBag.EventEventId = new SelectList(db.Events, "EventId", "EventName", userEvent.EventEventId);
            return View(userEvent);
        }

        // GET: UserEvents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserEvent userEvent = db.UserEvents.Find(id);
            if (userEvent == null)
            {
                return HttpNotFound();
            }
            return View(userEvent);
        }

        // POST: UserEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserEvent userEvent = db.UserEvents.Find(id);
            db.UserEvents.Remove(userEvent);
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
