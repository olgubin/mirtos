using System;
using System.Web;

namespace UC.UI.Controls
{
    public partial class MainMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool visible = (Page.User.IsInRole("Administrators") || Page.User.IsInRole("Editors") || Page.User.IsInRole("Contributors"));
            _adminMenu.Visible = visible;
            _adminSeparator.Visible = visible;

            this.DataBind();

            //string url = SeoHelper.GetAbsoluteUrl("About.aspx");
            //lblAbout.NavigateUrl = url;



            //HttpContext context = HttpContext.Current;

            //string scheme = context.Request.Url.Scheme;
            //string host = context.Request.Url.Host;
            //string port = context.Request.Url.Port > 0 ? ":" + context.Request.Url.Port.ToString() : "";
            //string url = this.ResolveUrl("~/About.aspx");

            //string res = scheme + "://" + host + port + "/" + url;
        }
    }
}
