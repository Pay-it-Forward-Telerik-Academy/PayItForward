using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

namespace PayItForward.WebForms.Story
{
    public partial class CreateStory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OnCreateStoryButtonClicked(object sender, EventArgs e)
        {
            var userId = User.Identity.GetUserId();
        }
    }
}