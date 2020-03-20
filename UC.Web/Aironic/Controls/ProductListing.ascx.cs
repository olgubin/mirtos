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
using System.Linq;
using UC;
using UC.UI;
using UC.BLL.Store;
using UC.BLL.Images;

namespace UC.UI.Controls
{
    public partial class ProductListing : BaseWebPart
    {
        //private bool _showDepartmentPicker = true;
        //public bool ShowDepartmentPicker
        //{
        //    get { return _showDepartmentPicker; }
        //    set
        //    {
        //        _showDepartmentPicker = value;
        //        ddlDepartments.Visible = value;
        //        lblDepartmentPicker.Visible = value;
        //        lblSeparator.Visible = value;
        //    }
        //}

        //private bool _showPageSizePicker = true;
        //public bool ShowPageSizePicker
        //{
        //    get { return _showPageSizePicker; }
        //    set
        //    {
        //        _showPageSizePicker = value;
        //        ddlProductsPerPage.Visible = value;
        //        lblPageSizePicker.Visible = value;
        //    }
        //}

        //private bool _enablePaging = true;
        //public bool EnablePaging
        //{
        //    get { return _enablePaging; }
        //    set
        //    {
        //        _enablePaging = value;
        //        gvwProducts.PagerSettings.Visible = value;
        //    }
        //}

        protected void Page_Init(object sender, EventArgs e)
        {
            this.Page.RegisterRequiresControlState(this);
        }

        protected override void LoadControlState(object savedState)
        {
            object[] ctlState = (object[])savedState;
            base.LoadControlState(ctlState[0]);
            //this.ShowDepartmentPicker = (bool)ctlState[1];
            //this.ShowPageSizePicker = (bool)ctlState[2];
            //this.EnablePaging = (bool)ctlState[3];
        }

        protected override object SaveControlState()
        {
            object[] ctlState = new object[4];
            ctlState[0] = base.SaveControlState();
            //ctlState[1] = this.ShowDepartmentPicker;
            //ctlState[2] = this.ShowPageSizePicker;
            //ctlState[3] = this.EnablePaging;
            return ctlState;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // hide the columns for editing and deleting a product if the current user
            // is not an administrator or a store keeper
            bool userCanEdit = (this.Page.User.Identity.IsAuthenticated &&
               (this.Page.User.IsInRole("Administrators") || this.Page.User.IsInRole("StoreKeepers")));
            gvwProducts.Columns[8].Visible = userCanEdit;
            gvwProducts.Columns[9].Visible = userCanEdit;

            if (!this.IsPostBack)
            {
                // preselect the department whose ID is passed in the querystring
                if (!string.IsNullOrEmpty(this.Request.QueryString["DepID"]))
                {
                    ddlDepartments.SelectedDepartmentId = Int32.Parse(this.Request.QueryString["DepID"]);
                    ddlDepartments.BindData();
                    //ddlDepartments.SelectedValue = this.Request.QueryString["DepID"];
                }

                ddlDepartments.BindData();
                ddlCurrency.BindData();

                // Set the page size as indicated in the config file. If an option for that size
                // doesn't already exist, first create and then select it.
                //int pageSize = Globals.Settings.Store.PageSize;
                int pageSize = 50;
                if (ddlProductsPerPage.Items.FindByValue(pageSize.ToString()) == null)
                    ddlProductsPerPage.Items.Add(new ListItem(pageSize.ToString(), pageSize.ToString()));
                ddlProductsPerPage.SelectedValue = pageSize.ToString();
                gvwProducts.PageSize = pageSize;

                ProductBindGrid();
            }
        }

        protected void ProductBindGrid()
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

            if (!String.IsNullOrEmpty(txtTitleFilter.Text))
            {
                ProductCollection p1 = new ProductCollection();

                foreach (Product item in productCollection)
                {
                    if (item.Title.Trim().ToLower().Contains(txtTitleFilter.Text.Trim().ToLower()))
                        p1.Add(item);
                }

                gvwProducts.DataSource = p1;
                gvwProducts.DataBind();
            }
            else
            {
                gvwProducts.DataSource = productCollection;
                gvwProducts.DataBind();
            }
        }

