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

namespace UC.UI.Controls
{
    public partial class DepartmentProductListing : BaseWebPart
    {
        int _departmentID = 0;
        public int DepartmentID
        {
            get
            {
                if (_departmentID == 0)
                {
                    // выбор ID раздела каталога из строки запроса
                    if (!string.IsNullOrEmpty(this.Request.QueryString["DepID"]))
                    {
                        _departmentID = int.Parse(this.Request.QueryString["DepID"]);
                    }
                }
                return _departmentID;
            }
        }

        int _manufacturerID = 0;
        public int ManufacturerID
        {
            get
            {
                if (_manufacturerID == 0)
                {
                    // выбор ID раздела каталога из строки запроса
                    if (!string.IsNullOrEmpty(this.Request.QueryString["ManID"]))
                    {
                        _manufacturerID = int.Parse(this.Request.QueryString["ManID"]);
                    }
                }
                return _manufacturerID;
            }
        }

        string _sortExpression;
        public string SortExpression
        {
            get
            {
                //получение порядка сортировки из сессии
                if (!String.IsNullOrEmpty((string)Session["product_sortexpression"]))
                    _sortExpression = (string)Session["product_sortexpression"];

                //получение порядка сортировки из профиля
                //if (!String.IsNullOrEmpty(this.Profile.ProductViewSorting))
                //    _sortExpression = this.Profile.ProductViewSorting;

                if (String.IsNullOrEmpty(_sortExpression))
                {
                    _sortExpression = "Title";
                }
                return _sortExpression;
            }
            set
            {
                _sortExpression = value;

                //сохранение порядка сортировки в сессии
                Session["product_sortexpression"] = _sortExpression;

                //сохранение порядка сортировки в профиле
                //this.Profile.ProductViewSorting = _sortExpression;
            }
        }

        int _maximumRow = 0;
        public int MaximumRow
        {
            get
            {
                //получение размера страницы из сессии
                if (Session["product_maximumrow"] != null)
                    _maximumRow = (int)Session["product_maximumrow"];

                //получение размера страницы из профиля
                //if (this.Profile.ProductViewMaxRows != null)
                //    _maximumRow = this.Profile.ProductViewMaxRows;

                if (_maximumRow == 0)
                {
                    _maximumRow = Globals.Settings.Store.PageSize;
                }
                return _maximumRow;
            }
            set
            {
                _maximumRow = value;

                //сохранение размера страницы в сессии
                Session["product_maximumrow"] = _maximumRow; 

                //сохранение размера страницы в профиле
                //this.Profile.ProductViewMaxRows = _maximumRow;
            }
        }

