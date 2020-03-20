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
using System.Net.Mail;
using UC;

namespace UC.UI.Controls
{
    public partial class ContactForm : System.Web.UI.UserControl
    {
        private string _title = "";
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private string _defaultName = "";
        public string DefaultName
        {
            get
            {
                if (!String.IsNullOrEmpty(_defaultName))
                {
                    return _defaultName;
                }
                else
                {
                    return txtName.Text;
                }
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    rowName.Visible = false;
                    _defaultName = value;
                }
                else
                    _defaultName = "";
            }
        }

        private string _defaultEmail = "";
        public string DefaultEmail
        {
            get
            {
                if (!String.IsNullOrEmpty(_defaultEmail))
                {
                    return _defaultEmail;
                }
                else
                {
                    return txtEmail.Text;
                }
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    rowEmail.Visible = false;
                    _defaultEmail = value;
                }
                else
                    _defaultEmail = "";
            }
        }

        private string _defaultSubject = "";
        public string DefaultSubject
        {
            get
            {
                if (!String.IsNullOrEmpty(_defaultSubject))
                {
                    return _defaultSubject;
                }
                else
                {
                    return txtSubject.Text;
                }
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    rowSubject.Visible = false;
                    _defaultSubject = value;
                }
                else
                    _defaultSubject = "";
            }
        }

        private bool _showFieldCaption = true;
        public bool ShowFieldCaption
        {
            get { return _showFieldCaption; }
            set
            {
                _showFieldCaption = value;

                if (!_showFieldCaption)
                {
                    cellNameCaption.Visible = false;
                    cellEmailCaption.Visible = false;
                    cellSubjectCaption.Visible = false;
                    cellBodyCaption.Visible = false;
                }
            }
        }

        private int _bodyRows = 8;
        public int BodyRows
        {
            get { return _bodyRows; }
            set { _bodyRows = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Title))
                pnlTitle.Visible = false;
            else
                lblTitle.Text = Title;

            txtBody.Rows = BodyRows;
        }

        protected void txtSubmit_Click(object sender, EventArgs e)
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
                msg.Body = txtBody.Text;
                new SmtpClient().Send(msg);
                // show a confirmation message, and reset the fields
                lblFeedbackOK.Visible = true;
                lblFeedbackKO.Visible = false;
                txtName.Text = "";
                txtEmail.Text = "";
                txtSubject.Text = "";
                txtBody.Text = "";
            }
            catch (Exception)
            {
                lblFeedbackOK.Visible = false;
                lblFeedbackKO.Visible = true;
            }
        }
    }
}
