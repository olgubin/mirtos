using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using FredCK.FCKeditorV2;
using System.Threading;
using System.Net.Mail;
using UC;
using UC.BLL.Newsletters;

namespace UC.UI.Admin
{
    public partial class ManageNewsletters : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool isSending = false;
            Newsletter.Lock.AcquireReaderLock(Timeout.Infinite);
            isSending = Newsletter.Sending;
            Newsletter.Lock.ReleaseReaderLock();

            if (!this.IsPostBack && isSending)
            {
                panWait.Visible = true;
                panSend.Visible = false;
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            List<Newsletter> newsletters = Newsletter.GetNewslettersNoSending();

            if (newsletters.Count > 0)
            {
                bool isSending = false;
                Newsletter.Lock.AcquireReaderLock(Timeout.Infinite);
                isSending = Newsletter.Sending;
                Newsletter.Lock.ReleaseReaderLock();
                // if another newsletter is currently being sent, show the panel with the wait message,
                // but don't hide the input controls so that the user doesn't loose the newsletter's text
                if (isSending)
                {
                    panWait.Visible = true;
                }
                else
                {
                    // if no newsletter is currently being sent, send this new one and
                    // redirect to the page showing the progress

                    //Newsletter newsletter = Newsletter.GetNewsletterByID(
                    //   int.Parse(this.Request.QueryString["ID"]));

                    //Newsletter.SendNewsletter(newsletter.Subject, newsletter.Abstract, newsletter.HtmlBody);

                    Newsletter.SendNoSendingNewsletters("Новости от DOMIS.RU", Request.PhysicalApplicationPath + "newsletter.txt", Request.PhysicalApplicationPath + "newsletters.txt",
                        Request.PhysicalApplicationPath + "Images\\Logo.gif", Request.PhysicalApplicationPath + "Images\\Banners\\bnr_avidius_600x90.gif");

                    this.Response.Redirect("~/Admin/SendingNewsletter.aspx");
                }
            }
            else
            {
                FailureText.Text = "Все новости уже были разосланы";
            }
        }
    }
}