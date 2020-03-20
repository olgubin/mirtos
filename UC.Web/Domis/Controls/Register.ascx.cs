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
using UC.Core;

namespace UC.UI.Controls
{
    public partial class Register : System.Web.UI.UserControl
    {
        string _returnUrl = "";
        public string ReturnUrl
        {
            get { return _returnUrl; }
            set { _returnUrl = value; }
        }

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
            if (!this.IsPostBack)
            {
                (this.Page as BasePage).SaveLastPage();
            }
        }

        public bool onRegister()
        {
            //�������� �� �������. �� ������ ���� � ������� �������� JScript
            valRequireLastName.Validate();
            valRequireFirstName.Validate();
            valRequireEmail.Validate();
            valEmailPattern.Validate();
            valRequirePassword.Validate();
            valPasswordLength.Validate();
            valRequireConfirmPassword.Validate();
            valComparePasswords.Validate();
            if (valRequireLastName.IsValid &
                valRequireFirstName.IsValid &
                valRequireEmail.IsValid &
                valEmailPattern.IsValid &
                valRequirePassword.IsValid &
                valPasswordLength.IsValid &
                valRequireConfirmPassword.IsValid &
                valComparePasswords.IsValid)
            {
                string userName = txtLastName.Text + " " + txtFirstName.Text + " " + txtMiddleName.Text;
                userName = userName.Trim();

                MembershipCreateStatus status;
                MembershipUser user = Membership.CreateUser(userName, txtPassword.Text, txtEmail.Text, null, null, true, null, out status);

                try
                {
                    user.Comment = userName;
                    Membership.UpdateUser(user);
                }
                catch
                {
                    status = MembershipCreateStatus.ProviderError;
                }

                if (status != MembershipCreateStatus.Success)
                {
                    switch (status)
                    {
                        case MembershipCreateStatus.DuplicateEmail:
                            ErrorMessage.Text = "��������� ���� ����� ����������� ����� ��� ���������������.";
                            break;
                        case MembershipCreateStatus.DuplicateUserName:
                            ErrorMessage.Text = "������������ � ����� ������ ��� ���������������.";
                            break;
                        case MembershipCreateStatus.InvalidEmail:
                            ErrorMessage.Text = "������ ������������ ����� ����������� �����.";
                            break;
                        case MembershipCreateStatus.InvalidPassword:
                            ErrorMessage.Text = "������ ������ ��������� ������� 5 ��������.";
                            break;
                        default:
                            ErrorMessage.Text = "������ ��� �����������. �������� ������������ � ����� ������� ��� ���������������.";
                            break;
                    }
                    return false;
                }
                else
                {
                    if (Membership.ValidateUser(userName, txtPassword.Text))
                    {
                        Roles.AddUserToRole(userName, "Posters");

                        //���������� ���������� � ������� � �������� ������ � �����������
                        FormsAuthentication.SetAuthCookie(user.UserName, false);

                        ProfileCommon profile = this.Profile;
                        profile = this.Profile.GetProfile(userName);
                        profile.FirstName = txtFirstName.Text;
                        profile.LastName = txtLastName.Text;
                        profile.MiddleName = txtMiddleName.Text;
                        profile.Preferences.Newsletter = chkNews.Checked;
                        profile.Save();

                        //�������� ��������� �� ����� ������������
                        if (!Helpers.SendEmail(SettingManager.GetSettingValue("Common.MailTo"), SettingManager.GetSettingValue("Common.StoreName"), user.Email, Subject, Request.MapPath(BodyFileName), user))
                        {
                            ErrorMessage.Text = "������ ��� �������� �����. �������� ������������ � ����� ������� ��� ���������������.";
                        }

                        //��������������� �������� ����� �����������
                        if (String.IsNullOrEmpty(ReturnUrl))
                        {
                            //string redirectUrl = FormsAuthentication.GetRedirectUrl(userName, true);
                            string redirectUrl = (this.Page as BasePage).LastPage;

                            if (String.IsNullOrEmpty(redirectUrl))
                            {
                                //Response.Redirect(FormsAuthentication.DefaultUrl);
                                Response.Redirect(Request.Url.PathAndQuery);  //���������� ����� ��������
                                //FormsAuthentication.RedirectFromLoginPage(userName, true);
                            }
                            else
                            {
                                Response.Redirect(redirectUrl);
                            }
                        }
                        else
                        {
                            Response.Redirect(ReturnUrl);
                        }

                        return true;
                    }
                    else
                    {
                        ErrorMessage.Text = "������ ��� �����������. �������� ������������ � ����� ������� ��� ���������������.";
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }
    }
}
