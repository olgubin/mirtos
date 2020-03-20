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
    public partial class PasswordRecovery : System.Web.UI.UserControl
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

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            valRequireUserName.Validate();
            valEmailPattern.Validate();
            if (valRequireUserName.IsValid &
                valEmailPattern.IsValid)
            {
                string userName = Membership.GetUserNameByEmail(txtEmail.Text);

                if (userName != null)
                {
                    MembershipUser user = Membership.GetUser(userName);
                    if (user != null)
                    {
                        //Отправка сообщения на почту пользователю
                        if (!Helpers.SendEmail(From, FromCaption, user.Email, Subject, Request.MapPath(BodyFileName), user))
                        {
                            FailureText.Text = "Ошибка при отправке сообщения по почте.";
                        }
                        else
                        {
                            lblSuccess.Visible = true;
                        }
                    }
                    else
                    {
                        FailureText.Text = "Указанный адрес электронной почты не зарегистрирован.";
                    }
                }
                else
                {
                    FailureText.Text = "Указанный адрес электронной почты не зарегистрирован.";
                }
            }
        }
    }
}