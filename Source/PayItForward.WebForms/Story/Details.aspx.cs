using Ninject;
using PayItForward.Services.Data.Contracts;
using System;
using System.Linq;

namespace PayItForward.WebForms.Story
{
    public partial class Details : Ninject.Web.PageBase
    {
        [Inject]
        public ICategoriesService categories { get; set; }
        [Inject]
        public IStoryService stories { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //int storyId = int.Parse(this.Request.QueryString["id"]);
                int storyId;

                int.TryParse(Request.QueryString["id"], out storyId);

                var story = stories.GetById(storyId);
                this.storyTitle.InnerText = story.Title;
                this.imageStory.ImageUrl = story.ImageUrl;
                this.storyDescription.InnerText = story.Description;
                this.likes.InnerText = story.Likes.ToString();

                this.CommentsRepeater.DataSource = story.Comments.ToList();
                this.CommentsRepeater.DataBind();


                var percentage = this.CalculatePercentage(story.CollectedAmount, story.GoalAmount);
                this.collectedAmount.InnerText = "$" + story.CollectedAmount.ToString();
                this.goalAmount.InnerText = "$" + story.GoalAmount.ToString();

                this.progressBar.Style.Add("width", percentage.ToString() + "%");


            }
        }


        protected double CalculatePercentage(double collected, double goal)
        {
            var percentage = (collected / goal) * 100;
            return percentage;
        }
    }
}