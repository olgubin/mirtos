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
using System.Drawing;
using UC;
using UC.BLL.Store;
using UC.UI;

namespace UC.UI.Controls
{
    public partial class ProductFeaturedBox : BaseWebPart
    {
        private class ProductFeaturedHelperClass
        {
            public int ProductID { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string FinalPrice { get; set; }
            public string Price { get; set; }
            public bool DiscountVisible { get; set; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ProductFeaturedCollection products = ProductFeaturedManager.GetProductFeaturedTop(Globals.Settings.ProductFeatured.TopProduct,Globals.Settings.ProductFeatured.Rotate);

            List<ProductFeaturedHelperClass> productCollection = new List<ProductFeaturedHelperClass>();

            foreach (ProductFeatured item in products)
            {
                ProductFeaturedHelperClass product = new ProductFeaturedHelperClass();

                product.ProductID = item.Product.ProductID;
                product.Title = item.Product.Title;
                product.Description = item.Description;
                product.FinalPrice = (this.Page as BasePage).FormatPrice(CurrencyManager.ConvertCurrency(item.Product.FinalPrice, item.Product.Currency, CurrencyManager.WorkingCurrency), CurrencyManager.WorkingCurrency.CurrencyCode);
                product.Price = (this.Page as BasePage).FormatPrice(CurrencyManager.ConvertCurrency(item.Product.Price, item.Product.Currency, CurrencyManager.WorkingCurrency), CurrencyManager.WorkingCurrency.CurrencyCode);
                product.DiscountVisible = item.Product.DiscountPercentage > 0;

                productCollection.Add(product);
            }

            repProductFeatured.DataSource = productCollection;
            repProductFeatured.DataBind();
        }
    }
}