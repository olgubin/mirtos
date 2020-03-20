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
   public partial class SearchResult : BasePage
   {
      protected void Page_Load(object sender, EventArgs e)
      {
          if (!this.IsPostBack)
          {
              (this.Page as BasePage).LastPage = this.Request.Url.PathAndQuery;
          }
      }
   }
}