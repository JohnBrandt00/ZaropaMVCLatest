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
    public class ShoesController : Controller
    {
        private ZaropaContext db = new ZaropaContext();

        // GET: Shoes
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            var shoes = db.Shoes.Include(s => s.Tiers);
            return View(shoes.ToList());
        }

        // GET: Shoes/Details/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shoes shoes = db.Shoes.Find(id);
            if (shoes == null)
            {
                return HttpNotFound();
            }
            return View(shoes);
        }

        // GET: Shoes/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            ViewBag.TiersId = new SelectList(db.Tiers, "Id", "Name");
            return View();
        }

        // POST: Shoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create([Bind(Include = "Id,Name,Tier,TiersId,Genders")] Shoes shoes)
        {
            if (ModelState.IsValid)
            {
                db.Shoes.Add(shoes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TiersId = new SelectList(db.Tiers, "Id", "Name", shoes.TiersId);
            return View(shoes);
        }

        // GET: Shoes/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shoes shoes = db.Shoes.Find(id);
            if (shoes == null)
            {
                return HttpNotFound();
            }
            ViewBag.TiersId = new SelectList(db.Tiers, "Id", "Name", shoes.TiersId);
            return View(shoes);
        }

        // POST: Shoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit([Bind(Include = "Id,Name,Tier,TiersId,Genders")] Shoes shoes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shoes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TiersId = new SelectList(db.Tiers, "Id", "Name", shoes.TiersId);
            return View(shoes);
        }

        // GET: Shoes/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shoes shoes = db.Shoes.Find(id);
            if (shoes == null)
            {
                return HttpNotFound();
            }
            return View(shoes);
        }

        // POST: Shoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteConfirmed(int id)
        {
            Shoes shoes = db.Shoes.Find(id);
            db.Shoes.Remove(shoes);
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
