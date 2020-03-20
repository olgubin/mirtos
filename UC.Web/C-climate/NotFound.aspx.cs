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
    public partial class NotFound : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblTitle.Text = "Страница не найдена";

            Context.Response.StatusCode = 404;

            this.Title = "404 Not Found";
        }
    }
}
