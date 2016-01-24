using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using PayItForward.Data.Models;

namespace PayItForward.WebForms.Account
{
    using Common;
    using PayItForward.WebForms.Helpers;
    using System.IO;
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<UserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            string avatarUrl = "";
            if (Avatar.HasFile)
            {
                string filename = Path.GetFileName(Avatar.FileName);
                avatarUrl = "../Resources/Avatars/" + filename;
                Avatar.SaveAs(Server.MapPath("~/Resources/Avatars/") + filename);
            }
            var user = new User() { UserName = UserName.Text, Email = Email.Text, AvatarUrl = avatarUrl};

            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {

                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");
                manager.AddToRole(user.Id, GlobalConstants.RoleUser);
                signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}