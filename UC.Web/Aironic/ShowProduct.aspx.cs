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
using System.Security;
using UC;
using UC.BLL.Store;
using UC.BLL.Images;
using UC.SEOHelper;

namespace UC.UI
{
    public partial class ShowProduct : BasePage
    {
        private bool _userCanEdit = false;
        protected bool UserCanEdit
        {
            get { return _userCanEdit; }
            set { _userCanEdit = value; }
        }

        int _productID = 0;
        public int ProductID
        {
            get
            {
                if (_productID <= 0)
                {
                    if (string.IsNullOrEmpty(this.Request.QueryString["ID"]))
                        throw new ApplicationException("Не передан идентификатор товара в строке запроса.");
                    else
                        _productID = int.Parse(this.Request.QueryString["ID"]);

                }
                return _productID;
            }
            set { _productID = value; }
        }

        int _departmentID = 0;

        protected void Page_Init(object sender, EventArgs e)
        {
            UserCanEdit = (this.User.Identity.IsAuthenticated &&
               (this.User.IsInRole("Administrators") || this.User.IsInRole("StoreKeepers")));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!this.IsPostBack)
            //{
                // try to load the product with the specified ID, and raise an exception if it doesn't exist
                Product product = ProductManager.GetByProductID(ProductID);
                if (product == null)
                {
                    Context.Response.StatusCode = 404;

                    this.Title = "404 Not Found";

                    pnlContent.Visible = false;

                    ctrl404.Visible = true;

                    //Response.Redirect("Error.aspx?code=404");
                    //throw new ApplicationException("Товар не найден.");
                }
                else
                {
                    Assign(product.AddedDate);  //Добавление в респонз Last Modified

                    tblProductAttributes.ProductID = ProductID;

                    ProductDepartmentMappingCollection dept = ProductDepartmentMappingManager.GetProductDepartmentMappingByProductID(ProductID);

                    if (dept.Count > 0)
                    {
                        _departmentID = dept[0].DepartmentID;
                        //_departmentID = product.DepartmentID;
                    }

                    DepartmentCollection departments = DepartmentManager.GetBreadCrumb(_departmentID);

                    for (int i = 0; i < departments.Count; i++)
                    {
                        if (i == 0)
                        {
                            //BreadCrumb.AddActiveLink(departments[i].Name, "~/Departments.aspx?DepID=" + departments[i].DepartmentID.ToString());
                            BreadCrumb.AddActiveLink(departments[i].Name, UC.SEOHelper.SeoHelper.GetDepartmentUrl(departments[i].DepartmentID));
                        }
                        else
                        {
                            //BreadCrumb.AddActiveLink(departments[i].Name, "~/Departments.aspx?DepID=" + departments[i].DepartmentID.ToString());
                            BreadCrumb.AddActiveLink(departments[i].Name, UC.SEOHelper.SeoHelper.GetDepartmentUrl(departments[i].DepartmentID));
                        }
                    }

                    //изменение заголовка и тега keywords в соответствии с разделом
                    //if (String.IsNullOrEmpty(product.Department.MetaKeywords))
                    //{
                    BasePage.HeaderWrite(this.Page, product.Title, "", "Цена: " + this.FormatPrice(product.UnitPrice) + ". " + product.ShortDescription);
                    //}
                    //else
                    //{
                    //    BasePage.HeaderWrite(this.Page, product.Title, product.Title + ", " + product.Department.MetaKeywords, "Цена: " + this.FormatPrice(product.UnitPrice) + ". " + product.ShortDescription);
                    //}

                    lblTitle.Text = product.Title;


                    //lblRating.Text = string.Format(lblRating.Text, product.Votes);
                    //ratDisplay.Value = product.AverageRating;
                    //ratDisplay.Visible = (product.Votes > 0);


                    mbRating.Value = product.AverageRating;
                    //mbRating.Visible = (product.Votes > 0);

                    //lblDiscount.Text = product.DiscountPercentage.ToString() + "%";
                    //lblDiscount.Text = this.FormatPrice((decimal)product.DiscountPercentage / 100 * product.UnitPrice);
                    pnDiscount.Visible = (product.DiscountPercentage > 0);



                    //availDisplay.Value = product.UnitsInStock;


                    lblSKU.Text = "Артикул: " + product.SKU;
                    if (product.ManufacturerID != 0)
                    {
                        panManufacturer.Visible = true;
                        lnkManTitle.Text = product.Manufacturer.Title;
                        lnkManTitle.NavigateUrl = SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/Departments.aspx?ManID=" + product.ManufacturerID.ToString()));
                    }
                    else
                        panManufacturer.Visible = false;
                    lblDescription.Text = product.LongDescription;
                    panEditProduct.Visible = this.UserCanEdit;
                    lnkEditProduct.NavigateUrl = string.Format(lnkEditProduct.NavigateUrl, ProductID);

                    decimal finalPrice = CurrencyManager.ConvertCurrency(product.FinalPrice, product.Currency, CurrencyManager.WorkingCurrency);
                    decimal price = CurrencyManager.ConvertCurrency(product.Price, product.Currency, CurrencyManager.WorkingCurrency);

                    lblPrice.Text = this.FormatPrice(finalPrice, CurrencyManager.WorkingCurrency.CurrencyCode);
                    lblDiscountedPrice.Text = string.Format(lblDiscountedPrice.Text, this.FormatPrice(price, CurrencyManager.WorkingCurrency.CurrencyCode));

                    pnlDiscountedPrice.Visible = (product.DiscountPercentage > 0);

                    if (product.UnitPrice > 0 & product.UnitsInStock > 0)
                    {
                        pnlToCart.Visible = true;
                        pnlToOrder.Visible = false;
                    }
                    else
                    {
                        pnlToCart.Visible = false;
                        pnlToOrder.Visible = true;
                    }

                    if (product.FullImageUrl.Length > 0)
                    {
                        imgProduct.ImageUrl = SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/fullimage.aspx?ID=" + product.ProductID.ToString()));
                        //imgProduct.ImageUrl = product.FullImageUrl;
                    }

                    // hide the rating box controls if the current user has already voted for this product
                    int userRating = GetUserRating();
                    if (userRating > 0)
                        ShowUserRating(userRating);                    
                }
            //}
        }

