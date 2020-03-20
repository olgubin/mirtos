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
using UC.Core;

namespace UC.UI
{
   public partial class Vacancy : BasePage
   {
      protected void Page_Load(object sender, EventArgs e)
      {
          BasePage.HeaderWrite(this.Page, this.Page.Title+". ��������", "", "");

          hlnkMailTo.NavigateUrl = "mailto:" + SettingManager.GetSettingValue("Common.MailTo");
          hlnkMailTo.Text = SettingManager.GetSettingValue("Common.MailTo");
      }
   }
}