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
    public class ProvidersController : Controller
    {
        private Rushbox_v2Entities db = new Rushbox_v2Entities();

        // GET: Providers
        public ActionResult Index()
        {
            var providers = db.Providers.Include(p => p.City).Include(p => p.Country).Include(p => p.User);
            return View(providers.ToList());
        }

        // GET: Providers/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provider provider = db.Providers.Find(id);
            if (provider == null)
            {
                return HttpNotFound();
            }
            return View(provider);
        }

        // GET: Providers/Create
        public ActionResult Create()
        {
            ViewBag.ID_City = new SelectList(db.Cities, "ID_City", "TX_City");
            ViewBag.ID_Country = new SelectList(db.Countries, "ID_Country", "TX_CountryName");
            ViewBag.ID_User = new SelectList(db.Users, "ID_User", "TX_Name");
            return View();
        }

        // POST: Providers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Provider,ID_User,TX_Name,TX_AddressLine1,TX_AddressLine2,ID_Country,ID_City,TX_StateProvinceRegion,TX_Zip,TX_PhoneNumber,DT_Register,BO_Open,NU_Latitude,NU_Longitud")] Provider provider)
        {
            if (ModelState.IsValid)
            {
                db.Providers.Add(provider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_City = new SelectList(db.Cities, "ID_City", "TX_City", provider.ID_City);
            ViewBag.ID_Country = new SelectList(db.Countries, "ID_Country", "TX_CountryName", provider.ID_Country);
            ViewBag.ID_User = new SelectList(db.Users, "ID_User", "TX_Name", provider.ID_User);
            return View(provider);
        }

        // GET: Providers/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provider provider = db.Providers.Find(id);
            if (provider == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_City = new SelectList(db.Cities, "ID_City", "TX_City", provider.ID_City);
            ViewBag.ID_Country = new SelectList(db.Countries, "ID_Country", "TX_CountryName", provider.ID_Country);
            ViewBag.ID_User = new SelectList(db.Users, "ID_User", "TX_Name", provider.ID_User);
            return View(provider);
        }

        // POST: Providers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Provider,ID_User,TX_Name,TX_AddressLine1,TX_AddressLine2,ID_Country,ID_City,TX_StateProvinceRegion,TX_Zip,TX_PhoneNumber,DT_Register,BO_Open,GE_Location,NU_Latitude,NU_Longitud")] Provider provider)
        {
            if (ModelState.IsValid)
            {
                db.Entry(provider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_City = new SelectList(db.Cities, "ID_City", "TX_City", provider.ID_City);
            ViewBag.ID_Country = new SelectList(db.Countries, "ID_Country", "TX_CountryName", provider.ID_Country);
            ViewBag.ID_User = new SelectList(db.Users, "ID_User", "TX_Name", provider.ID_User);
            return View(provider);
        }

        // GET: Providers/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provider provider = db.Providers.Find(id);
            if (provider == null)
            {
                return HttpNotFound();
            }
            return View(provider);
        }

        // POST: Providers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Provider provider = db.Providers.Find(id);
            db.Providers.Remove(provider);
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
