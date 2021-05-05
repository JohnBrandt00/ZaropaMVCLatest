using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZaropaMVC.Entities;

namespace ZaropaMVC.Controllers
{
    public class TradeshowController : Controller
    {

        public ActionResult GenerateUrlQR(string url,string label ,string col1  , string col2 )
        {

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData); 
            var qrCodeAsBitmap = qrCode.GetGraphic(30, Color.FromName(col1), Color.FromName(col2), (Bitmap)Bitmap.FromFile(Server.MapPath("~/Content/ZaropaLogo.png")));
            //using (var stream = new MemoryStream())
            //{
            //    qrCodeAsBitmap.Save(stream, ImageFormat.Png);
            //    return File(stream.ToArray(), "image/png");

            //}

            using(Graphics gs = Graphics.FromImage(qrCodeAsBitmap))
            {
                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Center;
                gs.DrawString(label, new Font("Rubik", 50), Brushes.Black, new Point(qrCodeAsBitmap.Width/2, (int)(qrCodeAsBitmap.Height *0.95)),sf) ;
                 
                using (var stream = new MemoryStream())
                {
                    qrCodeAsBitmap.Save(stream, ImageFormat.Png);
                    return File(stream.ToArray(), "image/png");

                }

            }

        }

        public ActionResult AutoFillDB()
        {
            SalesController sales = new SalesController();
            sales.Create();

            Sales sale = new Sales();
            sale.Employees = Employees.Arietty;
            sale.DateTime = DateTime.Now;
            sale.FirmName = "Fill Out!";
            sale.FirmEmail = "fill out";
            sale.FirmPhoneNumber = "516-555-5555";
            sale.Profit = 500;
            sale.SaleStatus = SaleStatus.ProcessingSale;
            sales.Create(sale);
            return RedirectToAction("index", "home");
        }


        // GET: Tradeshow
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Purchase(Employees employees,string Url)
        {

            SalesController sales = new SalesController();
            sales.Create();

            Sales sale = new Sales();
            sale.Employees = employees;
            sale.DateTime = DateTime.Now;
            sale.FirmName = "FILL";
            sale.FirmEmail = "FILL@Zaropa.com";
            sale.FirmPhoneNumber = "000-000-0000";
            sale.Profit = 0;
            sale.SaleStatus = SaleStatus.ProcessingSale;
            sales.Create(sale);
            ViewBag.Employee = employees;
            ViewBag.Url = Url;
            return View(  );
        }


    }
}