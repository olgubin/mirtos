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
using UC.SEOHelper;

namespace UC.UI.Controls
{
    public partial class BreadCrumb : BaseWebPart
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            _hlnkMain.NavigateUrl = SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/"));
        }

        /// <summary>
        /// Добавление активной ссылки
        /// </summary>
        /// <param name="title">заголовок ссылки</param>
        /// <param name="hyperLink">ссылка</param>
        public void AddActiveLink(string title, string link)
        {
            AddSeparator();

            HyperLink nhyperLink = new HyperLink();
            nhyperLink.NavigateUrl = link;
            nhyperLink.Text = title;
            pnlBreadCrumb.Controls.Add(nhyperLink);

        }

        /// <summary>
        /// Добавление неактивной ссылки
        /// </summary>
        /// <param name="title">заголовок ссылки</param>
        public void AddInActiveLink(string title)
        {
            AddSeparator();

            Label lbl = new Label();
            lbl.Text = title;
            pnlBreadCrumb.Controls.Add(lbl);
        }

        /// <summary>
        /// Добавление разделителя
        /// </summary>
        public void AddSeparator()
        {
            Image nimage = new Image();
            nimage.SkinID = "Separator";
            nimage.Style.Add("display", "inline");
            pnlBreadCrumb.Controls.Add(nimage);
        }
    }
}