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
                //изменени заголовка и тега keywords в соответствии с разделом
                BasePage.HeaderWrite(this.Page, "Новости от С-СLIMATE.RU",
                    "новости от С-СLIMATE.RU, новости Климатическое оборудование ",
                    "Новинки и специальные предложения от нашего магазина. Информация об изменении цен и ассортимента. Свежие новости цифровых диктофонов.");

                //Прячет элемент управления новостями
                //BaseWebPart NewsletterBox = base.Master.FindControl("NewsletterBox") as BaseWebPart;
                //if (NewsletterBox != null)
                //{
                //    NewsletterBox.Visible = false;
                //}
            }
        }
    }
}