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
    public class ManufacturerDetails
    {
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

        private string _title = "";
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private string _description = "";
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private string _keywords = "";
        public string Keywords
        {
            get { return _keywords; }
            set { _keywords = value; }
        }

        private string _imageUrl = "";
        public string ImageUrl
        {
            get { return _imageUrl; }
            set { _imageUrl = value; }
        }

        private string _url = "";
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        private int _articleID = 0;
        public int ArticleID
        {
            get { return _articleID; }
            set { _articleID = value; }
        }

        private string _articleTitle = "";
        public string ArticleTitle
        {
            get { return _articleTitle; }
            set { _articleTitle = value; }
        }

        private int _importance = 0;
        public int Importance
        {
            get { return _importance; }
            set { _importance = value; }
        }

        private bool _visible = true;
        public bool Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }

        public ManufacturerDetails() { }

        public ManufacturerDetails(int id, DateTime addedDate, string addedBy, string title, string description, string keywords,
            string imageUrl, string url, int articleID, string articleTitle, int importance, bool visible)
        {
            this.ID = id;
            this.AddedDate = addedDate;
            this.AddedBy = addedBy;
            this.Title = title;
            this.Description = description;
            this.Keywords = keywords;
            this.ImageUrl = imageUrl;
            this.Url = url;
            this.ArticleID = articleID;
            this.ArticleTitle = articleTitle;
            this.Importance = importance;
            this.Visible = visible;
        }
    }
}