        bool _extendedTitle = false;
        public bool ExtendedTitle
        {
            get
            {
                return _extendedTitle;
            }
            set
            {
                _extendedTitle = value;
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            this.Page.RegisterRequiresControlState(this);
        }

        protected override void LoadControlState(object savedState)
        {
            object[] ctlState = (object[])savedState;
            base.LoadControlState(ctlState[0]);
        }

        protected override object SaveControlState()
        {
            object[] ctlState = new object[1];
            ctlState[0] = base.SaveControlState();
            return ctlState;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                // получение раздела каталога по ID прверка есть ли такой раздел
                Department department = DepartmentManager.GetByDepartmentID(DepartmentID);
                Manufacturer manufacturer = ManufacturerManager.GetManufacturerByID(ManufacturerID);

                if (!(manufacturer != null & department != null))
                {
                    PageSizeRender(MaximumRow);
                    SortingRender(SortExpression);

                    PagingTop.SessionKey = "product_page_" + DepartmentID.ToString() + ManufacturerID.ToString();
                    PagingTop.MaximumRow = MaximumRow;

                    PagingBottom.SessionKey = "product_page_" + DepartmentID.ToString() + ManufacturerID.ToString();
                    PagingBottom.MaximumRow = MaximumRow;

                    Session["last_product_page"] = Page.Request.Url.AbsoluteUri;

                    ProductsBind();

                    PagingTop.PagingRender();
                    PagingBottom.PagingRender();
                }
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            //ProductsBind();
        }

        protected int ProductsBind()
        {
            IEnumerable<Product> productCollection;

            if (ManufacturerID > 0)
            {
                ProductCollection products = ProductManager.GetByManufacturerID(ManufacturerID, true);

                productCollection = products.Select(p => p);
            }
            else
            {
                ProductDepartmentMappingCollection productDepartmentCollection = ProductDepartmentMappingManager.GetProductDepartmentMappingByDepartmentID(DepartmentID, true);
                productCollection = productDepartmentCollection.Select(p => p.Product);
            }

            //учитываем фильтрацию
            foreach (Filter item in ucFilter.Filters)
            {
                FilterCriteriaCollection fc = ucFilter.GetFilterCriteriaByFilterID(item.FilterID);

                if (fc != null)
                {
                    if (fc.Count > 0)
                    {
                        FilterCriteriaProductCollection fcps = new FilterCriteriaProductCollection();

                        foreach (FilterCriteria item2 in fc)
                        {
                            fcps.AddRange(FilterCriteriaProductManager.GetFilterCriteriaProductByFilterCriteriaID(item2.FilterCriteriaID));
                        }

                        productCollection = productCollection.Join(fcps, e => e.ProductID, o => o.ProductID, (e, o) => e);
                    }
                }
            }

            int count = productCollection.Count();

            PagingTop.ProductCount = count;
            PagingBottom.ProductCount = count;

            switch (SortExpression)
            {
                case "Title": { productCollection = productCollection.OrderBy(p => p.Title); break; }
                case "Title DESC": { productCollection = productCollection.OrderByDescending(p => p.Title); break; }
                case "UnitPrice": { productCollection = productCollection.OrderBy(p => p.UnitPrice); break; }
                case "UnitPrice DESC": { productCollection = productCollection.OrderByDescending(p => p.UnitPrice); break; }
                case "TotalRating": { productCollection = productCollection.OrderBy(p => p.TotalRating); break; }
                case "TotalRating DESC": { productCollection = productCollection.OrderByDescending(p => p.TotalRating); break; }
                case "AddedDate": { productCollection = productCollection.OrderBy(p => p.AddedDate); break; }
                case "AddedDate DESC": { productCollection = productCollection.OrderByDescending(p => p.AddedDate); break; }
            }

            productCollection = productCollection.Where((p, i) => ((i >= PagingTop.StartRowIndex) & (i < (PagingTop.StartRowIndex + MaximumRow))));

            dlstProducts.DataSource = productCollection;
            dlstProducts.DataBind();

            return count;
        }

        //Добавление товара в корзину
        protected void dlstProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dlstProducts.SelectedValue != null)
            {
                int productID = Convert.ToInt32(dlstProducts.SelectedValue);

                ProductView productView = dlstProducts.SelectedItem.FindControl("ProductView") as ProductView;

                if (productView != null)
                {
                    TextBox txtQuantity = productView.FindControl("txtQuantity") as TextBox;

                    if (txtQuantity != null)
                    {
                        try
                        {
                            int quantity = Convert.ToInt32(txtQuantity.Text);

                            if (quantity > 0)
                            {
                                Product product = ProductManager.GetByProductID(productID);

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
                }
            }
        }

        protected void Sorting(Object sender, CommandEventArgs e)
        {
            if (!String.IsNullOrEmpty(e.CommandName))
            {
                switch (e.CommandName)
                {
                    case "Title":
                        {
                            if (SortExpression == "Title")
                                SortExpression = "Title DESC";
                            else
                                SortExpression = "Title";
                            break;
                        }
                    case "Price":
                        {
                            if (SortExpression == "UnitPrice")
                                SortExpression = "UnitPrice DESC";
                            else
                                SortExpression = "UnitPrice";
                            break;
                        }
                    case "Rating":
                        {
                            if (SortExpression == "TotalRating DESC")
                                SortExpression = "TotalRating";
                            else
                                SortExpression = "TotalRating DESC";
                            break;
                        }
                    case "New":
                        {
                            if (SortExpression == "AddedDate")
                                SortExpression = "AddedDate DESC";
                            else
                                SortExpression = "AddedDate";
                            break;
                        }
                }
                SortingRender(SortExpression);
                ProductsBind();
                PagingTop.PagingRender(1, "product_page_");
                PagingBottom.PagingRender(1);
            }
        }

        protected void PageSize(Object sender, CommandEventArgs e)
        {
            if (!String.IsNullOrEmpty(e.CommandName))
            {
                PageSizeRender(Int32.Parse(e.CommandName));
                ProductsBind();
                PagingTop.PagingRender(1, MaximumRow, "product_page_");
                PagingBottom.PagingRender(1, MaximumRow);
            }
        }

        protected void ucFilter_Filtered(Object sender)
        {
            ProductsBind();
            PagingTop.PagingRender(1, MaximumRow, "product_page_");
            PagingBottom.PagingRender(1, MaximumRow);
        }

        protected void PageSizeRender(int maximumrow)
        {
            lbtn10.ForeColor = System.Drawing.ColorTranslator.FromHtml("#9aaab1");
            lbtn10.BackColor = System.Drawing.Color.White;
            lbtn20.ForeColor = System.Drawing.ColorTranslator.FromHtml("#9aaab1");
            lbtn20.BackColor = System.Drawing.Color.White;
            lbtn30.ForeColor = System.Drawing.ColorTranslator.FromHtml("#9aaab1");
            lbtn30.BackColor = System.Drawing.Color.White;
            lbtn40.ForeColor = System.Drawing.ColorTranslator.FromHtml("#9aaab1");
            lbtn40.BackColor = System.Drawing.Color.White;
            lbtn50.ForeColor = System.Drawing.ColorTranslator.FromHtml("#9aaab1");
            lbtn50.BackColor = System.Drawing.Color.White;
            switch (maximumrow)
            {
                case 10:
                    {
                        lbtn10.ForeColor = System.Drawing.Color.White;
                        lbtn10.BackColor = System.Drawing.ColorTranslator.FromHtml("#9aaab1");
                        MaximumRow = 10;
                        break;
                    }
                case 20:
                    {
                        lbtn20.ForeColor = System.Drawing.Color.White;
                        lbtn20.BackColor = System.Drawing.ColorTranslator.FromHtml("#9aaab1");
                        MaximumRow = 20;
                        break;
                    }
                case 30:
                    {
                        lbtn30.ForeColor = System.Drawing.Color.White;
                        lbtn30.BackColor = System.Drawing.ColorTranslator.FromHtml("#9aaab1");
                        MaximumRow = 30;
                        break;
                    }
                case 40:
                    {
                        lbtn40.ForeColor = System.Drawing.Color.White;
                        lbtn40.BackColor = System.Drawing.ColorTranslator.FromHtml("#9aaab1");
                        MaximumRow = 40;
                        break;
                    }
                case 50:
                    {
                        lbtn50.ForeColor = System.Drawing.Color.White;
                        lbtn50.BackColor = System.Drawing.ColorTranslator.FromHtml("#9aaab1");
                        MaximumRow = 50;
                        break;
                    }
            }
        }

        protected void SortingRender(string sortexpression)
        {
            imgTitleAsc.Visible = false;
            imgTitleDesc.Visible = false;
            imgPriceAsc.Visible = false;
            imgPriceDesc.Visible = false;
            imgRatingAsc.Visible = false;
            imgRatingDesc.Visible = false;
            //imgNewAsc.Visible = false;
            //imgNewDesc.Visible = false;

            switch (sortexpression)
            {
                case "Title": { imgTitleAsc.Visible = true; break; }
                case "Title DESC": { imgTitleDesc.Visible = true; break; }
                case "UnitPrice": { imgPriceAsc.Visible = true; break; }
                case "UnitPrice DESC": { imgPriceDesc.Visible = true; break; }
                case "TotalRating": { imgRatingAsc.Visible = true; break; }
                case "TotalRating DESC": { imgRatingDesc.Visible = true; break; }
                //case "AddedDate": { imgNewAsc.Visible = true; break; }
                //case "AddedDate DESC": { imgNewDesc.Visible = true; break; }
            }
        }
    }
}