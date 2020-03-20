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
                //Заполнение вкладки связанных товаров
                ProductFeaturedCollection existingProductFeaturedCollection = ProductFeaturedManager.GetProductFeatured();
                List<ProductFeaturedHelperClass> featuredProducts = GetFeaturedProducts(existingProductFeaturedCollection);
                gvFeaturedProducts.DataSource = featuredProducts;
                gvFeaturedProducts.DataBind();
            }

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
            List<Product> productCollection = ProductManager.GetAllProducts(true);

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
                    rp.DisplayOrder = existingProductFeatured.DisplayOrder;
                    rp.Description = existingProductFeatured.Description;
                }
                else
                {
                    rp.DisplayOrder = 1;
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
                        NumericTextBox txtRowDisplayOrder = row.FindControl("txtDisplayOrder") as NumericTextBox;
                        TextBox txProductFeaturedDescription = row.FindControl("txProductFeaturedDescription") as TextBox;
                        int productFeaturedID = int.Parse(hfProductFeaturedID.Value);
                        int productID = int.Parse(hfProductID.Value);
                        int displayOrder = txtRowDisplayOrder.Value;
                        string description = txProductFeaturedDescription.Text;

                        if (productFeaturedID > 0 && !cbProductInfo.Checked)
                            ProductFeaturedManager.DeleteProductFeatured(productFeaturedID);
                        if (productFeaturedID > 0 && cbProductInfo.Checked)
                            ProductFeaturedManager.UpdateProductFeatured(productFeaturedID, productID, description, displayOrder);
                        if (productFeaturedID == 0 && cbProductInfo.Checked)
                            ProductFeaturedManager.InsertProductFeatured(productID, description, displayOrder);
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