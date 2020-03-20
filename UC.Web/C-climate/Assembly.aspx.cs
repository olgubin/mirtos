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
   public partial class Assembly : BasePage
   {
      protected void Page_Load(object sender, EventArgs e)
      {
          BasePage.HeaderWrite(this.Page, "Стоимость монтажа кондиционеров. Монтаж кондиционеров прайс. Оптовые продажи кондиционеров и монтаж кондиционеров - MIRTOS", "стоимость монтажа кондиционеров, монтаж кондиционеров прайс, оптовые продажи кондиционеров", "стоимость монтажа кондиционера, монтаж кондиционеров прайс, кондиционеры оптовые продажи, продажа монтаж кондиционеров от компании MIRTOS");
      }
   }
}