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
using System.Web.Profile;
using UC;

namespace UC.UI.Admin
{
    public partial class SearchRequests : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                int pageSize = Globals.Settings.Search.PageSize;
                if (ddlRequestsPerPage.Items.FindByValue(pageSize.ToString()) == null)
                    ddlRequestsPerPage.Items.Add(new ListItem(pageSize.ToString(), pageSize.ToString()));
                ddlRequestsPerPage.SelectedValue = pageSize.ToString();
                gvwRequests.PageSize = pageSize;

                gvwRequests.DataBind();
            }
        }

        protected void ddlRequestsPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvwRequests.PageSize = int.Parse(ddlRequestsPerPage.SelectedValue);
            gvwRequests.PageIndex = 0;
            gvwRequests.DataBind();
        }
    }
}