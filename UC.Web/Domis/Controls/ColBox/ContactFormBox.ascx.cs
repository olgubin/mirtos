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
using UC.UI;
using UC.BLL.Polls;
using System.Net.Mail;
using UC;

namespace UC.UI.Controls
{
    public partial class ContactFormBox : BaseWebPart
    {
        private string _defaultName = "";
        public string DefaultName
        {
            get { return _defaultName; }
            set { _defaultName = value; }
        }

        private string _defaultEmail = "";
        public string DefaultEmail
        {
            get { return _defaultEmail; }
            set { _defaultEmail = value; }
        }

        private string _defaultSubject = "";
        public string DefaultSubject
        {
            get { return _defaultSubject; }
            set { _defaultSubject = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!this.IsPostBack)
            //   DoBinding();
        }

        protected void boxSubmit_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(boxBody.Text))
            {
                rowFeedBack.Visible = true;
                lblValidate.Visible = true;
            }
            else
            {
                try
                {
                    // send the mail
                    MailMessage msg = new MailMessage();
                    msg.IsBodyHtml = false;


                    msg.From = new MailAddress(DefaultEmail, DefaultName);

                    // разбор адресов куда отправлять почту указанных в web.config
                    string[] mailTo = Globals.Settings.ContactForm.MailTo.Split(',');
                    foreach (string item in mailTo)
                    {
                        msg.To.Add(new MailAddress(item));
                    }


                    if (!string.IsNullOrEmpty(Globals.Settings.ContactForm.MailCC))
                        msg.CC.Add(new MailAddress(Globals.Settings.ContactForm.MailCC));
                    msg.Subject = string.Format(Globals.Settings.ContactForm.MailSubject, DefaultSubject);
                    msg.Body = boxBody.Text;
                    new SmtpClient().Send(msg);
                    // show a confirmation message, and reset the fields
                    rowFeedBack.Visible = true;
                    lblFeedbackOK.Visible = true;
                    lblFeedbackKO.Visible = false;
                    boxBody.Text = "";
                }
                catch (Exception)
                {
                    rowFeedBack.Visible = true;
                    lblFeedbackOK.Visible = false;
                    lblFeedbackKO.Visible = true;
                }
            }
        }
    }
}