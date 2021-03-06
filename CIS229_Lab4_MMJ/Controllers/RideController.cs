﻿using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CIS229_Lab4_MMJ.Models;

namespace CIS229_Lab4_MMJ.Controllers
{
    public class RideController : Controller
    {
        private RideShareDB db = new RideShareDB();

        // GET: Ride
        public ActionResult Index(int? campusId, string dayOfWeek)
        {
            IQueryable<Ride> ridesQuery = db.Rides.Include(r => r.Campus);

            if (campusId.HasValue)
            {
                ridesQuery = ridesQuery.Where(r => r.CampusId == campusId);
            }

            if (dayOfWeek != null)
            {
                ridesQuery = ridesQuery.Where(r => r.DayOfWeek == dayOfWeek);
            }

            var model = new RideIndexModel
            {
                Rides = ridesQuery
               ,Campuses = db.Campus.Select(c => new SelectListItem { Value = c.CampusId.ToString(), Text = c.Name })
               ,DaysOfWeek = new List<SelectListItem>
               {
                   new SelectListItem { Value = "Sunday",    Text = "Sunday"    }
                  ,new SelectListItem { Value = "Monday",    Text = "Monday"    }
                  ,new SelectListItem { Value = "Tuesday",   Text = "Tuesday"   }
                  ,new SelectListItem { Value = "Wednesday", Text = "Wednesday" }
                  ,new SelectListItem { Value = "Thursday",  Text = "Thursday"  }
                  ,new SelectListItem { Value = "Friday",    Text = "Friday"    }
                  ,new SelectListItem { Value = "Saturday",  Text = "Saturday"  }
               }
            };
          
            return View(model);
        }

       
        // Ride/Search
        public ActionResult Search(RideIndexModel query)
        {
            return RedirectToAction("Index", new { campusId = query?.SelectedCampusId, dayOfWeek = query?.SelectedDayOfWeek });
        }
        
        // GET: Ride/Details/5
        public ActionResult Details(int? id)
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

        // GET: Ride/Create
        public ActionResult Create()
        {
            ViewBag.CampusId = new SelectList(db.Campus, "CampusId", "Name");
            return View();
        }

        // POST: Ride/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RideId,CampusId,StudentEmail,StartingCrossroads,StartingTown,DayOfWeek,TimeStart,TimeEnd,Requirements")] Ride ride)
        {
            ModelState.Remove("Campus");
            if (ModelState.IsValid)
            {
                ride.Campus = db.Campus.First(c => c.CampusId == ride.CampusId);
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
        public ActionResult Edit([Bind(Include = "RideId,CampusId,StudentEmail,StartingCrossroads,StartingTown,DayOfWeek,TimeStart,TimeEnd,Requirements")] Ride ride)
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
