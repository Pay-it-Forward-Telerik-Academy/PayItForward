using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace PayItForward.WebForms
{
    using PayItForward.WebForms.App_Start;
    using Helpers;

    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DatabaseConfig.Initialize();
        }

        void Application_Error(object sender, EventArgs e)
        {
           
            Exception exc = Server.GetLastError();

            // Handle HTTP errors
            if (exc.GetType() == typeof(HttpException) || exc.GetType() == typeof(HttpUnhandledException))
            {
                Server.Transfer("~/ErrorPages/HttpErrorPage.aspx");
            }

            Response.Write("<h2>Global Page Error</h2>\n");
            Response.Write(
                "<p>" + exc.Message + "</p>\n");
            Response.Write("Return to the <a href='Index.aspx'>" +
                "Home Page</a>\n");

            ExceptionUtility.LogException(exc, "DefaultPage");
            ExceptionUtility.NotifySystemOps(exc);

            Server.ClearError();
        }
    }
}