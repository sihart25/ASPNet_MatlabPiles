using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSICDemoDec.Models; 

namespace CSICDemoDec.Controllers
{
    public class HomeController : System.Web.Mvc.Controller
    {


        private static OpenProjectArray GetProjectList()
        { 
            System.IO.DirectoryInfo root = new System.IO.DirectoryInfo(HttpRuntime.BinDirectory + "Content\\Projects");
            var files = root.EnumerateDirectories();
            OpenProjectArray retvals = new OpenProjectArray();
            foreach (var f in files)
            {
                OpenProjectItem op = new OpenProjectItem(f.Name, f.Name.ToLower(), new Uri(f.FullName)); 
                retvals.Add(op);
            }
            return retvals;
        }

        public ActionResult Home()
        {
            if (User.Identity.IsAuthenticated)
            {

                var models = GetProjectList();
                return View(models);
            }else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Index()
        {

            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Message = "Logged in as:"+User.Identity.Name.ToString();

                return RedirectToAction("Home", "Home");
            }
            else
            {
                ViewBag.Message = " Please Login.";
                return View();
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = " Sensor Database description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Us.";

            return View();
        }

        public ActionResult Map()
        {
            ViewBag.Message = "Your Map page.";

            return View();
        }

        public ActionResult Project(string i)
        {  
            return RedirectToAction("Index", "Project", i);
        }

    } 
}