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
using UC.UI;

namespace UC.UI.Controls
{
    public partial class AdwertBox : BaseWebPart
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Request.RawUrl.ToLower().Contains("default.aspx"))
                pnlAdwert.Visible = true;
        }
    }
}