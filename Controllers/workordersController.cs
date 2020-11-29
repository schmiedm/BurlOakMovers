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
    [Authorize]
    public class workordersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: workorders
        public ActionResult Index()
        {
            var workorders = db.workorders.Include(w => w.customer);
            return View(workorders.ToList());
        }

        // GET: workorders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            workorder workorder = db.workorders.Find(id);
            if (workorder == null)
            {
                return HttpNotFound();
            }
            return View(workorder);
        }

        // GET: workorders/Create
        public ActionResult Create()
        {
            ViewBag.custid = new SelectList(db.customers, "custid", "custname");
            return View();
        }

        // POST: workorders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "workorderid,custid,numvans,numworker,numhours,payrate,furnishtotal,washer,dryer,fridge,stove,dishwasher,mircowave,freezer,pianotype,wadrobe,mirrorcartons,proposalother,appliancetotal,deductible,deductibleamount,specialins,labourhrs,carton2,carton4,carton5,smmirror,lgmirror,sglmatress,dblmatress,kingqeen,wardrobes,totalpackestimate,shipper,mover,moverrep,esttotal,taxrate,total")] workorder workorder)
        {
            if (ModelState.IsValid)
            {
                db.workorders.Add(workorder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.custid = new SelectList(db.customers, "custid", "custname", workorder.custid);
            return View(workorder);
        }

        // GET: workorders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            workorder workorder = db.workorders.Find(id);
            if (workorder == null)
            {
                return HttpNotFound();
            }
            ViewBag.custid = new SelectList(db.customers, "custid", "custname", workorder.custid);
            return View(workorder);
        }

        // POST: workorders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "workorderid,custid,numvans,numworker,numhours,payrate,furnishtotal,washer,dryer,fridge,stove,dishwasher,mircowave,freezer,pianotype,wadrobe,mirrorcartons,proposalother,appliancetotal,deductible,deductibleamount,specialins,labourhrs,carton2,carton4,carton5,smmirror,lgmirror,sglmatress,dblmatress,kingqeen,wardrobes,totalpackestimate,shipper,mover,moverrep,esttotal,taxrate,total")] workorder workorder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workorder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.custid = new SelectList(db.customers, "custid", "custname", workorder.custid);
            return View(workorder);
        }

        // GET: workorders/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            workorder workorder = db.workorders.Find(id);
            if (workorder == null)
            {
                return HttpNotFound();
            }
            return View(workorder);
        }

        // POST: workorders/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            workorder workorder = db.workorders.Find(id);
            db.workorders.Remove(workorder);
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
