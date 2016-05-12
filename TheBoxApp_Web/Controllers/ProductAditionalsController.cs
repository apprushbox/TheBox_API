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
    public class ProductAditionalsController : Controller
    {
        private Rushbox_v2Entities db = new Rushbox_v2Entities();

        // GET: ProductAditionals
        public ActionResult Index()
        {
            var productAditionals = db.ProductAditionals.Include(p => p.Aditional).Include(p => p.Product);
            return View(productAditionals.ToList());
        }

        // GET: ProductAditionals/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductAditional productAditional = db.ProductAditionals.Find(id);
            if (productAditional == null)
            {
                return HttpNotFound();
            }
            return View(productAditional);
        }

        // GET: ProductAditionals/Create
        public ActionResult Create()
        {
            ViewBag.ID_Aditional = new SelectList(db.Aditionals, "ID_Aditional", "TX_Aditional");
            ViewBag.ID_Product = new SelectList(db.Products, "ID_Product", "TX_Name");
            return View();
        }

        // POST: ProductAditionals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_ProductAditional,ID_Product,ID_Aditional,NU_AditionalCost,BO_Mandatory,BO_Active,DT_Register")] ProductAditional productAditional)
        {
            if (ModelState.IsValid)
            {
                db.ProductAditionals.Add(productAditional);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Aditional = new SelectList(db.Aditionals, "ID_Aditional", "TX_Aditional", productAditional.ID_Aditional);
            ViewBag.ID_Product = new SelectList(db.Products, "ID_Product", "TX_Name", productAditional.ID_Product);
            return View(productAditional);
        }

        // GET: ProductAditionals/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductAditional productAditional = db.ProductAditionals.Find(id);
            if (productAditional == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Aditional = new SelectList(db.Aditionals, "ID_Aditional", "TX_Aditional", productAditional.ID_Aditional);
            ViewBag.ID_Product = new SelectList(db.Products, "ID_Product", "TX_Name", productAditional.ID_Product);
            return View(productAditional);
        }

        // POST: ProductAditionals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_ProductAditional,ID_Product,ID_Aditional,NU_AditionalCost,BO_Mandatory,BO_Active,DT_Register")] ProductAditional productAditional)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productAditional).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Aditional = new SelectList(db.Aditionals, "ID_Aditional", "TX_Aditional", productAditional.ID_Aditional);
            ViewBag.ID_Product = new SelectList(db.Products, "ID_Product", "TX_Name", productAditional.ID_Product);
            return View(productAditional);
        }

        // GET: ProductAditionals/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductAditional productAditional = db.ProductAditionals.Find(id);
            if (productAditional == null)
            {
                return HttpNotFound();
            }
            return View(productAditional);
        }

        // POST: ProductAditionals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ProductAditional productAditional = db.ProductAditionals.Find(id);
            db.ProductAditionals.Remove(productAditional);
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
