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
   public partial class Service : BasePage
   {
      protected void Page_Load(object sender, EventArgs e)
      {
          BreadCrumb.AddInActiveLink("Сервис");
          BasePage.HeaderWrite(this.Page, "DOMIS.RU Сервисное обслуживание", "Сервисное обслуживание", "Сервисное обслуживание");
      }
   }
}