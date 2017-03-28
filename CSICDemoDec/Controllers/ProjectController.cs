using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSICDemoDec.Utils;

namespace CSICDemoDec.Controllers
{
    public class ProjectController : Controller
    {
        //
        // GET: /Project/
        public ActionResult Index( string name)
        {
            CSICDemoDec.Models.Project _currentproject = CSICDemoDec.App_Start.TestConfig.TEST_PROJECTLIST[name];


            Success(string.Format("<b>{0}</b>checked out project: {1} from database.", _currentproject.ProjectUsersList[0].ProjectUserName, _currentproject.ProjectName), true);
            return View(_currentproject); 

        }

        // GET: /Project/Timeline
        public ActionResult TimeLine(string name)
        { 
                 CSICDemoDec.Models.Project _currentproject = CSICDemoDec.App_Start.TestConfig.TEST_PROJECTLIST[name];
                 _currentproject.ProjectTimelineList.Initialize(CSICDemoDec.App_Start.TestConfig.TEST_PROJECTLIST[name]);
                 return View(_currentproject.ProjectTimelineList); 
        }
        public ActionResult UpLoad()
        {
            //foreach (string upload in Request.Files)
            //{
            //    if (!Request.Files[upload].HasFile()) continue;
            //    string path = AppDomain.CurrentDomain.BaseDirectory + "uploads/";
            //    string filename = System.IO.Path.GetFileName(Request.Files[upload].FileName);
            //    Request.Files[upload].SaveAs(System.IO.Path.Combine(path, filename));
            //}
            return View();
        }
        public ActionResult RealtimeSensor(string name)
        {
            return View();
        }

        // GET: /Project/Timeline
        public ActionResult Map(string name)
        {
            CSICDemoDec.Models.Project _currentproject = CSICDemoDec.App_Start.TestConfig.TEST_PROJECTLIST[name];

            return View(_currentproject.ProjectTimelineList);
        }



        // GET: /Project/AddTimelineItem
        public ActionResult AddTimelineItem(int i)
        {
            CSICDemoDec.Models.TimeLineItem item = new CSICDemoDec.Models.TimeLineItem();  
            return View(item); 
        }
        


        // GET: /Project/AddTimelineItem
        public ActionResult CreateTimelineItem(CSICDemoDec.Models.TimeLineItem t)
        {
            CSICDemoDec.Models.Project _currentproject = CSICDemoDec.App_Start.TestConfig.TEST_PROJECTLIST[t.TimeLineItemProjectID];
            if (_currentproject!=null)
           {
               _currentproject.ProjectTimelineList.Add(t);
             Success(string.Format("<b>{0}</b> was successfully added to the database.", t.TimeLineItemHeadline), true);
            return RedirectToAction("Timeline", "Project");
           }
            else
            {
                Danger("Looks like something went wrong. Please check your form.");
                return RedirectToAction("Index"); 
            }
        }

        //
        // GET: /Project/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Project/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Project/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Project/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Project/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public void Success(string message, bool dismissable = false)
        {
            AddAlert( CSICDemoDec.Utils.AlertStyles.Success, message, dismissable);
        }

        public void Information(string message, bool dismissable = false)
        {
            AddAlert(CSICDemoDec.Utils.AlertStyles.Information, message, dismissable);
        }

        public void Warning(string message, bool dismissable = false)
        {
            AddAlert(CSICDemoDec.Utils.AlertStyles.Warning, message, dismissable);
        }

        public void Danger(string message, bool dismissable = false)
        {
            AddAlert(CSICDemoDec.Utils.AlertStyles.Danger, message, dismissable);
        }

        private void AddAlert(string alertStyle, string message, bool dismissable)
        {
            var alerts = TempData.ContainsKey(CSICDemoDec.Utils.Alert.TempDataKey)
                ? (List<CSICDemoDec.Utils.Alert>)TempData[CSICDemoDec.Utils.Alert.TempDataKey]
                : new List<CSICDemoDec.Utils.Alert>();

            alerts.Add(new CSICDemoDec.Utils.Alert
            {
                AlertStyle = alertStyle,
                Message = message,
                Dismissable = dismissable
            });

            TempData[CSICDemoDec.Utils.Alert.TempDataKey] = alerts;
        }
         
    }
}
