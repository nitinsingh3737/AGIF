using IHSDC.WebApp.Controllers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using iTextSharp.text.log;
using System.ComponentModel;
using System.Globalization;
using IHSDC.WebApp.Models;
using System.Web.Helpers;

namespace IHSDC.WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
           
            System.Web.Helpers.AntiForgeryConfig.SuppressXFrameOptionsHeader = true;
            ApplicationDatabaseHelper.Initialize();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            CultureInfo cInf = new CultureInfo("en-ZA", false);
            // NOTE: change the culture name en-ZA to whatever culture suits your needs

            cInf.DateTimeFormat.DateSeparator = "/";
            cInf.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";


            
        }


        public void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            string referer = Request.ServerVariables["HTTP_REFERER"];
            string login = Request.CurrentExecutionFilePath;
            if (referer == null && login != "/")
            {
                if ((referer == null && login != "/Account/Login"))
                {
                    Response.Redirect("/Account/Login");  
                }
            }
        }


    }
}
