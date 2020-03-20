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
    public partial class AboutProducts : BasePage
   {
      protected void Page_Load(object sender, EventArgs e)
      {
          BreadCrumb.AddInActiveLink("О продукции");
          BasePage.HeaderWrite(this.Page, "DOMIS.RU О продукции", "О продукции Edelform", "О продукции Edelform");
      }
   }
}