        protected void gvwProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvwProducts.PageIndex = e.NewPageIndex;
            ProductBindGrid();
        }

        protected void gvwProducts_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton btn = e.Row.Cells[11].Controls[0] as ImageButton;
                btn.OnClientClick = "if (confirm('Подтвердите удаление товара?') == false) return false;";
            }
        }

        protected void gvwProducts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Product product = e.Row.DataItem as Product;

                ImageButton btn = e.Row.FindControl("btnChangeVisible") as ImageButton;

                if (btn != null)
                {
                    if (product.Visible)
                    {
                        btn.AlternateText = "Видимый товар";
                        btn.ImageUrl = "~/Images/vis.gif";
                    }
                    else
                    {
                        btn.AlternateText = "Невидимый товар";
                        btn.ImageUrl = "~/Images/unvis.gif";
                    }
                }
            }
        }

        protected void gvwProducts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddToCart")
            {
                //int productID = Convert.ToInt32(
                //   gvwProducts.DataKeys[Convert.ToInt32(e.CommandArgument)][0]);

                int productID = Convert.ToInt32(e.CommandArgument);

                Product product = ProductManager.GetByProductID(productID);
                this.Profile.ShoppingCart.InsertItem(product.ProductID, product.Title, product.SKU, product.FinalPrice, product.CurrencyID, product.CurrencyID);

                Control sc = Page.FindControl("ShoppingCartBox");

                if (sc != null)
                {
                    ProductBindGrid();
                }

                //this.Response.Redirect("ShoppingCart.aspx", false);
                //gvwProducts.DataBind();
            }
            if (e.CommandName == "ChangeVisible")
            {
                int productID = Convert.ToInt32(e.CommandArgument);

                Product product = ProductManager.GetByProductID(productID);

                ProductManager.ChangeVisible(productID, !product.Visible);

                ProductBindGrid();
            }
            //if (e.CommandName == "Delete")
            //{
            //    int productID = Convert.ToInt32(e.CommandArgument);

            //    ProductManager.DeleteProduct(productID);

            //    ProductBindGrid();
            //}
        }

        protected void gvwProducts_RowDeleting(Object sender, GridViewDeleteEventArgs e)
        {
            if (gvwProducts.Rows.Count <= 1)
            {
                e.Cancel = true;
            }
            else
            {
                int productID = (int)gvwProducts.DataKeys[e.RowIndex].Value;

                Product product = ProductManager.GetByProductID(productID);
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

                ProductManager.DeleteProduct(productID);
                ProductBindGrid();
            }
        }

        /// <summary>
        /// Смена отображения изображений товаров
        /// </summary>
        protected void chkGvwProductsHeader_CheckedChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvwProducts.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    (row.Cells[0].FindControl("chkGvwProducts") as CheckBox).Checked = (gvwProducts.HeaderRow.Cells[0].FindControl("chkGvwProductsHeader") as CheckBox).Checked;
                }
            }
        }

        /// <summary>
        /// Назначение производителя выделенным товарам
        /// </summary>
        protected void lnkManufacturerAssign_Click(object sender, EventArgs e)
        {
            int manufacturerID = Int32.Parse(ddlManufacturer.SelectedValue);

            foreach (GridViewRow row in gvwProducts.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    if ((row.Cells[0].FindControl("chkGvwProducts") as CheckBox).Checked)
                    {
                        HiddenField hf = row.Cells[0].FindControl("hfID") as HiddenField;
                        if (hf != null)
                        {
                            ProductManager.AssignProductManufacturer(Int32.Parse(hf.Value), manufacturerID);
                        }
                    }
                }
            }

            ProductBindGrid();
        }

        /// <summary>
        /// Назначение валюты выделенным товарам
        /// </summary>
        protected void lnkCurrencyAssign_Click(object sender, EventArgs e)
        {
            int currencyID = ddlCurrency.SelectedCurrencyId;

            foreach (GridViewRow row in gvwProducts.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    if ((row.Cells[0].FindControl("chkGvwProducts") as CheckBox).Checked)
                    {
                        HiddenField hf = row.Cells[0].FindControl("hfID") as HiddenField;
                        if (hf != null)
                        {
                            ProductManager.AssignProductCurrency(Int32.Parse(hf.Value), currencyID);
                        }
                    }
                }
            }

            ProductBindGrid();
        }

        /// <summary>
        /// Отобразить товары в соответствии с заданным условием
        /// </summary>
        protected void btnProduxtsView_Click(object sender, EventArgs e)
        {
            gvwProducts.PageSize = int.Parse(ddlProductsPerPage.SelectedValue);
            gvwProducts.PageIndex = 0;

            gvwProducts.Columns[1].Visible = chkImageVisible.Checked;

            ProductBindGrid();
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
                    bool allvalidate = true;

                    foreach (GridViewRow row in gvwProducts.Rows)
                    {
                        HiddenField hfID = row.FindControl("hfID") as HiddenField;
                        TextBox txtUnitPrice = row.FindControl("txtUnitPrice") as TextBox;
                        TextBox txtDiscountPercentage = row.FindControl("txtDiscountPercentage") as TextBox;
                        TextBox txtMarginPercentage = row.FindControl("txtMarginPercentage") as TextBox;

                        int productID = 0;
                        decimal unitPrice = 0.0m;
                        int discountPercentage = 0;
                        int marginPercentage = 0;

                        bool validate = true;

                        try
                        {
                            productID = int.Parse(hfID.Value);
                        }
                        catch
                        {
                            validate = false;
                            allvalidate = false;
                        }

                        try
                        {
                            unitPrice = decimal.Parse(txtUnitPrice.Text.Replace(".", ","));
                            txtUnitPrice.ForeColor = System.Drawing.Color.Black;
                            txtUnitPrice.Font.Bold = false;
                        }
                        catch
                        {
                            txtUnitPrice.ForeColor = System.Drawing.Color.Red;
                            txtUnitPrice.Font.Bold = true;
                            validate = false;
                            allvalidate = false;
                        }

                        try
                        {
                            discountPercentage = int.Parse(txtDiscountPercentage.Text);
                            txtDiscountPercentage.ForeColor = System.Drawing.Color.Black;
                            txtDiscountPercentage.Font.Bold = false;
                        }
                        catch
                        {
                            txtDiscountPercentage.ForeColor = System.Drawing.Color.Red;
                            txtDiscountPercentage.Font.Bold = true;
                            validate = false;
                            allvalidate = false;
                        }

                        try
                        {
                            marginPercentage = int.Parse(txtMarginPercentage.Text);
                            txtMarginPercentage.ForeColor = System.Drawing.Color.Black;
                            txtMarginPercentage.Font.Bold = false;
                        }
                        catch
                        {
                            txtMarginPercentage.ForeColor = System.Drawing.Color.Red;
                            txtMarginPercentage.Font.Bold = true;
                            validate = false;
                            allvalidate = false;
                        }
                            
                        if (validate)
                            ProductManager.ChangeUnitPriceAndDiscountPercentage(productID, unitPrice, discountPercentage, marginPercentage);
                    }

                    if (allvalidate)
                    {
                        lblAttribute.Text = "Сохранение проведено успешно";

                        ProductBindGrid();
                    }
                    else
                    {
                        lblAttribute.Text = "При сохранении были ошибки в полях выделенных красным цветом";
                    }
                }
                catch
                {
                    lblAttribute.Text = "Ошибка при сохранении";
                }
            }
        }
    }
}