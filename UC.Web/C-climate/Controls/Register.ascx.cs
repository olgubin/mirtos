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
            //Проверка на сервере. на случай если у клиента отключен JScript
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
                            ErrorMessage.Text = "Введенный Вами адрес электронной почты уже зарегистрирован.";
                            break;
                        case MembershipCreateStatus.DuplicateUserName:
                            ErrorMessage.Text = "Пользователь с таким именем уже зарегистрирован.";
                            break;
                        case MembershipCreateStatus.InvalidEmail:
                            ErrorMessage.Text = "Введен неправильный адрес электронной почты.";
                            break;
                        case MembershipCreateStatus.InvalidPassword:
                            ErrorMessage.Text = "Пароль должен содержать минимум 5 символов.";
                            break;
                        default:
                            ErrorMessage.Text = "Ошибка при регистрации. Возможно пользователь с таким адресом уже зарегистрирован.";
                            break;
                    }
                    return false;
                }
                else
                {
                    if (Membership.ValidateUser(userName, txtPassword.Text))
                    {
                        Roles.AddUserToRole(userName, "Posters");

                        //сохранение информации в профиль и отправка письма о регистрации
                        FormsAuthentication.SetAuthCookie(user.UserName, false);

                        ProfileCommon profile = this.Profile;
                        profile = this.Profile.GetProfile(userName);
                        profile.FirstName = txtFirstName.Text;
                        profile.LastName = txtLastName.Text;
                        profile.MiddleName = txtMiddleName.Text;
                        profile.Preferences.Newsletter = chkNews.Checked;
                        profile.Save();

                        //Отправка сообщения на почту пользователю
                        if (!Helpers.SendEmail(SettingManager.GetSettingValue("Common.MailTo"), SettingManager.GetSettingValue("Common.StoreName"), user.Email, Subject, Request.MapPath(BodyFileName), user))
                        {
                            ErrorMessage.Text = "Ошибка при отправке почты. Возможно пользователь с таким адресом уже зарегистрирован.";
                        }

                        //перенаправление страницы после регистрации
                        if (String.IsNullOrEmpty(ReturnUrl))
                        {
                            //string redirectUrl = FormsAuthentication.GetRedirectUrl(userName, true);
                            string redirectUrl = (this.Page as BasePage).LastPage;

                            if (String.IsNullOrEmpty(redirectUrl))
                            {
                                //Response.Redirect(FormsAuthentication.DefaultUrl);
                                Response.Redirect(Request.Url.PathAndQuery);  //обновление самой страницы
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
                        ErrorMessage.Text = "Ошибка при регистрации. Возможно пользователь с таким адресом уже зарегистрирован.";
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
