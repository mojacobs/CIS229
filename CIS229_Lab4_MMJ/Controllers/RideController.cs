using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CIS229_Lab4_MMJ.Models;

namespace CIS229_Lab4_MMJ.Controllers
{
    public class RideController : Controller
    {
        private RideShareDB db = new RideShareDB();

        // GET: Ride
        public ActionResult Index()
        {
            var rides = db.Rides.Include(r => r.Campus);
            return View(rides.ToList());
        }

        // GET: Ride/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ride ride = db.Rides.Find(id);
            //Ride ride = db.Rides.Include(r => r.Campus).Where(r => r.RideId == id).FirstOrDefault();
            if (ride == null)
            {
                return HttpNotFound();
            }
            return View(ride);
        }

        // GET: Ride/Create
        public ActionResult Create()
        {
            ViewBag.CampusId = new SelectList(db.Campus, "CampusId", "Name");
            return View();
        }

        // POST: Ride/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RideId,CampusId,StudentEmail,StartingCrossroads,StartingTown,DayOfWeek,TimeStart,TimeEnd")] Ride ride)
        {
            if (ModelState.IsValid)
            {
                db.Rides.Add(ride);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CampusId = new SelectList(db.Campus, "CampusId", "Name", ride.CampusId);
            return View(ride);
        }

        // GET: Ride/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ride ride = db.Rides.Find(id);
            if (ride == null)
            {
                return HttpNotFound();
            }
            ViewBag.CampusId = new SelectList(db.Campus, "CampusId", "Name", ride.CampusId);
            return View(ride);
        }

        // POST: Ride/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RideId,CampusId,StudentEmail,StartingCrossroads,StartingTown,DayOfWeek,TimeStart,TimeEnd")] Ride ride)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ride).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CampusId = new SelectList(db.Campus, "CampusId", "Name", ride.CampusId);
            return View(ride);
        }

        // GET: Ride/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ride ride = db.Rides.Find(id);
            if (ride == null)
            {
                return HttpNotFound();
            }
            return View(ride);
        }

        // POST: Ride/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ride ride = db.Rides.Find(id);
            db.Rides.Remove(ride);
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
