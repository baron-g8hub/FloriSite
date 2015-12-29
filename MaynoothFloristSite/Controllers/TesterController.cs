using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaynoothFloristSite.Controllers
{
    public class TesterController : Controller
    {
        // GET: Tester
        public ActionResult Index()
        {
            var tester = 0;

            return View();
        }
    }
}