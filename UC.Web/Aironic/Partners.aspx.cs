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
using UC.BLL.Store;

namespace UC.UI
{
   public partial class Partner : BasePage
   {
      protected void Page_Load(object sender, EventArgs e)
      {
          BasePage.HeaderWrite(this.Page, this.Page.Title+". ѕартнеры", "", "");
      }

      //protected void Button1_Click(object sender, EventArgs e)
      //{
      //    ProductCollection products = new ProductCollection();

      //    products = ProductManager.GetAllProducts(false);

      //    string text = "<p style=\"clear: left\"><b><i>*ѕримечание:</i></b> <i>ѕроизводитель об€зуетс€ посто€нно улучшать и совершенствовать свою продукцию, обеспечивать соответствие наивысшим стандартам качества и надежности, выполн€ть требовани€ местных нормативных документов и требовани€ рынка. “ехнические характеристики, параметры и отдельные детали дизайна, могут быть изменены без предварительного уведомлени€.</i></p><div style=\"text-align: center\"><img alt=\"\" style=\"clear: none; float: none\" src=\"Images/Store/s542_080.gif\" /></div>";

      //    foreach (Product item in products)
      //    {
      //        if (item.ManufacturerID != 4)
      //        {

      //            string descr = item.LongDescription;

      //            if (!String.IsNullOrEmpty(descr.Trim()))
      //            {
      //                string temp1 = descr.Trim().Substring(descr.Length - 19, 13);

      //                if (temp1 == "<p>&nbsp;</p>")
      //                {
      //                    descr.Remove(descr.Length - 19, 13);
      //                }

      //                string temp = descr.Trim().Substring(descr.Length - 6, 6);

      //                if (temp == "</div>")
      //                {
      //                    descr = descr.Trim().Insert(descr.Length - 6, text);
      //                }
      //                else
      //                {
      //                    descr = "<div class=\"description\">" + descr.Trim() + text + "</div>";
      //                }

      //                ProductManager.UpdateProductLongDescription(item.ProductID, descr);
      //            }
      //        }
      //    }
      //}
}
}