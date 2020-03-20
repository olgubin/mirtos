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
    public partial class Login : System.Web.UI.UserControl
    {
        string _returnUrl = "";
        public string ReturnUrl
        {
            get{ return _returnUrl; }
            set{ _returnUrl = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                (this.Page as BasePage).SaveLastPage();
            }
        }

        protected void btnEnter_Click(object sender, EventArgs e)
        {
            valRequirePassword.Validate();
            valRequireUserName.Validate();
            if (valRequirePassword.IsValid & valRequireUserName.IsValid)
            {
                string userName = Membership.GetUserNameByEmail(UserName.Text);
                if (Membership.ValidateUser(userName, Password.Text))
                {
                    FormsAuthentication.SetAuthCookie(userName, true);

                    if (String.IsNullOrEmpty(ReturnUrl))
                    {
                        //string redirectUrl = FormsAuthentication.GetRedirectUrl(userName, true);
                        //string redirectUrl = (this.Page as BasePage).LastPage;

                        //if (String.IsNullOrEmpty(redirectUrl))
                        //{

                            string DestinationPageUrl = string.Empty;
                            DestinationPageUrl = Page.Request.QueryString["ReturnUrl"];
                            if (string.IsNullOrEmpty(DestinationPageUrl))
                                DestinationPageUrl = "~/Default.aspx";

                            //Response.Redirect(FormsAuthentication.DefaultUrl);
                            //Response.Redirect(Request.Url.PathAndQuery);  //обновление самой страницы
                            //FormsAuthentication.RedirectFromLoginPage(userName, true);
                             Response.Redirect(DestinationPageUrl);  //обновление самой страницы
                        //}
                        //else
                        //{
                        //    Response.Redirect(redirectUrl);
                        //}
                    }
                    else
                    {
                        Response.Redirect(ReturnUrl);
                    }
                }
                else
                {
                    FailureText.Text = "Неправильный e-mail или пароль";
                }
            }
        }
}
}
