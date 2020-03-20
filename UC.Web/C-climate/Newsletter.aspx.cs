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
using UC.BLL.Newsletters;

namespace UC.UI
{
    public partial class ShowNewsletter : BasePage
    {
        private bool _userCanEdit = false;
        protected bool UserCanEdit
        {
            get { return _userCanEdit; }
            set { _userCanEdit = value; }
        }

        int _newsID = 0;
        public int NewsID
        {
            get
            {
                if (_newsID == 0)
                {
                    // выбор ID товара из строки запроса
                    if (string.IsNullOrEmpty(this.Request.QueryString["ID"]))
                        throw new ApplicationException("Не могу прочитать параметр товара в строке запроса.");
                    else
                        _newsID = int.Parse(this.Request.QueryString["ID"]);

                }
                return _newsID;
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            UserCanEdit = (this.User.Identity.IsAuthenticated &&
               (this.User.IsInRole("Administrators") || this.User.IsInRole("Editors")));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // check whether this page can be accessed by anonymous users. If not, and if the
            // current user is not authenticated, redirect to the login page
            if (!this.User.Identity.IsAuthenticated && !Globals.Settings.Newsletters.ArchiveIsPublic)
                this.RequestLogin();

            // load the newsletter with the ID passed on the querystring
            Newsletter newsletter = Newsletter.GetNewsletterByID(NewsID);

            if (newsletter == null)
            {
                Context.Response.StatusCode = 404;

                this.Title = "404 Not Found";

                pnlContent.Visible = false;

                ctrl404.Visible = true;

                //throw new ApplicationException("Новость не найдена.");
            }
            else
            {
                Assign(newsletter.AddedDate);

                if (!this.IsPostBack)
                {
                    //изменени заголовка и тега keywords в соответствии с разделом
                    BasePage.HeaderWrite(this.Page, newsletter.Subject,
                        newsletter.Subject + ", новости, новости о диктофонах, новости о цифровых диктофонах, диктофоны, Климатическое оборудование, Климатическое оборудование Гном, диктофоны Гном",
                        newsletter.Abstract);
                }
                // check that the newsletter can be viewed, according to the number of days
                // that must pass before it is published in the archive
                //int days = ((TimeSpan)(DateTime.Now - newsletter.AddedDate)).Days;
                //if (Globals.Settings.Newsletters.HideFromArchiveInterval > days &&
                //   (!this.User.Identity.IsAuthenticated ||
                //   (!this.User.IsInRole("Administrators") && !this.User.IsInRole("Editors"))))
                //    this.RequestLogin();

                panEditNews.Visible = this.UserCanEdit;
                lnkEditNews.NavigateUrl = string.Format(lnkEditNews.NavigateUrl, NewsID);

                // show the newsletter's data
                lblAddedDate.Text = newsletter.AddedDate.ToShortDateString();
                lblSubject.Text = newsletter.Subject;
                //lblAbstract.Text = newsletter.Abstract;
                lblHtmlBody.Text = newsletter.HtmlBody;                
            }
        }

        protected void btnDelete_Click(object sender, ImageClickEventArgs e)
        {
            //удаление новости
            Newsletter.DeleteNewsletter(NewsID);

            //перенаправление на раздел управлени новостями
            this.Response.Redirect("~/Admin/ManageNewsletters.aspx", false);
        }
    }
}
