namespace PayItForward.WebForms.Administration
{
    using Ninject;
    using PayItForward.Services.Data.Contracts;
    using System;

    public partial class AdminPanel : System.Web.UI.Page
    {
        [Inject]
        public IUsersService users { get; set; }

        [Inject]
        public IStoryService stories { get; set; }

        [Inject]
        public IDonationService donations { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.usersCount.InnerText = this.users.Count().ToString();
                this.storiesCount.InnerText = this.stories.Count().ToString();
                this.donationCount.InnerText = this.donations.Count().ToString();
            }
        }
    }
}