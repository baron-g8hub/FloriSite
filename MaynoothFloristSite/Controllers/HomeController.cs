using MFlorist.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaynoothFloristSite.Controllers
{
    public class HomeController : Controller
    {
        private FlowersdbEntities db = new FlowersdbEntities();
         /// <summary>
         /// //////////////////////////////////////////////////////////////////////
         /// </summary>
         /// <returns></returns>
        // GET: Home
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }


        public ActionResult IndexVM()
        {
            using (db)
            {
                var employeeList = db.Products.ToList();
                return Json(employeeList, JsonRequestBehavior.AllowGet);
            }
        }
    }
}