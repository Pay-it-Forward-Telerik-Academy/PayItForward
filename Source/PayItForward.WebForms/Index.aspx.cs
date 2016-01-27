namespace PayItForward.WebForms.Home
{
    using System;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Ninject;
    using PayItForward.Services.Data.Contracts;
    using PayItForward.Data.Models;

    public partial class Index : Ninject.Web.PageBase
    {
        [Inject]
        public IStoryService Stories { get; set; }

        [Inject]
        public ICategoriesService Categories { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                var Qstories = SetSortByType(SortType.Value);
                var stories = CheckForCategoryAndMakeSelection(Qstories);

                var categories = Categories.GetAll().ToList();

                this.lvStories.DataSource = CheckForTitleSearch(stories).ToList();
                this.lvStories.DataBind();

                this.CategoriesMenu.DataSource = categories;
                this.CategoriesMenu.DataBind();
            }
        }

        protected void OnLatestStoryButtonClicked(object sender, EventArgs e)
        {
            ResetDataPager();
            SortType.Value = "latest";
            var Qstories = SetSortByType(SortType.Value);
            var stories = CheckForCategoryAndMakeSelection(Qstories);
            this.lvStories.DataSource = stories.ToList();
            this.lvStories.DataBind();
        }

        protected void OnMostPopularStoryButtonClicked(object sender, EventArgs e)
        {
            ResetDataPager();
            SortType.Value = "popular";
            var Qstories = SetSortByType(SortType.Value);
            var stories = CheckForCategoryAndMakeSelection(Qstories);
            this.lvStories.DataSource = stories.ToList();
            this.lvStories.DataBind();
        }

        protected void OnAlmostThereStoryButtonClicked(object sender, EventArgs e)
        {
            ResetDataPager();
            SortType.Value = "almost";
            var Qstories = SetSortByType(SortType.Value);
            var stories = CheckForCategoryAndMakeSelection(Qstories);
            this.lvStories.DataSource = stories.ToList();
            this.lvStories.DataBind();
        }

        protected void OnCriticalStoryButtonClicked(object sender, EventArgs e)
        {
            ResetDataPager();
            SortType.Value = "critical";
            var Qstories = SetSortByType(SortType.Value);
            var stories = CheckForCategoryAndMakeSelection(Qstories);
            this.lvStories.DataSource = stories.ToList();
            this.lvStories.DataBind();
        }

        protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (lvStories.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            SortType.Value = SortType.Value;
            var Qstories = SetSortByType(SortType.Value);
            var stories = CheckForCategoryAndMakeSelection(Qstories);
            this.lvStories.DataSource = stories.ToList();
            this.lvStories.DataBind();
        }

        private void ResetDataPager()
        {
            var dataPager = lvStories.FindControl("DataPager1") as DataPager;
            (dataPager).SetPageProperties(0, dataPager.MaximumRows, false);
        }

        private IQueryable<Story> CheckForCategoryAndMakeSelection(IQueryable<Story> list)
        {
            int categoryId;
            if (int.TryParse(Request.QueryString["CategoryId"], out categoryId))
            {
                list = list.Where(x => x.CategoryId == categoryId);
            }

            return list;
        }

        private IQueryable<Story> SetSortByType(string sort)
        {
            if (sort == "latest")
                return Stories.GetAll().OrderByDescending(x => x.PostDate);
            if (sort == "popular")
                return Stories.GetAll().OrderByDescending(x => x.Likes.Count);
            if (sort == "almost")
                return Stories.GetAll().OrderBy(x => x.GoalAmount - x.CollectedAmount);
            if (sort == "critical")
                return Stories.GetAll().OrderByDescending(x => (x.GoalAmount - x.CollectedAmount) / ((x.ExpirationDate - DateTime.Now).TotalDays));
            return Stories.GetAll();
        }


        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            var parameter = ((TextBox)lvStories.FindControl("Search")).Text;
            var url = this.Request.Url.ToString();

            if (this.Request.QueryString.Count == 0)
            {
                url += "?search=" + parameter;
            }
            else
            {
                if (this.Request.QueryString["search"] == null)
                {
                    url += "&search=" + parameter;
                }
                else
                {
                    var partial = url.Substring(0, url.IndexOf("search"));
                    url = partial  + "search=" + parameter;
                }
            }

            this.Response.Redirect(url);
        }

        private IQueryable<Story> CheckForTitleSearch(IQueryable<Story> list)
        {
            string parameter;
            if ((parameter = Request.QueryString["search"]) != null)
            {
                list = list.Where(x => x.Title.Contains(parameter));
            }

            return list;
        }
    }
}