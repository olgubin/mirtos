using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using UC;
using UC.BLL.Store;
using UC.UI.Admin.Controls;

namespace UC.UI.Admin
{
    public partial class ManageProductFeatured : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                ddlDepartments.BindData();

                ProductBindGrid();
            }
        }

        protected void gvwProductFeatured_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            gvwProductFeatured.DataBind();
        }

        protected void gvwProductFeatured_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton btn = e.Row.Cells[3].Controls[0] as ImageButton;
                btn.OnClientClick = "if (confirm('Подтвердите удаление') == false) return false;";
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
                    foreach (GridViewRow row in gvwProductFeatured.Rows)
                    {
                        HiddenField hfProductFeaturedID = row.FindControl("hfProductFeaturedID") as HiddenField;
                        TextBox txtDescription = row.FindControl("txtDescription") as TextBox;
                        NumericTextBox txtDisplayOrder = row.FindControl("txtDisplayOrder") as NumericTextBox;

                        int productFeaturedID = int.Parse(hfProductFeaturedID.Value);
                        string productFeaturedDescription = txtDescription.Text;
                        int displayOrder = txtDisplayOrder.Value;

                        ProductFeatured productFeatured = ProductFeaturedManager.GetByProductFeaturedID(productFeaturedID);

                        if (productFeatured != null)
                            ProductFeaturedManager.UpdateProductFeatured(productFeatured.ProductFeaturedID,
                               productFeatured.ProductID, productFeaturedDescription, displayOrder);
                    }

                    lblAttribute.Text = "Сохранение проведено успешно";

                    gvwProductFeatured.DataBind();
                }
                catch
                {
                    lblAttribute.Text = "Ошибка пр сохранении";
                }
            }
        }

        protected void gvFeaturedProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvFeaturedProducts.PageIndex = e.NewPageIndex;
            ProductBindGrid();
        }

        protected void ddlDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductBindGrid();
        }

        protected void ProductBindGrid()
        {
            //Заполнение вкладки связанных товаров
            ProductFeaturedCollection existingProductFeaturedCollection = ProductFeaturedManager.GetProductFeatured();
            List<ProductFeaturedHelperClass> featuredProducts = GetFeaturedProducts(existingProductFeaturedCollection);
            gvFeaturedProducts.DataSource = featuredProducts;
            gvFeaturedProducts.DataBind();
        }

        private class ProductFeaturedHelperClass
        {
            public int ProductFeaturedID { get; set; }
            public int ProductID { get; set; }
            public string Description { get; set; }
            public string ProductInfo { get; set; }
            public bool IsMapped { get; set; }
            public int DisplayOrder { get; set; }
        }

        private List<ProductFeaturedHelperClass> GetFeaturedProducts(ProductFeaturedCollection ExistingProductFeaturedCollection)
        {
            ProductCollection productCollection = new ProductCollection();

            if (ddlDepartments.SelectedDepartmentId > 0)
            {
                ProductDepartmentMappingCollection productDepartmentMapping = ProductDepartmentMappingManager.GetProductDepartmentMappingByDepartmentID(ddlDepartments.SelectedDepartmentId, false);

                foreach (ProductDepartmentMapping item in productDepartmentMapping)
                {
                    productCollection.Add(item.Product);
                }
            }
            else
            {
                productCollection = ProductManager.GetAllProducts(false);
            }

            List<ProductFeaturedHelperClass> result = new List<ProductFeaturedHelperClass>();

            for (int i = 0; i < productCollection.Count; i++)
            {
                Product product = productCollection[i];

                ProductFeatured existingProductFeatured = ExistingProductFeaturedCollection.FindProductFeatured(product.ProductID);

                ProductFeaturedHelperClass rp = new ProductFeaturedHelperClass();
                if (existingProductFeatured != null)
                {
                    rp.ProductFeaturedID = existingProductFeatured.ProductFeaturedID;
                    rp.IsMapped = true;
                }

                rp.ProductID = product.ProductID;
                rp.ProductInfo = product.Title;

                result.Add(rp);
            }

            return result;
        }

        protected void btnProductFeatured_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    foreach (GridViewRow row in gvFeaturedProducts.Rows)
                    {
                        CheckBox cbProductInfo = row.FindControl("cbProductInfo") as CheckBox;
                        HiddenField hfProductID = row.FindControl("hfProductID") as HiddenField;
                        HiddenField hfProductFeaturedID = row.FindControl("hfProductFeaturedID") as HiddenField;

                        int productFeaturedID = int.Parse(hfProductFeaturedID.Value);
                        int productID = int.Parse(hfProductID.Value);

                        if (productFeaturedID > 0 && !cbProductInfo.Checked)
                            ProductFeaturedManager.DeleteProductFeatured(productFeaturedID);
                        if (productFeaturedID > 0 && cbProductInfo.Checked)
                            ProductFeaturedManager.UpdateProductFeatured(productFeaturedID, productID, "", 1);
                        if (productFeaturedID == 0 && cbProductInfo.Checked)
                            ProductFeaturedManager.InsertProductFeatured(productID, "", 1);

                        gvwProductFeatured.DataBind();
                    }

                    lblFeedBack.Text = "Сохранение проведено успешно";
                }
                catch
                {
                    lblFeedBack.Text = "Ошибка при сохранении";
                }
            }
        }
    }
}