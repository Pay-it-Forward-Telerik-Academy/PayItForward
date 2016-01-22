using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using PayItForward.Services.Data.Contracts;
using Ninject;

namespace PayItForward.WebForms
{
    public partial class Donate : System.Web.UI.Page
    {
        [Inject]
        public ICategoriesService categories { get; set; }
        [Inject]
        public IStoryService stories { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var countries = Common.Countries.GetAllCountries();
            var story = this.stories.GetById(1).FirstOrDefault();

            this.DropDownListCountries.DataSource = countries;
            this.DropDownListCountries.DataBind();

            this.Username.Enabled = false;
            this.Email.Enabled = false;

            this.Username.Text = User.Identity.GetUserName();
            this.Email.Text = User.Identity.GetUserName();

            this.storyImage.Src = story.ImageUrl;
            this.cardTitle.InnerText = story.Title;
            this.Description.InnerText = story.Description;
        }

        protected void CreateDonation(object sender, EventArgs e)
        {

        }
    }
}