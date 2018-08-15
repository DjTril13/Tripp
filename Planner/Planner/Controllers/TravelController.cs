using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Planner.Models;

namespace Planner.Controllers
{
    public class TravelController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Travel
        public ActionResult Index()
        {
            return View(db.Travel.ToList());
        }

        // GET: Travel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Travel travel = db.Travel.Find(id);
            if (travel == null)
            {
                return HttpNotFound();
            }
            return View(travel);
        }

        // GET: Travel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Travel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Method,Depature,Arrival,Comments,TicketLink")] Travel travel)
        {
            if (ModelState.IsValid)
            {
                db.Travel.Add(travel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(travel);
        }

        // GET: Travel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Travel travel = db.Travel.Find(id);
            if (travel == null)
            {
                return HttpNotFound();
            }
            return View(travel);
        }

        // POST: Travel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Method,Depature,Arrival,Comments,TicketLink")] Travel travel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(travel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(travel);
        }

        // GET: Travel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Travel travel = db.Travel.Find(id);
            if (travel == null)
            {
                return HttpNotFound();
            }
            return View(travel);
        }

        // POST: Travel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Travel travel = db.Travel.Find(id);
            db.Travel.Remove(travel);
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
