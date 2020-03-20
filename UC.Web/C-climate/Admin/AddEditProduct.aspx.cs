using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using UC.BLL.Store;
using UC;

namespace UC.UI.Admin
{
    public partial class AddEditProduct : BasePage
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
                if (!string.IsNullOrEmpty(this.Request.QueryString["ID"]))
                {
                    if (this.User.Identity.IsAuthenticated &&
                       (this.User.IsInRole("Administrators") || this.User.IsInRole("Editors")))
                    {
                        lblTitle.Text = "Редактирование товара";
                        lblProduct.Text = "Редактирование товара: " + ProductManager.GetByProductID(ProductID).Title;
                    }
                    else
                        throw new SecurityException("У вас нет доступа к редактированию товаров!");
                }
                else
                {
                    lblTitle.Text = "Добавление товара";
                    lblProduct.Text = "Добавление нового товара";
                }

                if (ProductID <= 0)
                {
                    pnlCopyProduct.Visible = false;
                    pnlProductSpecification.Visible = true;
                    pnlRelatedProducts.Visible = false;
                    pnlDepartmentMappings.Visible = false;
                }
            }
        }

        /// <summary>
        /// Добавление копии товара
        /// </summary>
        protected void lbtnProductCopy_Click(object sender, EventArgs e)
        {
            if (ProductID <= 0)
            {
                lblProductCopy.Text = "* нельзя создать копию товара, поскольку не определен идентификатор товара";
            }
            else
            {
                //Копирование товара
                Product product = ProductManager.GetByProductID(ProductID);

                Product productCopy = ProductManager.InsertProduct
                    (
                    //product.Title,
                    product.ProductTypeID,
                    product.Model,
                    product.ShortDescription,
                    product.LongDescription,
                    product.ManufacturerID,
                    "",
                    product.CurrencyID,
                    product.UnitPrice,
                    product.DiscountPercentage,
                    product.MarginPercentage,
                    product.UnitsInStock,
                    product.SmallImageUrl,
                    product.FullImageUrl,
                    product.Visible
                    );

                //Копируем характеристики товара
                ProductAttributeMappingCollection productAttributeMappingCollection = ProductAttributeMappingManager.GetProductAttributeMappingByProductID(ProductID);
                foreach (ProductAttributeMapping item in productAttributeMappingCollection)
                {
                    ProductAttributeMappingManager.InsertProductAttributeMapping
                        (
                        productCopy.ProductID,
                        item.ProductAttributeID,
                        item.AttributeValue,
                        item.DisplayOrder,
                        item.DisplayInShort
                        );
                }

                //Копируем связанные товары
                ProductRelatedCollection productRelatedCollection = ProductRelatedManager.GetProductRelatedByProductID1(ProductID);
                foreach (ProductRelated item in productRelatedCollection)
                {
                    ProductRelatedManager.InsertProductRelated
                    (
                    productCopy.ProductID,
                    item.ProductID2,
                    item.DisplayOrder
                    );
                }

                //Копируем разделы
                ProductDepartmentMappingCollection productDepartmentMappingCollection = ProductDepartmentMappingManager.GetProductDepartmentMappingByProductID(ProductID);
                foreach (ProductDepartmentMapping item in productDepartmentMappingCollection)
                {
                    ProductDepartmentMappingManager.InsertProductDepartmentMapping
                    (
                    productCopy.ProductID,
                    item.DepartmentID,
                    item.DisplayOrder
                    );
                }

                //Копируем критерии фильтрации
                FilterCriteriaProductCollection filterCriteriaProductCollection = FilterCriteriaProductManager.GetFilterCriteriaProductByProductID(ProductID);
                foreach (FilterCriteriaProduct item in filterCriteriaProductCollection)
                {
                    FilterCriteriaProductManager.InsertFilterCriteriaProduct
                    (
                    productCopy.ProductID,
                    item.FilterCriteriaID
                    );
                }

                this.Response.Redirect("~/Admin/AddEditProduct.aspx?ID=" + productCopy.ProductID.ToString());
            }
        }
    }
}