        protected void btnRate_Click(object sender, EventArgs e)
        {
            // check whether the user has already rated this article
            int userRating = GetUserRating();
            if (userRating > 0)
            {
                ShowUserRating(userRating);
            }
            else
            {
                // rate the product, then create a cookie to remember this user's rating
                userRating = ddlRatings.SelectedIndex + 1;
                ProductManager.RateProduct(ProductID, userRating);
                ShowUserRating(userRating);

                HttpCookie cookie = new HttpCookie(
                   "Rating_Product" + ProductID.ToString(), userRating.ToString());
                cookie.Expires = DateTime.Now.AddDays(Globals.Settings.Store.RatingLockInterval);
                this.Response.Cookies.Add(cookie);
            }
        }

        protected void ShowUserRating(int rating)
        {
            lblUserRating.Text = string.Format(lblUserRating.Text, rating);
            ddlRatings.Visible = false;
            btnRate.Visible = false;
            lblUserRating.Visible = true;
            litVoiteQuetion.Visible = false;
        }

        protected int GetUserRating()
        {
            int rating = 0;
            HttpCookie cookie = this.Request.Cookies["Rating_Product" + ProductID.ToString()];
            if (cookie != null)
                rating = int.Parse(cookie.Value);
            return rating;
        }

        protected void btnAddToCart_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                int quantity = Convert.ToInt32(txtQuantity.Text);

                if (quantity > 0)
                {
                    Product product = ProductManager.GetByProductID(ProductID);

                    this.Profile.ShoppingCart.InsertItem(product.ProductID, product.Title, product.SKU, product.FinalPrice, product.CurrencyID, quantity);

                    txtQuantity.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    txtQuantity.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch
            {
                txtQuantity.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnDelete_Click(object sender, ImageClickEventArgs e)
        {
            //удаление рисунков на товар
            Product product = ProductManager.GetByProductID(ProductID);
            if (product != null)
            {
                if (ProductManager.GetProductCountByImageUrl(product.SmallImageUrl) == 0)
                {
                    Images.DeleteImageByUrl(product.SmallImageUrl);
                }
                if (ProductManager.GetProductCountByImageUrl(product.FullImageUrl) == 0)
                {
                    Images.DeleteImageByUrl(product.FullImageUrl);
                }
            }

            //string returnUrl = "~/Departments.aspx?DepID=" + product.DepartmentID.ToString();
            string returnUrl = "~/Default.aspx";

            //удаление товара
            ProductManager.DeleteProduct(ProductID);

            //перенаправление на раздел каталога
            this.Response.Redirect(returnUrl);
        }

        protected void btnProductCopy_Click(object sender, ImageClickEventArgs e)
        {
            if (ProductID > 0)
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
