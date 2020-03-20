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
    public partial class LoginView : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (this.Page.User.Identity.IsAuthenticated)
            {
                MembershipUser user = Membership.GetUser(this.Page.User.Identity.Name);
                if (user != null)
                {
                    trName.Visible = true;
                    lblName.Text = user.Comment;
                }

                trExit.Visible = true;
            }
            else
            {
                trLogin.Visible = true;
                trPswRec.Visible = true;
                trRegister.Visible = true;
            }
        }

        protected void lbtnExit_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect(Request.RawUrl);
        }
    }
}