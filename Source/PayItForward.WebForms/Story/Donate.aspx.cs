using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using PayItForward.Services.Data.Contracts;
using Ninject;
using PayItForward.Common;
using PayItForward.WebForms.Controls.Notifier;

namespace PayItForward.WebForms
{
    public partial class Donate : System.Web.UI.Page
    {
        [Inject]
        public IDonationService donations { get; set; }

        [Inject]
        public IStoryService stories { get; set; }

        [Inject]
        public IUsersService users { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                var countries = Countries.GetAllCountries();
                int storyId;

                if (int.TryParse(Request.QueryString["id"], out storyId))
                {


                    var story = this.stories.GetById(storyId);
                    this.DropDownListCountries.DataSource = countries;
                    this.DropDownListCountries.DataBind();
                    this.storyDetails.HRef = "/Story/Details?id=" + story.Id;

                    this.Username.Enabled = false;
                    this.Email.Enabled = false;

                    var currentUser = this.users.GetById(User.Identity.GetUserId());

                    this.Username.Text = currentUser.UserName;
                    this.Email.Text = currentUser.Email;

                    this.storyImage.Src = story.ImageUrl;
                    this.cardTitle.InnerText = story.Title;
                    this.Description.InnerText = story.Description;

                    var percentage = this.CalculatePercentage(story.CollectedAmount, story.GoalAmount);
                    this.collectedAmount.InnerText = "$" + story.CollectedAmount.ToString();
                    this.goalAmount.InnerText = "$" + story.GoalAmount.ToString();

                    this.progressBar.Style.Add("width", percentage.ToString() + "%");
                }
                else
                {
                    this.Response.Redirect("~/Index.aspx");
                }
            }
        }

        protected void CreateDonation(object sender, EventArgs e)
        {
            int storyId = int.Parse(Request.QueryString["id"]);
            var story = this.stories.GetById(storyId);
            this.donations.Add(User.Identity.GetUserId(), storyId, int.Parse(this.Amount.Text), this.DropDownListCountries.SelectedItem.Text);
            var percentage = this.CalculatePercentage(story.CollectedAmount, story.GoalAmount);
            this.collectedAmount.InnerText = "$" + story.CollectedAmount.ToString();
            this.goalAmount.InnerText = "$" + story.GoalAmount.ToString();

            this.progressBar.Style.Add("width", percentage.ToString() + "%");
            //this.ProgressPanel.Update();
            //Notifier notifier = new Notifier();
            //notifier.Message("You donate successful!");


        }

        protected double CalculatePercentage(double collected, double goal)
        {
            var percentage = (collected / goal) * 100;
            return percentage;
        }
    }
}