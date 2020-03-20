using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using UC.BLL.Store;
using UC.Core;

namespace UC.UI
{
   public partial class SiteMapPage : BasePage
   {
      protected void Page_Load(object sender, EventArgs e)
      {
          BreadCrumb.AddInActiveLink("����� �����");
          BasePage.HeaderWrite(this.Page, "DOMIS.RU ����� �����", "", "");
      }
   }
}