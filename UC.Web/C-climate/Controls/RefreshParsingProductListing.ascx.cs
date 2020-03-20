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
using UC;
using UC.UI;
using UC.BLL.Parsing;
using UC.BLL.Store;

namespace UC.UI.Controls
{
    public partial class RefreshParsingProductListing : BaseWebPart
    {
        int _catalogID = 0;
        public int CatalogID
        {
            get
            {
                if (_catalogID == 0)
                {
                    // выбор ID раздела каталога из строки запроса
                    if (!string.IsNullOrEmpty(this.Request.QueryString["CatalogID"]))
                    {
                        _catalogID = int.Parse(this.Request.QueryString["CatalogID"]);
                    }
                }
                return _catalogID;
            }
        }

        string _sortExpression;
        public string SortExpression
        {
            get
            {
                //получение порядка сортировки из сессии
                //if (!String.IsNullOrEmpty((string)Session["product_sortexpression"]))
                //    _sortExpression = (string)Session["product_sortexpression"];

                //получение порядка сортировки из профиля
                if (!String.IsNullOrEmpty(this.Profile.ProductViewSorting))
                    _sortExpression = this.Profile.ProductViewSorting;

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
                this.Profile.ProductViewSorting = _sortExpression;
            }
        }

        int _maximumRow = 0;
        public int MaximumRow
        {
            get
            {
                //получение размера страницы из сессии
                //if (Session["product_maximumrow"] != null)
                //    _maximumRow = (int)Session["product_maximumrow"];

                //получение размера страницы из профиля
                if (this.Profile.ProductViewMaxRows != null)
                    _maximumRow = this.Profile.ProductViewMaxRows;

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
                //Session["product_maximumrow"] = _maximumRow; 

                //сохранение размера страницы в профиле
                this.Profile.ProductViewMaxRows = _maximumRow;
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
            //получение параметров из состояния вида
            //this.SortExpression = (string)ctlState[1];
            //this.MaximumRow = (int)ctlState[2];
        }

        protected override object SaveControlState()
        {
            //object[] ctlState = new object[3];
            object[] ctlState = new object[1];
            ctlState[0] = base.SaveControlState();
            //сохранение параметров в состоянии вида
            //ctlState[1] = this.SortExpression;
            //ctlState[2] = this.MaximumRow;
            return ctlState;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                // получение каталога по ID проверка есть ли такой раздел
                ParsingCatalog catalog = ParsingCatalog.GetCatalogByID(CatalogID);
                if (catalog == null)
                    throw new ApplicationException("Каталог не найден.");

                lblTitle.Text = "Обновление каталога " + catalog.Title;

                PageSizeRender(MaximumRow);
                SortingRender(SortExpression);

                //Очистка кэша для загрузки обновленного каталога
                //ParsingProduct.RefreshProducts(catalog.SiteProviderType); --сделал только при щелчке, чтобы можно было вернуться к каталогу

                PagingTop.ProductCount = ParsingProduct.GetProductCount(CatalogID, catalog.SiteProviderType);
                PagingTop.MaximumRow = MaximumRow;

                PagingBottom.ProductCount = ParsingProduct.GetProductCount(CatalogID, catalog.SiteProviderType);
                PagingBottom.MaximumRow = MaximumRow;
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            List<ParsingProduct> products = ParsingProduct.GetProducts(CatalogID, ParsingCatalog.GetProviderTypeByID(CatalogID), SortExpression, PagingTop.StartRowIndex, MaximumRow);
            dlstProducts.DataSource = products;
            dlstProducts.DataBind();
        }

        protected void dlstProducts_ItemCreated(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
             e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (e.Item.DataItem != null)
                {
                    if (((ParsingProduct)e.Item.DataItem).IsNew)
                    {
                        e.Item.BackColor = System.Drawing.Color.FromName("#ceff8d");
                    }

                    if (((ParsingProduct)e.Item.DataItem).IsUpdated)
                    {
                        e.Item.BackColor = System.Drawing.Color.FromName("#fffaa1");
                    }

                    if (((ParsingProduct)e.Item.DataItem).IsDeleted)
                    {
                        e.Item.BackColor = System.Drawing.Color.FromName("#e4e4e4");
                    }

                    if (((ParsingProduct)e.Item.DataItem).IsRestored)
                    {
                        e.Item.BackColor = System.Drawing.Color.FromName("#ffd392");
                    }
                }
            }
        }

        //Добавление товара в корзину - Можно заменить процедуру на добавление товара в каталог
        protected void dlstProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (dlstProducts.SelectedValue != null)
            //{
            //    int productID = Convert.ToInt32(dlstProducts.SelectedValue);

            //    TextBox txtQuantity = dlstProducts.SelectedItem.FindControl("txtQuantity") as TextBox;

            //    try
            //    {
            //        int quantity = Convert.ToInt32(txtQuantity.Text);

            //        if (quantity > 0)
            //        {
            //            Product product = Product.GetProductByID(productID);

            //            this.Profile.ShoppingCart.InsertItem(product.ID, product.Title, product.SKU, product.FinalPrice, quantity);

            //            txtQuantity.ForeColor = System.Drawing.Color.Black;
            //        }
            //        else
            //        {
            //            txtQuantity.ForeColor = System.Drawing.Color.Red;
            //        }
            //    }
            //    catch
            //    {
            //        txtQuantity.ForeColor = System.Drawing.Color.Red;
            //    }
            //}
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
                PagingTop.PagingRender(1);
                PagingBottom.PagingRender(1);
            }
        }

        protected void PageSize(Object sender, CommandEventArgs e)
        {
            if (!String.IsNullOrEmpty(e.CommandName))
            {
                PageSizeRender(Int32.Parse(e.CommandName));
                PagingTop.PagingRender(1, MaximumRow);
                PagingBottom.PagingRender(1, MaximumRow);
            }
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
            //imgTitleAsc.Visible = false;
            //imgTitleDesc.Visible = false;
            //imgPriceAsc.Visible = false;
            //imgPriceDesc.Visible = false;
            //imgRatingAsc.Visible = false;
            //imgRatingDesc.Visible = false;
            //imgNewAsc.Visible = false;
            //imgNewDesc.Visible = false;

            //switch (sortexpression)
            //{
            //    case "Title": { imgTitleAsc.Visible = true; break; }
            //    case "Title DESC": { imgTitleDesc.Visible = true; break; }
            //    case "UnitPrice": { imgPriceAsc.Visible = true; break; }
            //    case "UnitPrice DESC": { imgPriceDesc.Visible = true; break; }
            //    case "TotalRating": { imgRatingAsc.Visible = true; break; }
            //    case "TotalRating DESC": { imgRatingDesc.Visible = true; break; }
            //    case "AddedDate": { imgNewAsc.Visible = true; break; }
            //    case "AddedDate DESC": { imgNewDesc.Visible = true; break; }
            //}
        }
        protected void btnRefreshCatalog_Click(object sender, EventArgs e)
        {
            if (ParsingProduct.UpdateProductsAll(CatalogID, ParsingCatalog.GetProviderTypeByID(CatalogID)))
            {
                this.Response.Redirect("ManageParsingProducts.aspx?CatalogID=" + CatalogID.ToString());
            }
        }
    }
}