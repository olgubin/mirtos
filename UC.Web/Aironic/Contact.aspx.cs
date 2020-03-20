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
using System.Net.Mail;
using UC;

namespace UC.UI
{
   public partial class Contact : BasePage
   {
      protected void Page_Load(object sender, EventArgs e)
      {
          BasePage.HeaderWrite(this.Page, this.Page.Title + ". Контакты", "", "");
      }
   }
}
