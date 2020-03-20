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

namespace UC.UI
{
   public partial class Partner : BasePage
   {
      protected void Page_Load(object sender, EventArgs e)
      {
          BasePage.HeaderWrite(this.Page, this.Page.Title+". Партнеры", "", "");
      }

      //protected void Button1_Click(object sender, EventArgs e)
      //{
      //    ProductCollection products = new ProductCollection();

      //    products = ProductManager.GetAllProducts(false);

      //    string text = "<p style=\"clear: left\"><b><i>*Примечание:</i></b> <i>Производитель обязуется постоянно улучшать и совершенствовать свою продукцию, обеспечивать соответствие наивысшим стандартам качества и надежности, выполнять требования местных нормативных документов и требования рынка. Технические характеристики, параметры и отдельные детали дизайна, могут быть изменены без предварительного уведомления.</i></p><div style=\"text-align: center\"><img alt=\"\" style=\"clear: none; float: none\" src=\"Images/Store/s542_080.gif\" /></div>";

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

      //protected void Button1_Click(object sender, EventArgs e)
      //{
      //    //int count = 0;

      //    ProductCollection products = ProductManager.GetAllProducts(false);

      //    foreach (Product product in products)
      //    {
      //        //if (!product.LongDescription.Contains("<noindex><b><i>*Примечание:</i></b> <i>Производитель обязуется постоянно улучшать и совершенствовать свою продукцию, обеспечивать соответствие наивысшим стандартам качества и надежности, выполнять требования местных нормативных документов и требования рынка. Технические характеристики, параметры и отдельные детали дизайна, могут быть изменены без предварительного уведомления.</i></noindex>"))
      //        //{
      //        //    //if (product.LongDescription.Contains("Производитель обязуется постоянно улучшать и совершенствовать"))
      //        //    //{
      //        //    //    count++;
      //        //    //}

      //        //    ProductManager.UpdateProductLongDescription(product.ProductID,
      //        //                                                product.LongDescription.Replace(
      //        //                                                    "<b><i>*Примечание:</i></b> <i>Производитель обязуется постоянно улучшать и совершенствовать свою продукцию, обеспечивать соответствие наивысшим стандартам качества и надежности, выполнять требования местных нормативных документов и требования рынка. Технические характеристики, параметры и отдельные детали дизайна, могут быть изменены без предварительного уведомления.</i>",
      //        //                                                    "<noindex><b><i>*Примечание:</i></b> <i>Производитель обязуется постоянно улучшать и совершенствовать свою продукцию, обеспечивать соответствие наивысшим стандартам качества и надежности, выполнять требования местных нормативных документов и требования рынка. Технические характеристики, параметры и отдельные детали дизайна, могут быть изменены без предварительного уведомления.</i></noindex>"));
      //        //}

      //        StringBuilder txt = new StringBuilder();

      //        //txt.Append("<p style=\"clear: left\"><noindex></noindex><noindex><b><i>*Примечание:</i></b> <i>Производитель обязуется постоянно улучшать и совершенствовать свою продукцию, обеспечивать соответствие наивысшим стандартам качества и надежности, выполнять требования местных нормативных документов и требования рынка. Технические характеристики, параметры и отдельные детали дизайна, могут быть изменены без предварительного уведомления.</i></noindex></p>");
      //        //txt.Append(
      //        //    "<div style=\"text-align: center\"><img alt=\"\" style=\"clear: none; float: none\" src=\"Images/Store/s542_080.gif\" /></div>");
      //        //txt.Append(
      //        //    "<p style=\"clear: left\"><noindex><b><i>*Примечание:</i></b> <i>Производитель обязуется постоянно улучшать и совершенствовать свою продукцию, обеспечивать соответствие наивысшим стандартам качества и надежности, выполнять требования местных нормативных документов и требования рынка. Технические характеристики, параметры и отдельные детали дизайна, могут быть изменены без предварительного уведомления.</i></noindex></p><div style=\"text-align: center\"><img alt=\"\" style=\"clear: none; float: none\" src=\"Images/Store/s542_080.gif\" /></div>");

      //        txt.Append(
      //            "<p style=\"clear: left\"><noindex></noindex><noindex><b><i>*Примечание:</i></b> <i>Производитель обязуется постоянно улучшать и совершенствовать свою продукцию, обеспечивать соответствие наивысшим стандартам качества и надежности, выполнять требования местных нормативных документов и требования рынка. Технические характеристики, параметры и отдельные детали дизайна, могут быть изменены без предварительного уведомления.</i></noindex></p>  <div style=\"text-align: center\"><img alt=\"\" style=\"clear: none; float: none\" src=\"Images/Store/s542_080.gif\" /></div>  </div>  <p>&nbsp;</p><p style=\"clear: left\"><noindex><b><i>*Примечание:</i></b> <i>Производитель обязуется постоянно улучшать и совершенствовать свою продукцию, обеспечивать соответствие наивысшим стандартам качества и надежности, выполнять требования местных нормативных документов и требования рынка. Технические характеристики, параметры и отдельные детали дизайна, могут быть изменены без предварительного уведомления.</i></noindex></p><div style=\"text-align: center\"><img alt=\"\" style=\"clear: none; float: none\" src=\"Images/Store/s542_080.gif\" /></div></div>");


      //        if (product.LongDescription.Contains(txt.ToString()))
      //        {
      //            //ProductManager.UpdateProductLongDescription(product.ProductID,
      //            //                                            product.LongDescription.Replace(
      //            //                                                txt.ToString(),
      //            //                                                "<p style=\"clear: left\"><noindex><b><i>*Примечание:</i></b> <i>Производитель обязуется постоянно улучшать и совершенствовать свою продукцию, обеспечивать соответствие наивысшим стандартам качества и надежности, выполнять требования местных нормативных документов и требования рынка. Технические характеристики, параметры и отдельные детали дизайна, могут быть изменены без предварительного уведомления.</i></noindex></p><div style=\"text-align: center\"><img alt=\"\" style=\"clear: none; float: none\" src=\"Images/Store/s542_080.gif\" /></div>"));

      //            ProductManager.UpdateProductLongDescription(product.ProductID,
      //                                                        product.LongDescription.Replace(
      //                                                            txt.ToString(),
      //                                                            "<p style=\"clear: left\"><noindex><b><i>*Примечание:</i></b> <i>Производитель обязуется постоянно улучшать и совершенствовать свою продукцию, обеспечивать соответствие наивысшим стандартам качества и надежности, выполнять требования местных нормативных документов и требования рынка. Технические характеристики, параметры и отдельные детали дизайна, могут быть изменены без предварительного уведомления.</i></noindex></p><div style=\"text-align: center\"><img alt=\"\" style=\"clear: none; float: none\" src=\"Images/Store/s542_080.gif\" /></div></div>"));
      //        }
      //    }










          //foreach (Product product in products)
          //{
          //    if (product.LongDescription.Contains("Производитель обязуется постоянно улучшать и совершенствовать"))
          //    {
          //        if (!product.LongDescription.Contains("<noindex>"))
          //        {
          //            //count++;

          //            lblID.Text += product.ProductID.ToString() + "<br/>";
          //        }
          //    }
          //}

          //lblID.Text += count.ToString();
      //}
}
}