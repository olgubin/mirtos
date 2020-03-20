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
using UC.SEOHelper;

namespace UC.UI
{
    public partial class _Default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.Master.EnablePersonalization = true;
        }

        protected void ucFilter_FilteredMebel(Object sender)
        {
            Response.Redirect(SeoHelper.GetDepartmentUrl(316));
        }

        protected void ucFilter_FilteredDush(Object sender)
        {
            Response.Redirect(SeoHelper.GetDepartmentUrl(317));
        }
    }
}