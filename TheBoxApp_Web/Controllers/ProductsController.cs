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
    public class ProductsController : Controller
    {
        private Rushbox_v2Entities db = new Rushbox_v2Entities();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.ProductCategory).Include(p => p.Provider);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.ID_ProductCategory = new SelectList(db.ProductCategories, "ID_ProductCategory", "TX_ProductCategory");
            ViewBag.ID_Provider = new SelectList(db.Providers, "ID_Provider", "TX_Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Product,ID_Provider,ID_ProductCategory,TX_Name,TX_Description,NU_Price,NU_ShippingCost,BO_SpecialOffer,IM_Image,BO_Active,DT_Register,BO_Service")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_ProductCategory = new SelectList(db.ProductCategories, "ID_ProductCategory", "TX_ProductCategory", product.ID_ProductCategory);
            ViewBag.ID_Provider = new SelectList(db.Providers, "ID_Provider", "TX_Name", product.ID_Provider);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ProductCategory = new SelectList(db.ProductCategories, "ID_ProductCategory", "TX_ProductCategory", product.ID_ProductCategory);
            ViewBag.ID_Provider = new SelectList(db.Providers, "ID_Provider", "TX_Name", product.ID_Provider);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Product,ID_Provider,ID_ProductCategory,TX_Name,TX_Description,NU_Price,NU_ShippingCost,BO_SpecialOffer,IM_Image,BO_Active,DT_Register,BO_Service")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ProductCategory = new SelectList(db.ProductCategories, "ID_ProductCategory", "TX_ProductCategory", product.ID_ProductCategory);
            ViewBag.ID_Provider = new SelectList(db.Providers, "ID_Provider", "TX_Name", product.ID_Provider);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
