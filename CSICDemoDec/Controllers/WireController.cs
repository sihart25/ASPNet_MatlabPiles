using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSICDemoDec.Controllers
{
    public class WireController : Controller
    {
        //
        // GET: /Wire/
        public ActionResult Index()
        {
            return View();
        }  
        // GET: /Project/Details/5
        public ActionResult Details(string id)
        {
            return View();
        }
        //public ActionResult Download(string name)
        //{
        //    var document = name;
        //    var cd = new System.Net.Mime.ContentDisposition
        //    {
        //        // for example foo.bak
        //        FileName = document.FileName, 

        //        // always prompt the user for downloading, set to true if you want 
        //        // the browser to try to show the file inline
        //        Inline = false, 
        //    };
        //    Response.AppendHeader("Content-Disposition", cd.ToString());
        //    return File(document.Data, document.ContentType);
        //}
	}
}