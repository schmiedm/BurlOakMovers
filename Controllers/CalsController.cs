using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BurlOakMovers.Models;

namespace BurlOakMovers.Controllers
{
    public class CalsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TestEvents
        public ActionResult Index()
        {
            return View(db.TestEvents.ToList());
        }

        // GET: TestEvents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestEvent testEvent = db.TestEvents.Find(id);
            if (testEvent == null)
            {
                return HttpNotFound();
            }
            return View(testEvent);
        }

        // GET: TestEvents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestEvents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Subject,Description,Start,End,ThemeColor,IsFullDay")] TestEvent testEvent)
        {
            if (ModelState.IsValid)
            {
                db.TestEvents.Add(testEvent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(testEvent);
        }

        // GET: TestEvents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestEvent testEvent = db.TestEvents.Find(id);
            if (testEvent == null)
            {
                return HttpNotFound();
            }
            return View(testEvent);
        }

        // POST: TestEvents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Subject,Description,Start,End,ThemeColor,IsFullDay")] TestEvent testEvent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testEvent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(testEvent);
        }

        // GET: TestEvents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestEvent testEvent = db.TestEvents.Find(id);
            if (testEvent == null)
            {
                return HttpNotFound();
            }
            return View(testEvent);
        }

        // POST: TestEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestEvent testEvent = db.TestEvents.Find(id);
            db.TestEvents.Remove(testEvent);
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
