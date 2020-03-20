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

namespace UC.UI.Controls
{
    public partial class MainMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool visible = (Page.User.IsInRole("Administrators") || Page.User.IsInRole("Editors") || Page.User.IsInRole("Contributors"));
            AdminMenu.Visible = visible;
            AdminSeparator.Visible = visible;
        }
    }
}
