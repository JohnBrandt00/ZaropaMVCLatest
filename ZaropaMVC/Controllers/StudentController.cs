using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZaropaMVC.Models;

namespace ZaropaMVC.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            StudentModels model = new StudentModels();
              
            return PartialView("_student",model);
        }
    }
}