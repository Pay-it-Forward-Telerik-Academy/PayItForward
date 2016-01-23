namespace PayItForward.WebForms.Home
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    using System.Web;
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

                this.lvCustomers.DataSource = stories;
                this.lvCustomers.DataBind();

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
            this.lvCustomers.DataSource = stories;
            this.lvCustomers.DataBind();
        }

        protected void OnMostPopularStoryButtonClicked(object sender, EventArgs e)
        {
            ResetDataPager();
            SortType.Value = "popular";
            var Qstories = SetSortByType(SortType.Value);
            var stories = CheckForCategoryAndMakeSelection(Qstories);
            this.lvCustomers.DataSource = stories;
            this.lvCustomers.DataBind();
        }

        protected void OnAlmostThereStoryButtonClicked(object sender, EventArgs e)
        {
            ResetDataPager();
            SortType.Value = "almost";
            var Qstories = SetSortByType(SortType.Value);
            var stories = CheckForCategoryAndMakeSelection(Qstories);
            this.lvCustomers.DataSource = stories;
            this.lvCustomers.DataBind();
        }

        protected void OnCriticalStoryButtonClicked(object sender, EventArgs e)
        {
            ResetDataPager();
            SortType.Value = "critical";
            var Qstories = SetSortByType(SortType.Value);
            var stories = CheckForCategoryAndMakeSelection(Qstories);
            this.lvCustomers.DataSource = stories;
            this.lvCustomers.DataBind();
        }

        protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (lvCustomers.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            SortType.Value = SortType.Value;
            var Qstories = SetSortByType(SortType.Value);
            var stories = CheckForCategoryAndMakeSelection(Qstories);
            this.lvCustomers.DataSource = stories;
            this.lvCustomers.DataBind();
        }

        private void ResetDataPager()
        {
            var dataPager = lvCustomers.FindControl("DataPager1") as DataPager;
            (dataPager).SetPageProperties(0, dataPager.MaximumRows, false);
        }

        private List<Story> CheckForCategoryAndMakeSelection(IQueryable<Story> list)
        {
            int categoryId;
            if (int.TryParse(Request.QueryString["CategoryId"],out categoryId))
            {
              list =  list.Where(x => x.CategoryId == categoryId);
            }

            return list.ToList();
        }

        private IQueryable<Story> SetSortByType(string sort)
        {
            if (sort == "latest")
                return Stories.GetAll().OrderByDescending(x => x.PostDate);
            if (sort == "popular")
                return Stories.GetAll().OrderByDescending(x => x.Likes);
            if (sort == "almost")
                return Stories.GetAll().OrderBy(x => x.GoalAmount - x.CollectedAmount);
            if (sort == "critical")
                return Stories.GetAll().OrderByDescending(x => (x.GoalAmount - x.CollectedAmount) / (EntityFunctions.DiffDays(x.ExpirationDate, DateTime.Now)));
            return Stories.GetAll();
        }
    }
}