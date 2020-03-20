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
    public partial class Newsletters : BasePage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            // check whether this page can be accessed by anonymous users. If not, and if the
            // current user is not authenticated, redirect to the login page
            if (!this.User.Identity.IsAuthenticated && !Globals.Settings.Newsletters.ArchiveIsPublic)
                this.RequestLogin();

            if (!this.IsPostBack)
            {
                //�������� ��������� � ���� keywords � ������������ � ��������
                BasePage.HeaderWrite(this.Page, "������� �� �-�LIMATE.RU",
                    "������� �� �-�LIMATE.RU, ������� ������������� ������������ ",
                    "������� � ����������� ����������� �� ������ ��������. ���������� �� ��������� ��� � ������������. ������ ������� �������� ����������.");

                //������ ������� ���������� ���������
                //BaseWebPart NewsletterBox = base.Master.FindControl("NewsletterBox") as BaseWebPart;
                //if (NewsletterBox != null)
                //{
                //    NewsletterBox.Visible = false;
                //}
            }
        }
    }
}