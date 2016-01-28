using Ninject;
using PayItForward.Data.Models;
using PayItForward.Services.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PayItForward.WebForms.Controls.Pager.CustomDelegates;

namespace PayItForward.WebForms.Administration
{
    public partial class UsersPanel : System.Web.UI.Page
    {
        [Inject]
        public IUsersService users { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                int totalPages = this.users.All().Count();
                custPager.TotalPages = totalPages % GridViewUsers.PageSize == 0 ? totalPages / GridViewUsers.PageSize : totalPages / GridViewUsers.PageSize + 1;
            }
        }

        public IQueryable<User> GridViewUsers_GetData()
        {
            return this.users.All();
        }

        protected void custPager_PageChanged(object sender, CustomPageChangeArgs e)
        {

            this.GridViewUsers.PageSize = e.CurrentPageSize;
            this.GridViewUsers.PageIndex = e.CurrentPageNumber-1;

            int totalPages = this.users.All().Count();
            custPager.TotalPages = totalPages % GridViewUsers.PageSize == 0 ? totalPages / GridViewUsers.PageSize : totalPages / GridViewUsers.PageSize + 1;
        }

       
        public void GridViewUsers_UpdateItem(string id)
        {
            User user = this.users.GetById(id);

            if (user == null)
            {
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }

            this.TryUpdateModel(user);

            if (ModelState.IsValid)
            {
                this.users.Update();
            }
        }

        public void GridViewUsers_DeleteItem(string id)
        {
            User user = this.users.GetById(id);

            if (user == null)
            {
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }

            this.TryUpdateModel(user);

            if (ModelState.IsValid)
            {
                this.users.Delete(id);
            }
        }
    }
}