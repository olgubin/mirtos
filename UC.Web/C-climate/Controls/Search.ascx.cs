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

namespace UC.UI.Controls
{
    public partial class Search : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!String.IsNullOrEmpty(Page.Request.QueryString["sw"]))
                {
                    search_text.Value = Page.Request.QueryString["sw"];
                }
            }
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            if (search_text.Value == "Поиск по кталогу" | String.IsNullOrEmpty(search_text.Value))
            {
                search_text.Focus();
            }
            else
            {
                Session["product_search_sortexpression"] = null;
                Response.Redirect("~/SearchResult.aspx?sw=" + search_text.Value);
            }
        }
    }
}
