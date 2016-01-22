using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

namespace PayItForward.WebForms
{
    public partial class Donate : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            var countries = Common.Countries.GetAllCountries();

            this.DropDownListCountries.DataSource = countries;
            this.DropDownListCountries.DataBind();

            this.Username.Enabled = false;
            this.Email.Enabled = false;

            this.Username.Text = User.Identity.GetUserName();
            this.Email.Text = User.Identity.GetUserName();
        }

        protected void CreateDonation(object sender, EventArgs e)
        {

        }
    }
}