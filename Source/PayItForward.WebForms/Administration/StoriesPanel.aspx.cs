namespace PayItForward.WebForms.Administration
{
    using System;
    using System.Linq;
    using PayItForward.Data.Models;
    using Ninject;
    using PayItForward.Services.Data.Contracts;

    public partial class StoriesPanel : System.Web.UI.Page
    {
        [Inject]
        public IStoryService stories { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Story> GridViewStories_GetData()
        {
            return this.stories.GetAll();
        }

        public void GridViewStories_UpdateItem(int id)
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

        public void GridViewStories_DeleteItem(int id)
        {
            Story story = this.stories.GetById(id);

            if (story == null)
            {
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }

            this.stories.RemoveById(id);
        }
    }
}