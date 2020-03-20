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

namespace UC.UI
{
   public partial class Adwert : BasePage
   {
      protected void Page_Load(object sender, EventArgs e)
      {
          if (this.Request.QueryString["ID"] != null)
          {
              if (this.Request.QueryString["ID"] == "1")
              {
                  this.Response.Redirect("http://www.domis.ru");
              }
          }
          else
          {
              this.Response.Redirect("http://www.mirtos.ru");
          }
      }
   }
}