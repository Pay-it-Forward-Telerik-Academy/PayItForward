using Ninject;
using PayItForward.Data.Models;
using PayItForward.Services.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PayItForward.WebForms.Administration
{
    public partial class UsersPanel : System.Web.UI.Page
    {
        [Inject]
        public IUsersService users { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public IQueryable<User> GridViewUsers_GetData()
        {
            return this.users.All();
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