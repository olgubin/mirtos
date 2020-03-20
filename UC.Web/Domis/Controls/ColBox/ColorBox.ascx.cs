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
using UC.BLL.Store;
using UC.SEOHelper;
using UC.UI;

namespace UC.UI.Controls
{
    public partial class ColorBox : BaseWebPart
    {
        private const string SESSION = "UCFILTER{0}{1}{2}";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void onCommand(object sender, CommandEventArgs e)
        {
            FilterCriteriaCollection filterCriteriaCollection = new FilterCriteriaCollection();

            FilterCriteria filterCriteria = FilterCriteriaManager.GetByFilterCriteriaID(int.Parse(e.CommandArgument.ToString()));

            filterCriteriaCollection.Add(filterCriteria);

            string sessionKey = String.Format(SESSION, 316, 0, 18);

            Session[sessionKey] = filterCriteriaCollection;

            Response.Redirect(SeoHelper.GetDepartmentUrl(316));
        }
    }
}