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
    public partial class ProductAttributesControl : System.Web.UI.UserControl
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
                    //Заполнение списка характеристик товаров
                    this.ddlNewProductAttribute.Items.Clear();
                    ProductAttributeCollection productAttributes = ProductAttributeManager.GetProductAttributes();
                    foreach (ProductAttribute item in productAttributes)
                    {
                        ListItem listItem = new ListItem(item.Name, item.ProductAttributeID.ToString());
                        this.ddlNewProductAttribute.Items.Add(listItem);
                    }

                    //Заполнение таблицы характеристик товара
                    BindProductAttributesMapping();
                }
            }
        }

        /// <summary>
        /// Привязка списка характеристик к таблице характеристик товара
        /// </summary>
        private void BindProductAttributesMapping()
        {
            ProductAttributeMappingCollection productAttributesMapping = ProductAttributeMappingManager.GetProductAttributeMappingByProductID(this.ProductID);

            if (productAttributesMapping.Count > 0)
            {
                gvProductAttributesMapping.Visible = true;
                gvProductAttributesMapping.DataSource = productAttributesMapping;
                gvProductAttributesMapping.DataBind();
            }
            else
                gvProductAttributesMapping.Visible = false;
        }

        /// <summary>
        /// Добавление характеристики к продукты
        /// </summary>
        protected void btnNewProductAttribute_Click(object sender, EventArgs e)
        {
            try
            {
                Product product = ProductManager.GetByProductID(this.ProductID);
                if (product != null)
                {
                    int ProductAttributeID = int.Parse(ddlNewProductAttribute.SelectedItem.Value);

                    ProductAttributeMapping productAttributeMapping = ProductAttributeMappingManager.InsertProductAttributeMapping(product.ProductID,
                        ProductAttributeID, txtNewProductAttributeMappingValue.Text, txtNewProductAttributeMappingDisplayOrder.Value, cbDisplayInShort.Checked);

                    BindProductAttributesMapping();
                }
            }
            catch (Exception exc)
            {
                //ProcessException(exc);
            }
        }

        /// <summary>
        /// Заполнение данными таблицы характеристик товаров
        /// </summary>
        protected void gvProductAttributesMapping_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ProductAttributeMapping productAttributeMapping = (ProductAttributeMapping)e.Row.DataItem;

                Button btnUpdate = e.Row.FindControl("btnUpdate") as Button;
                if (btnUpdate != null)
                    btnUpdate.CommandArgument = e.Row.RowIndex.ToString();

                DropDownList ddlProductAttribute = e.Row.FindControl("ddlProductAttribute") as DropDownList;
                ddlProductAttribute.Items.Clear();
                ProductAttributeCollection productAttributes = ProductAttributeManager.GetProductAttributes();
                foreach (ProductAttribute productAttribute in productAttributes)
                {
                    ListItem item = new ListItem(productAttribute.Name, productAttribute.ProductAttributeID.ToString());
                    ddlProductAttribute.Items.Add(item);
                    if (productAttributeMapping.ProductAttributeID == productAttribute.ProductAttributeID)
                        item.Selected = true;
                }
            }
        }

        /// <summary>
        /// Удаление характеристики товара
        /// </summary>
        protected void gvProductAttributesMapping_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int productAttributeMappingID = (int)gvProductAttributesMapping.DataKeys[e.RowIndex]["ProductAttributeMappingID"];
            ProductAttributeMapping productAttributeMapping = ProductAttributeMappingManager.GetByProductAttributeMappingID(productAttributeMappingID);
            if (productAttributeMapping != null)
            {
                ProductAttributeMappingManager.DeleteProductAttributeMapping(productAttributeMapping.ProductAttributeMappingID);

                BindProductAttributesMapping();
            }
        }

        /// <summary>
        /// Обновление характеристик товаров
        /// </summary>
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    foreach (GridViewRow row in gvProductAttributesMapping.Rows)
                    {
                        HiddenField hfProductAttributesMappingID = row.FindControl("hfProductAttributesMappingID") as HiddenField;
                        DropDownList ddlProductAttribute = row.FindControl("ddlProductAttribute") as DropDownList;
                        SimpleTextBox txtProductAttributeMappingValue = row.FindControl("txtProductAttributeMappingValue") as SimpleTextBox;
                        NumericTextBox txtProductAttributesMappingDisplayOrder = row.FindControl("txtProductAttributesMappingDisplayOrder") as NumericTextBox;
                        CheckBox cbDisplayInShort = row.FindControl("cbDisplayInShort") as CheckBox;

                        int productAttributeMappingID = int.Parse(hfProductAttributesMappingID.Value);
                        int productAttributeID = int.Parse(ddlProductAttribute.SelectedItem.Value);
                        int displayOrder = txtProductAttributesMappingDisplayOrder.Value;
                        bool displayInShort = cbDisplayInShort.Checked;

                        ProductAttributeMapping productAttributeMapping = ProductAttributeMappingManager.GetByProductAttributeMappingID(productAttributeMappingID);

                        if (productAttributeMapping != null)
                            ProductAttributeMappingManager.UpdateProductAttributeMapping(productAttributeMapping.ProductAttributeMappingID,
                               productAttributeMapping.ProductID, productAttributeID,
                               txtProductAttributeMappingValue.Text, displayOrder, displayInShort);
                    }

                    lblAttribute.Text = "Сохранение проведено успешно";

                    BindProductAttributesMapping();
                }
                catch
                {
                    lblAttribute.Text = "Ошибка пр сохранении";
                }
            }
        }
    }
}
