using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using PayItForward.Services.Data.Contracts;
using Ninject;
using System.IO;

namespace PayItForward.WebForms.Story
{
    public partial class CreateStory : Ninject.Web.PageBase
    {
        [Inject]
        public ICategoriesService categories { get; set; }
        [Inject]
        public IStoryService stories { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var allCategories = categories.GetAll().ToList();
                this.DropDownListCategories.DataSource = allCategories;
                this.DropDownListCategories.DataBind();
                this.DropDownListCategories.SelectedIndex = 0;

            }
        }

        protected void OnCreateStoryButtonClicked(object sender, EventArgs e)
        {
            string userId = User.Identity.GetUserId();
            string imageUrl="";
            string documentUrl="";

            if (Image.HasFile)
            {
                string filename = Path.GetFileName(Image.FileName);
                imageUrl = Server.MapPath("~/App_Data/Images/") + filename;
                Image.SaveAs(imageUrl);
            }

            if (Document.HasFile)
            {
                string filename = Path.GetFileName(Document.FileName);
                documentUrl = Server.MapPath("~/App_Data/Documents/") + filename;
                Document.SaveAs(documentUrl);
            }

            stories.Add(this.TitleStory.Text, this.Description.Text, int.Parse(this.GoalAmount.Text), int.Parse(this.EstimatedDays.Text), int.Parse(this.DropDownListCategories.SelectedValue), userId, imageUrl, documentUrl);

        }
    }
}