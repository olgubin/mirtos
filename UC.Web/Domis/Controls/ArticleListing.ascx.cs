using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using UC;
using UC.UI;
using UC.BLL.Articles;

namespace UC.UI.Controls
{
    public partial class ArticleListing : BaseWebPart
    {
        private int _categoryID = 0;
        public int CategoryID
        {
            get
            {
                if (!this.IsPostBack)
                {
                    // выбор ID товара из строки запроса
                    if (!String.IsNullOrEmpty(this.Request.QueryString["CatID"]))
                    {
                        _categoryID = int.Parse(this.Request.QueryString["CatID"]);
                    }
                }
                return _categoryID;
            }
            set { _categoryID = value; }
        }

        private bool _publishedOnly = true;
        public bool PublishedOnly
        {
            get { return _publishedOnly; }
            set { _publishedOnly = value; }
        }

        private bool _showCategoryPicker = true;
        public bool ShowCategoryPicker
        {
            get { return _showCategoryPicker; }
            set
            {
                _showCategoryPicker = value;
                ddlCategories.Visible = value;
                lblCategoryPicker.Visible = value;
            }
        }

        private bool _showCategoryTitle = true;
        public bool ShowCategoryTitle
        {
            get { return _showCategoryTitle; }
            set
            {
                _showCategoryTitle = value;
            }
        }

        private bool _userCanEdit = false;
        protected bool UserCanEdit
        {
            get { return _userCanEdit; }
            set { _userCanEdit = value; }
        }

        int _maximumRow = 0;
        public int MaximumRow
        {
            get
            {
                if (_maximumRow == 0)
                {
                    _maximumRow = Globals.Settings.Articles.PageSize;
                }
                return _maximumRow;
            }
            set
            {
                _maximumRow = value;
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            this.Page.RegisterRequiresControlState(this);

            this.UserCanEdit = (this.Page.User.Identity.IsAuthenticated &&
               (this.Page.User.IsInRole("Administrators") || this.Page.User.IsInRole("Editors")));
        }

        protected override void LoadControlState(object savedState)
        {
            object[] ctlState = (object[])savedState;
            base.LoadControlState(ctlState[0]);
            this.PublishedOnly = (bool)ctlState[1];
            this.ShowCategoryPicker = (bool)ctlState[2];
        }

        protected override object SaveControlState()
        {
            object[] ctlState = new object[3];
            ctlState[0] = base.SaveControlState();
            ctlState[1] = this.PublishedOnly;
            ctlState[2] = this.ShowCategoryPicker;
            return ctlState;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                // preselect the category whose ID is passed in the querystring
                if (CategoryID != 0)
                {
                    ddlCategories.DataBind();
                    ddlCategories.SelectedValue = CategoryID.ToString();
                }

                PagingTop.SessionKey = "articles_page";
                PagingTop.ProductCount = Article.GetArticleCount(PublishedOnly, CategoryID);
                PagingTop.MaximumRow = MaximumRow;

                PagingBottom.SessionKey = "articles_page";
                PagingBottom.ProductCount = Article.GetArticleCount(PublishedOnly, CategoryID);
                PagingBottom.MaximumRow = MaximumRow;

                Session["last_articles_page"] = Page.Request.Url.AbsoluteUri;
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            List<Article> articles = Article.GetArticles(PublishedOnly, CategoryID, PagingTop.StartRowIndex, MaximumRow);

            gvwArticles.DataSource = articles;
            gvwArticles.DataBind();
        }

        protected void ddlCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            CategoryID = Int32.Parse(ddlCategories.SelectedValue);

            PagingRender();

            gvwArticles.PageIndex = 0;
            gvwArticles.DataBind();
        }

        protected void gvwArticles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Approve")
            {
                int articleID = int.Parse(e.CommandArgument.ToString());
                Article.ApproveArticle(articleID);
                gvwArticles.PageIndex = 0;
                gvwArticles.DataBind();
            }
        }

        protected void gvwArticles_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int articleID = Convert.ToInt32(gvwArticles.DataKeys[e.RowIndex].Value);
            Article.DeleteArticle(articleID);

            PagingRender();
        }

        protected void PagingRender()
        {
            PagingTop.ProductCount = Article.GetArticleCount(PublishedOnly, CategoryID);
            PagingBottom.ProductCount = Article.GetArticleCount(PublishedOnly, CategoryID);
            PagingTop.PagingRender();
            PagingBottom.PagingRender();
        }
    }
}