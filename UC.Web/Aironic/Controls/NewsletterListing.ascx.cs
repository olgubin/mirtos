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
using UC.BLL.Newsletters;

namespace UC.UI.Controls
{
    public partial class NewsletterListing : BaseWebPart
    {
        int _maximumRow = 0;
        public int MaximumRow
        {
            get
            {
                //получение размера страницы из сессии
                //if (Session["product_maximumrow"] != null)
                //    _maximumRow = (int)Session["product_maximumrow"];

                if (_maximumRow == 0)
                {
                    _maximumRow = Globals.Settings.Newsletters.PageSize;
                }
                return _maximumRow;
            }
            set
            {
                _maximumRow = value;

                //сохранение размера страницы в сессии
                //Session["product_maximumrow"] = _maximumRow; 
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            // set the ObjectDataSource's "toDate" select param. if the current user is
            // an admin or editor, set it to the current date. Otherwise set it to the current date
            // minus the number of days stored in the web.config
            DateTime toDate = DateTime.Now;
            if (!this.Page.User.Identity.IsAuthenticated ||
               (!this.Page.User.IsInRole("Administrators") && !this.Page.User.IsInRole("Editors")))
            {
                toDate = toDate.Subtract(new TimeSpan(Globals.Settings.Newsletters.HideFromArchiveInterval, 0, 0, 0));
            }
            //objNewsletters.SelectParameters["toDate"].DefaultValue = toDate.ToString("f");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // if the user is not an admin or editor, hide the grid's column with the delete button
            bool userCanEdit = (this.Page.User.Identity.IsAuthenticated && (this.Page.User.IsInRole("Administrators") || this.Page.User.IsInRole("Editors")));
            gvwNewsletters.Columns[2].Visible = userCanEdit;
            gvwNewsletters.Columns[3].Visible = userCanEdit;
            gvwNewsletters.Columns[4].Visible = userCanEdit;

            if (!this.IsPostBack)
            {
                PagingTop.SessionKey = "news_page";
                PagingTop.ProductCount = Newsletter.GetNewsletterCount();
                PagingTop.MaximumRow = MaximumRow;

                PagingBottom.SessionKey = "news_page";
                PagingBottom.ProductCount = Newsletter.GetNewsletterCount();
                PagingBottom.MaximumRow = MaximumRow;

                Session["last_news_page"] = Page.Request.Url.AbsoluteUri;
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            List<Newsletter> newsletters = Newsletter.GetNewsletters(PagingTop.StartRowIndex, MaximumRow);
            gvwNewsletters.DataSource = newsletters;
            gvwNewsletters.DataBind();
        }

        protected void gvwNewsletters_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton btn = e.Row.Cells[4].Controls[0] as ImageButton;
                btn.OnClientClick = "if (confirm('Подтвердите удаление новости') == false) return false;";
            }
        }

        protected void gvwNewsletters_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int newsID= Convert.ToInt32(gvwNewsletters.DataKeys[e.RowIndex].Value);
            Newsletter.DeleteNewsletter(newsID);
            PagingTop.ProductCount = Newsletter.GetNewsletterCount();
            PagingBottom.ProductCount = Newsletter.GetNewsletterCount();
            PagingTop.PagingRender();
            PagingBottom.PagingRender();
        }
}
}