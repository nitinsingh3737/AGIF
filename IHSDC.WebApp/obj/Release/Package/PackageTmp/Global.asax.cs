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


        //protected void Application_BeginRequest()
        //{
        //    Response.AddHeader("X-Frame-Options", "DENY");
        //}
        //protected void Application_Error(object sender, EventArgs e)
        //{
        //    Exception ex = Server.GetLastError();

        //    HttpException httpException = ex as HttpException;
        //    var routeData = new RouteData();
        //    routeData.Values["controller"] = "Error";
        //    routeData.Values["exception"] = ex;
        //    routeData.Values["action"] = "Index";
        //    IController controller = new ErrorController();
        //    controller.Execute(new RequestContext(new HttpContextWrapper(context), routeData));
        //}
        //protected void Application_Error(object sender, EventArgs e)
        //{
        //    var app = (MvcApplication)sender;
        //    var context = app.Context;
        //    var ex = app.Server.GetLastError();
        //    context.Response.Clear();
        //    context.ClearError();
        //    var httpException = ex as HttpException;

        //    var routeData = new RouteData();
        //    routeData.Values["controller"] = "Error";
        //    routeData.Values["exception"] = ex;
        //    routeData.Values["action"] = "Index";
        //    if (httpException != null)
        //    {
        //        switch (httpException.GetHttpCode())
        //        {
        //            case 404:
        //                routeData.Values["action"] = "Index";
        //                break;
        //            case 403:
        //                routeData.Values["action"] = "Index";
        //                break;
        //            case 500:
        //                routeData.Values["action"] = "Index";
        //                break;
        //        }
        //    }
        //    IController controller = new ErrorController();
        //    controller.Execute(new RequestContext(new HttpContextWrapper(context), routeData));
        //}

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
