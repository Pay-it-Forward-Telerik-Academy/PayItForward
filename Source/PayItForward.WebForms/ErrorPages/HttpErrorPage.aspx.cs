using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PayItForward.WebForms.Helpers;

namespace PayItForward.WebForms.ErrorPages
{
    public partial class HttpErrorPage : System.Web.UI.Page
    {
        protected HttpException ex = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            ex = (HttpException)Server.GetLastError();
            int httpCode = ex.GetHttpCode();

            // Filter for Error Codes and set text

            if (httpCode == 401)
                ex = new HttpException
                    (httpCode, "Request Unauthorized!", ex);
            else
            if (httpCode == 403)
                ex = new HttpException
                    (httpCode, "Forbidden Request!",ex);
            else
            if (httpCode >= 400 && httpCode < 500)
                ex = new HttpException
                    (httpCode, "File not found!", ex);
            else
            if (httpCode > 499)
                ex = new HttpException
                    (ex.ErrorCode, "Oops...! :(", ex);
            else
                ex = new HttpException
                    (httpCode, "Unexpected Exception!", ex);

            // Log the exception and notify system operators
            ExceptionUtility.LogException(ex, "HttpErrorPage");
            ExceptionUtility.NotifySystemOps(ex);

            // Fill the page fields
            exCode.Text = httpCode.ToString();
            exMessage.Text = ex.Message;
            exTrace.Text = ex.StackTrace;


            // Show Inner Exception fields for local access
            if (ex.InnerException != null)
            {
                innerTrace.Text = ex.InnerException.StackTrace;
                InnerErrorPanel.Visible = Request.IsLocal;
                innerMessage.Text = string.Format("HTTP {0}: {1}",
                  httpCode, ex.InnerException.Message);
            }
            // Show Trace for local access
            exTrace.Visible = Request.IsLocal;

            // Clear the error from the server
            Server.ClearError();
        }
    }
}