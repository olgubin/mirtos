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
    public partial class ChangePassword : System.Web.UI.UserControl
    {
        string _bodyFileName = "";
        public string BodyFileName
        {
            get { return _bodyFileName; }
            set { _bodyFileName = value; }
        }

        string _from = "";
        public string From
        {
            get { return _from; }
            set { _from = value; }
        }

        string _fromCaption = "";
        public string FromCaption
        {
            get { return _fromCaption; }
            set { _fromCaption = value; }
        }

        string _subject = "";
        public string Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ChangePasswordPushButton_Click(object sender, ImageClickEventArgs e)
        {
            valRequireNewPassword.Validate();
            valPasswordLength.Validate();
            valRequireConfirmNewPassword.Validate();
            valComparePasswords.Validate();
            if (valRequireNewPassword.IsValid &
                valPasswordLength.IsValid &
                valRequireConfirmNewPassword.IsValid &
                valComparePasswords.IsValid)
            {
                if (Page.User.Identity.IsAuthenticated)
                {
                    MembershipUser user = Membership.GetUser();

                    try
                    {
                        if (user.ChangePassword(user.GetPassword(), NewPassword.Text))
                        {
                            lblChangePswOK.Visible = true;

                            ////e.Message.Body = e.Message.Body.Replace("<% E-mail %>", Email);
                            //MembershipUser user = Membership.GetUser();
                            //e.Message.From = new MailAddress("info@С-СLIMATE.RU", "Климатическое оборудование С-СLIMATE.RU", System.Text.Encoding.UTF8);
                            //e.Message.Body = Regex.Replace(e.Message.Body, @"<%\s*e-mail\s*%>", user.Email, RegexOptions.IgnoreCase | RegexOptions.Compiled);

                            //Отправка сообщения на почту пользователю
                            if (!Helpers.SendEmail(From, FromCaption, user.Email, Subject, Request.MapPath(BodyFileName), user))
                            {
                                FailureText.Text = "Ошибка при отправке сообщения по почте.";
                            }
                        }
                        else
                        {
                            FailureText.Text = "Ошибка при изменении пароля. Попробуйте снова.";
                        }
                    }
                    catch (Exception error)
                    {
                        FailureText.Text = Server.HtmlEncode(error.Message);
                    }
                }
            }
        }
}
}