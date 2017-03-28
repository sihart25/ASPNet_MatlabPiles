using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSICDemoDec.Controllers
{
    public class VisController : Controller
    {
        //
        // GET: /Vis/
        public ActionResult Index()
        {
            return View();
        }
        //
        // GET: /Vis/
        public ActionResult network()
        {
            return View();
        }
        public ActionResult graph2d()
        {
            return View();
        }
        public ActionResult graph3d()
        {
            return View();
        }
        public ActionResult timeline()
        {
            return View();
        }
	}
}