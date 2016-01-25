namespace PayItForward.WebForms.Administration
{
    using System;
    using System.Linq;
    using PayItForward.Data.Models;
    using Ninject;
    using PayItForward.Services.Data.Contracts;
    using System.Web.UI.WebControls;
    using System.IO;
    using System.Web.UI;
    public partial class StoriesApproval : System.Web.UI.Page
    {
        [Inject]
        public IStoryService stories { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IQueryable<Story> GridViewStories_GetData()
        {
            return this.stories.GetNotApproved();
        }

        public void GridViewStories_UpdateData(int id)
        {
            Story story = this.stories.GetById(id);

            if (story == null)
            {
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }

            this.TryUpdateModel(story);

            if (ModelState.IsValid)
            {
                this.stories.Save();
            }
        }
    }
}