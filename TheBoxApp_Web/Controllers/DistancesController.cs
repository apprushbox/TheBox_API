using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheBoxApp_Web;

namespace TheBoxApp_Web.Controllers
{
    public class DistancesController : Controller
    {
        private Rushbox_v2Entities db = new Rushbox_v2Entities();

        // GET: Distances
        public ActionResult Index()
        {
            var Distances = db.Distances.Include(d => d.Provider);
            return View(Distances.ToList());
        }

        // GET: Distances/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Distance Distance = db.Distances.Find(id);
            if (Distance == null)
            {
                return HttpNotFound();
            }
            return View(Distance);
        }

        // GET: Distances/Create
        public ActionResult Create()
        {
            ViewBag.ID_Provider = new SelectList(db.Providers, "ID_Provider", "TX_Name");
            return View();
        }

        // POST: Distances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Distance,ID_Provider,NU_MinDistance,NU_MaxDistance,NU_Time")] Distance Distance)
        {
            if (ModelState.IsValid)
            {
                db.Distances.Add(Distance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Provider = new SelectList(db.Providers, "ID_Provider", "TX_Name", Distance.ID_Provider);
            return View(Distance);
        }

        // GET: Distances/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Distance Distance = db.Distances.Find(id);
            if (Distance == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Provider = new SelectList(db.Providers, "ID_Provider", "TX_Name", Distance.ID_Provider);
            return View(Distance);
        }

        // POST: Distances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Distance,ID_Provider,NU_MinDistance,NU_MaxDistance,NU_Time")] Distance Distance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Distance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Provider = new SelectList(db.Providers, "ID_Provider", "TX_Name", Distance.ID_Provider);
            return View(Distance);
        }

        // GET: Distances/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Distance Distance = db.Distances.Find(id);
            if (Distance == null)
            {
                return HttpNotFound();
            }
            return View(Distance);
        }

        // POST: Distances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Distance Distance = db.Distances.Find(id);
            db.Distances.Remove(Distance);
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
