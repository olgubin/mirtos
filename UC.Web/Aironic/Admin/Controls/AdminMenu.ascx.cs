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
using UC.BLL.Polls;

namespace UC.UI.Controls
{
   public partial class AdminMenu : BaseWebPart
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         //if (!this.IsPostBack)
         //   DoBinding();
      }

      protected void lnkBtn_Click(object sender, EventArgs e)
      {
          FormsAuthentication.SignOut();
          Response.Redirect(Request.RawUrl);
      }
}
}