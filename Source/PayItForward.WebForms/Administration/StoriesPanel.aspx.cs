namespace PayItForward.WebForms.Administration
{
    using System;
    using System.Linq;
    using PayItForward.Data.Models;
    using Ninject;
    using PayItForward.Services.Data.Contracts;
    using Controls.Pager.CustomDelegates;

    public partial class StoriesPanel : System.Web.UI.Page
    {
        [Inject]
        public IStoryService stories { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int totalPages = this.stories.GetAll().Count();
                custlinkPager.TotalPages = totalPages % GridViewStories.PageSize == 0 ? totalPages / GridViewStories.PageSize : totalPages / GridViewStories.PageSize + 1;
            }

        }

        protected void custLinkPager_PageChanged(object sender, CustomPageChangeArgs e)
        {
            int totalPages = this.stories.GetAll().Count();
            custlinkPager.TotalPages = totalPages % GridViewStories.PageSize == 0 ? totalPages / GridViewStories.PageSize : totalPages / GridViewStories.PageSize + 1;
            GridViewStories.PageIndex = e.CurrentPageNumber -1;

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