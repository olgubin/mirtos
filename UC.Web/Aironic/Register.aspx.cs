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
using UC;

namespace UC.UI
{
    public partial class Register : BasePage
    {
        protected string Email = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack && !string.IsNullOrEmpty(this.Request.QueryString["Email"]))
            {
                Email = this.Request.QueryString["Email"];
                //CreateUserWizard1.DataBind();
            }

            //Trace.IsEnabled = true;
        }

        //protected void CreateUserWizard1_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        //{
        //    //��������� ���������� ������� �� ������ ��������
        //    UserProfile1.SaveProfile();
        //}

        //protected void CreateUserWizard1_CreatingUser(object sender, LoginCancelEventArgs e)
        //{
        //    //� ���� ����� �������� ���, ��������� � �������� ����� �� ���������� �����
        //    CreateUserWizard1.Email = CreateUserWizard1.UserName;
        //}

        //protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
        //{
        //    // add the current user to the Posters role
        //    Roles.AddUserToRole(CreateUserWizard1.UserName, "Posters");

        //    ////��������� �������, ��� � �������� � �������
        //    //WizardStepBase step = null;
        //    //for (int i = 0; i < CreateUserWizard1.WizardSteps.Count; i++)
        //    //{
        //    //    if (CreateUserWizard1.WizardSteps[i].ID == "CreateUser")
        //    //    {
        //    //        step = CreateUserWizard1.WizardSteps[i];
        //    //        break;
        //    //    }
        //    //}

        //    //if (step != null)
        //    //{
        //    //    if (step.FindControl("FirstName") != null)
        //    //    {
        //    //        this.Profile.FirstName = ((TextBox)step.FindControl("FirstName")).Text;
        //    //    }
        //    //    this.Profile.LastName = ((TextBox)step.FindControl("LastName")).Text;
        //    //    this.Profile.PatronymicName = ((TextBox)step.FindControl("PatronymicName")).Text;
        //    //    this.Profile.Save();
        //    //}
        //}

        ////protected void CreateUserWizard1_SendingMail(object sender, MailMessageEventArgs e)
        ////{
        ////    e.Message.IsBodyHtml = false;
        ////    e.Message.Body = String.Format("������� �� ����������� � �������� �-�LIMATE.RU!\n"+
        ////        "������ ��� ������� � �������:\n"+
        ////        "��� ������������: {0}\n"+
        ////        "������: {1}\n\n"+
        ////        "� ���������,\n"+
        ////        "�-�LIMATE.RU.",
        ////        CreateUserWizard1.UserName.ToString(), CreateUserWizard1.Password.ToString());
        ////    e.Message.Priority = System.Net.Mail.MailPriority.High;
        ////}

        //protected void CreateUserWizard1_ContinueButtonClick(object sender, EventArgs e)
        //{

        //}
        protected void btnEnter_Click(object sender, EventArgs e)
        {
            Reg.onRegister();
        }
}
}
