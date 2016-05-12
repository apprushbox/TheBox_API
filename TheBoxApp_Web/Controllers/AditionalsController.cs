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
    public class AditionalsController : Controller
    {
        private Rushbox_v2Entities db = new Rushbox_v2Entities();

        // GET: Aditionals
        public ActionResult Index()
        {
            return View(db.Aditionals.ToList());
        }

        // GET: Aditionals/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aditional aditional = db.Aditionals.Find(id);
            if (aditional == null)
            {
                return HttpNotFound();
            }
            return View(aditional);
        }

        // GET: Aditionals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Aditionals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Aditional,TX_Aditional,BO_Active,DT_Register")] Aditional aditional)
        {
            if (ModelState.IsValid)
            {
                db.Aditionals.Add(aditional);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aditional);
        }

        // GET: Aditionals/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aditional aditional = db.Aditionals.Find(id);
            if (aditional == null)
            {
                return HttpNotFound();
            }
            return View(aditional);
        }

        // POST: Aditionals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Aditional,TX_Aditional,BO_Active,DT_Register")] Aditional aditional)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aditional).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aditional);
        }

        // GET: Aditionals/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aditional aditional = db.Aditionals.Find(id);
            if (aditional == null)
            {
                return HttpNotFound();
            }
            return View(aditional);
        }

        // POST: Aditionals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Aditional aditional = db.Aditionals.Find(id);
            db.Aditionals.Remove(aditional);
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
