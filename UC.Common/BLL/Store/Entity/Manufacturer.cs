using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using UC.Core;
using UC.BLL.Articles;

namespace UC.BLL.Store
{
    public class Manufacturer : BaseEntity
    {
        public Manufacturer()
        {
        }

        public int ManufacturerID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string MetaTitle { get; set; }

        public string MetaDescription { get; set; }

        public string MetaKeywords { get; set; }

        public string ImageUrl { get; set; }

        public string Url { get; set; }

        public int ArticleID { get; set; }

        public int DisplayOrder { get; set; }

        public bool Published { get; set; }

        public DateTime AddedDate { get; set; }

        public string AddedBy { get; set; }

        public string LongDescription
        {
            get { return ManufacturerManager.GetManufacturerLongDescription(ManufacturerID); }
        }

        public Article Article
        {
            get
            {
                return Article.GetArticleByID(ArticleID);
            }
        }
    }
}