using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MyCouch;
using MyCouch.AspNet.Identity;

namespace CSICDemoDec
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles); 
            CSICDemoDec.App_Start.TestConfig.RegisterData("");
            MyMethodAsync();
        }

        async static void MyMethodAsync()
       {

            using (var client = new MyCouchClient(CreateUri()))
            {
                await client.Database.PutAsync();
                try
                {
                    await client.EnsureDesignDocsExists();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                    if(ex.Message=="Could not create design document 'userstore' with required views.\r\n[Error]: conflict.\r\n[Reason]: Document update conflict..")
                    { 
                        // do a get to ignore revisions
                       // Ignore  as template must exist to have revisions! 
                    }

                }
            }
        }

        protected void Application_BeginRequest()
        {
            HttpContext.Current.Items["MyCouchClient"] = new MyCouchClient(CreateUri());
        }

        protected void Application_EndRequest()
        {
            var client = HttpContext.Current.Items["MyCouchClient"] as IMyCouchClient;
            if (client != null)
                client.Dispose();
        }

        private static Uri CreateUri()
        {

            string COUCHDB_URL =  System.Configuration.ConfigurationManager.AppSettings["COUCHDB_URL"];
            if (COUCHDB_URL == "")
            {
                COUCHDB_URL = "http://127.0.0.1:5984";
            }
            string DATABASE_NAME = System.Configuration.ConfigurationManager.AppSettings["DATABASE_NAME"];
            if(DATABASE_NAME=="")
            {
                DATABASE_NAME = "aspnet-identity";
            }
            string DATABASE_USER = System.Configuration.ConfigurationManager.AppSettings["DATABASE_USER"];
            if(DATABASE_USER=="")
            {
                DATABASE_USER="admin";
            }
            string DATABASE_PASS = System.Configuration.ConfigurationManager.AppSettings["DATABASE_PASS"];
            if(DATABASE_PASS=="")
            {
                DATABASE_PASS="Salmon24";
            } 
               
            return new MyCouchUriBuilder(COUCHDB_URL)
                    .SetDbName(DATABASE_NAME)
                    .SetBasicCredentials(DATABASE_USER, DATABASE_PASS)
                    .Build();
          
        }
    }
}
