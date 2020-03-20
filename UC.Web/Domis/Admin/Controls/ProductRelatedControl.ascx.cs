using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using UC.BLL.Store;

namespace UC.UI.Admin.Controls
{
    public partial class ProductRelatedControl : System.Web.UI.UserControl
    {
        public int ProductID
        {
            get
            {
                if (!String.IsNullOrEmpty(this.Request.QueryString["ID"]))
                {
                    string resultStr = this.Request.QueryString["ID"].ToUpperInvariant();
                    int result;
                    Int32.TryParse(resultStr, out result);
                    return result;
                }
                else
                {
                    return 0;
                }
            }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (ProductID > 0)
                {
                    //Заполнение списка разделов
                    ddlProducts.BindData();

                    //Заполнение таблицы разделов
                    BindProductRelatedMapping();
                }
            }
        }

        /// <summary>
        /// Привязка списка характеристик к таблице характеристик товара
        /// </summary>
        private void BindProductRelatedMapping()
        {
            ProductRelatedCollection productsRelated = ProductRelatedManager.GetProductRelatedByProductID1(this.ProductID);

            if (productsRelated.Count > 0)
            {
                gvProductRelated.Visible = true;
                gvProductRelated.DataSource = productsRelated;
                gvProductRelated.DataBind();
            }
            else
                gvProductRelated.Visible = false;
        }

        /// <summary>
        /// Добавление раздела к товару
        /// </summary>
        protected void btnNewProductRelated_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlProducts.SelectedProductId > 0)
                {
                    Product product = ProductManager.GetByProductID(this.ProductID);

                    ProductRelatedCollection productsRelated = product.ProductRelated;

                    if (productsRelated.FindRelatedProduct(this.ProductID, ddlProducts.SelectedProductId) == null)
                    {
                        if (product != null)
                        {
                            int productID = ddlProducts.SelectedProductId;

                            ProductRelatedManager.InsertProductRelated(this.ProductID,
                                productID, txtNewProductRelatedDisplayOrder.Value);

                            lblNewProductRelated.Text = "Сохранение успешно проведено";

                            BindProductRelatedMapping();
                        }
                    }
                    else
                    {
                        lblNewProductRelated.Text = "Товар уже существует";
                    }
                }
                else
                {
                    lblNewProductRelated.Text = "Не выбран товар";
                }
            }
            catch (Exception exc)
            {
                lblNewProductRelated.Text = "Ошибка при сохранении";
            }
        }

        /// <summary>
        /// Удаление товара
        /// </summary>
        protected void gvProductRelated_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int productRelatedID = (int)gvProductRelated.DataKeys[e.RowIndex]["ProductRelatedID"];

            ProductRelatedManager.DeleteProductRelated(productRelatedID);

            BindProductRelatedMapping();
        }

        /// <summary>
        /// Обновление товаров
        /// </summary>
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    foreach (GridViewRow row in gvProductRelated.Rows)
                    {
                        HiddenField hfProductRelatedID = row.FindControl("hfProductRelatedID") as HiddenField;
                        NumericTextBox txtProductRelatedDisplayOrder = row.FindControl("txtProductRelatedDisplayOrder") as NumericTextBox;

                        int productRelatedID = int.Parse(hfProductRelatedID.Value);
                        int displayOrder = txtProductRelatedDisplayOrder.Value;

                        ProductRelated productRelated = ProductRelatedManager.GetByProductRelatedID(productRelatedID);

                        if (productRelated != null)
                            ProductRelatedManager.UpdateProductRelated(productRelated.ProductRelatedID,
                               productRelated.ProductID1, productRelated.ProductID2, displayOrder);
                    }

                    lblAttribute.Text = "Сохранение проведено успешно";

                    BindProductRelatedMapping();
                }
                catch
                {
                    lblAttribute.Text = "Ошибка при сохранении";
                }
            }
        }

        protected void gvProductRelated_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ProductRelated productRelated = e.Row.DataItem as ProductRelated;

                Image img = e.Row.FindControl("imgVisible") as Image;

                if (img != null)
                {
                    if (productRelated.Product2.Visible)
                    {
                        img.AlternateText = "Видимый товар";
                        img.ImageUrl = "~/Images/vis.gif";
                    }
                    else
                    {
                        img.AlternateText = "Невидимый товар";
                        img.ImageUrl = "~/Images/unvis.gif";
                    }
                }
            }
        }
    }
}
