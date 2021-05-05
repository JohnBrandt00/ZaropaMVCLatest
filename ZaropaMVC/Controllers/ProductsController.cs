using QRCoder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using ZaropaMVC.DAL;
using ZaropaMVC.Entities;

namespace ZaropaMVC.Controllers
{
    public class ProductsController : Controller
    {
        private ZaropaContext db = new ZaropaContext();

        // GET: Products
        [Authorize(Roles ="Administrator")]
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Shoes);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Details(int? id)
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
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            ViewBag.ShoesId = new SelectList(db.Shoes, "Id", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create([Bind(Include = "Id,Name,Price,Description,BuyButton,Tier,ShoeName,Genders,ShoesId,RetailPrice")] Product product,HttpPostedFileBase ImageData)
        {
            

            if (ModelState.IsValid)
            {

                if (ImageData != null)
                {
                    ImageData.SaveAs(HttpContext.Server.MapPath("~/Images/")
                                                          + ImageData.FileName);
                    product.ImageUrl = ImageData.FileName;

                    //WebImage img = new WebImage(ImageData.InputStream);
                    //if(img.Width <1067 || img.Width > 1067)
                    //{
                    //    img.Resize(1067, 1067);
                    //    img.Save(HttpContext.Server.MapPath("~/Images/") + ImageData.FileName);
                    //    product.ImageUrl = ImageData.FileName;
                    //}


                    db.Products.Add(product);
                    db.SaveChanges();

                }

                return RedirectToAction("Index");
            }

            ViewBag.ShoesId = new SelectList(db.Shoes, "Id", "Name", product.ShoesId);
            return View(product);
        }

        // GET: Products/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int? id)
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
            ViewBag.ShoesId = new SelectList(db.Shoes, "Id", "Name", product.ShoesId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit([Bind(Include = "Id,Name,Price,Description,BuyButton,ImageUrl,Tier,ShoeName,Genders,ShoesId,RetailPrice")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ShoesId = new SelectList(db.Shoes, "Id", "Name", product.ShoesId);
            return View(product);
        }

        // GET: Products/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int? id)
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
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteConfirmed(int id)
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
        

        public ActionResult ProductPage(Genders genders)
        {
            ViewBag.gender = genders;
            return View();
        }

        public ActionResult ShowProduct(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var outfit = db.Products.Find(id);
            
            if(outfit == null)
            {
                return HttpNotFound();
            }


            return View(outfit);
        }

        public ActionResult GetTiers(Genders genders )
        {
            ViewBag.gender = genders;
            var model = db.Tiers.ToList();

            return PartialView("_TierList", model);
        }

     

    }
}
