using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace UC.UI
{
   public partial class Login : BasePage
   {
      protected void Page_Load(object sender, EventArgs e)
      {
          if (this.User.Identity.IsAuthenticated)
          {
              if (String.IsNullOrEmpty(Log.ReturnUrl))
              {
                  Response.Redirect("~/");
              }
              else
              {
                  Response.Redirect(Log.ReturnUrl);
              }
          }

          BreadCrumb.AddInActiveLink("Авторизация");

         //lblInsufficientPermissions.Visible = this.User.Identity.IsAuthenticated;
         //lblLoginRequired.Visible = (!this.User.Identity.IsAuthenticated &&
         //   string.IsNullOrEmpty(this.Request.QueryString["loginfailure"]));
         //lblInvalidCredentials.Visible = (this.Request.QueryString["loginfailure"] != null &&
         //   this.Request.QueryString["loginfailure"] == "1");
      }
   }
}