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
using UC.SEOHelper;
using UC.UI;
using UC.BLL.Newsletters;

namespace UC.UI.Controls
{
    public partial class NewsletterBox : BaseWebPart
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            repNewsItems.DataSource = Newsletter.GetNewslettersLast(Globals.Settings.Newsletters.LastNewsSize);
            repNewsItems.DataBind();

            hlnkAll.NavigateUrl = SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/Newsletters.aspx"));
        }
    }
}