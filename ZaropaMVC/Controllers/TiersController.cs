using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZaropaMVC.DAL;
using ZaropaMVC.Entities;

namespace ZaropaMVC.Controllers
{
    public class TiersController : Controller
    {
        private ZaropaContext db = new ZaropaContext();

        // GET: Tiers
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            return View(db.Tiers.ToList());
        }

        // GET: Tiers/Details/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tiers tiers = db.Tiers.Find(id);
            if (tiers == null)
            {
                return HttpNotFound();
            }
            return View(tiers);
        }

        // GET: Tiers/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tiers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create([Bind(Include = "Id,Name,Price,Description")] Tiers tiers)
        {
            if (ModelState.IsValid)
            {
                db.Tiers.Add(tiers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tiers);
        }

        // GET: Tiers/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tiers tiers = db.Tiers.Find(id);
            if (tiers == null)
            {
                return HttpNotFound();
            }
            return View(tiers);
        }

        // POST: Tiers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit([Bind(Include = "Id,Name,Price,Description")] Tiers tiers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tiers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tiers);
        }

        // GET: Tiers/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tiers tiers = db.Tiers.Find(id);
            if (tiers == null)
            {
                return HttpNotFound();
            }
            return View(tiers);
        }

        // POST: Tiers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteConfirmed(int id)
        {
            Tiers tiers = db.Tiers.Find(id);
            db.Tiers.Remove(tiers);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult TiersPage()
        {
            return View(db.Tiers.ToList());
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
