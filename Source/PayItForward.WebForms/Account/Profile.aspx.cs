using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Ninject;
using PayItForward.Services.Data.Contracts;
using PayItForward.Data.Models;

namespace PayItForward.WebForms.Account
{
    public partial class Profile : System.Web.UI.Page
    {

        [Inject]
        public IUsersService users { get; set; }

        protected User CurrentUser { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var userId = this.User.Identity.GetUserId();
                this.CurrentUser = users.GetById(userId);

            }
        }
    }
}