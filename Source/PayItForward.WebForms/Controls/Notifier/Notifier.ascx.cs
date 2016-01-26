using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PayItForward.WebForms.Controls.Notifier
{
    public partial class Notifier : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Message(string msg)
        {
            IncludeJavaScript();

            var page = HttpContext.Current.CurrentHandler as Page;
           
            page.ClientScript.RegisterStartupScript(this.GetType(), "Notify", "javascript:Materialize.toast('" + msg +", 3000);", true);
        }

        public void IncludeJavaScript()
        {
            var page = HttpContext.Current.CurrentHandler as Page;
            ClientScriptManager cs = page.ClientScript;

            string jqueryURL = this.TemplateSourceDirectory +
                "../../Scripts/jquery-1.10.2.js";
            if (!cs.IsStartupScriptRegistered(jqueryURL))
            {
                cs.RegisterClientScriptInclude(jqueryURL, jqueryURL);
            }


            // Include the jQuery library (if not already included)
            string matirializeURL = this.TemplateSourceDirectory +
                "../../Scripts/materialize.js";
            if (!cs.IsStartupScriptRegistered(matirializeURL))
            {
                cs.RegisterClientScriptInclude(matirializeURL, matirializeURL);
            }
        }
    }
}