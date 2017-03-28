
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc; 
using System.Threading.Tasks;
using CSICDemoDec.Models;

namespace CSICDemoDec.Controllers
{
    public class ChartJSController : Controller
    {

        public ActionResult MakeGraph(ChartJSModel model)
        {
            
            if (ModelState.IsValid)
            {
              
            return View("MakeGraph");
            }
            else
            {
             //TODO::SIMON   "Error"
                return RedirectToAction("Index", "Home");
            } 

        }
    }
}