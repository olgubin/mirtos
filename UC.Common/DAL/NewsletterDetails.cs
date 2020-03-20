using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace UC.DAL
{
    public class NewsletterDetails
    {
        public NewsletterDetails() { }

        public NewsletterDetails(int id, DateTime addedDate, string addedBy, string subject, string newsabstract, string htmlBody, bool isSending)
        {
            this.ID = id;
            this.AddedDate = addedDate;
            this.AddedBy = addedBy;
            this.Subject = subject;
            this.Abstract = newsabstract;
            this.HtmlBody = htmlBody;
            this.IsSending = isSending;
        }

        private int _id = 0;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private DateTime _addedDate = DateTime.Now;
        public DateTime AddedDate
        {
            get { return _addedDate; }
            set { _addedDate = value; }
        }

        private string _addedBy = "";
        public string AddedBy
        {
            get { return _addedBy; }
            set { _addedBy = value; }
        }

        private string _subject = "";
        public string Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        private string _abstract = "";
        public string Abstract
        {
            get { return _abstract; }
            set { _abstract = value; }
        }

        private string _htmlBody = "";
        public string HtmlBody
        {
            get { return _htmlBody; }
            set { _htmlBody = value; }
        }

        private bool _isSending = false;
        public bool IsSending
        {
            get { return _isSending; }
            set { _isSending = value; }
        }
    }
}