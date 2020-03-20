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
using UC.BLL.Search;

namespace UC.UI.Controls
{
    public partial class SearchProductListing : BaseWebPart
    {
        string _searchwords = "";
        public string SearchWords
        {
            get
            {
                // выбор поискового запроса из строки запроса
                if (!string.IsNullOrEmpty(this.Request.QueryString["sw"]))
                {
                    _searchwords = this.Request.QueryString["sw"];
                }
                return _searchwords;
            }
        }

        string _sortExpression;
        public string SortExpression
        {
            get
            {
                //получение порядка сортировки из сессии
                if (!String.IsNullOrEmpty((string)Session["product_search_sortexpression"]))
                    _sortExpression = (string)Session["product_search_sortexpression"];

                if (String.IsNullOrEmpty(_sortExpression))
                {
                    _sortExpression = "Rank DESC";
                }
                return _sortExpression;
            }
            set
            {
                _sortExpression = value;

                //сохранение порядка сортировки в сессии
                Session["product_search_sortexpression"] = _sortExpression;
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
            lblSearchWords.Text = "Вы искали: \"" + SearchWords + "\"";

            if (!this.IsPostBack)
            {
                PageSizeRender(MaximumRow);
                SortingRender(SortExpression);

                int count = ProductSearchedManager.GetProductsSearch(SearchWords).Count;

                PagingTop.SessionKey = "product_page_" + SearchWords.Replace(" ", "_").ToLower();
                PagingTop.MaximumRow = MaximumRow;

                PagingTop.SessionKey = "product_page_" + SearchWords.Replace(" ", "_").ToLower();
                PagingBottom.MaximumRow = MaximumRow;

                Session["last_product_page"] = Page.Request.Url.AbsoluteUri;

                SearchRequest.InsertSearchRequest(SearchWords, count);

                ProductsBind();

                PagingTop.PagingRender();
                PagingBottom.PagingRender();
            }
        }

        protected int ProductsBind()
        {
            //List<Product> products = Product.GetProducts(SearchWords, SortExpression, PagingTop.StartRowIndex, MaximumRow);
            //dlstProducts.DataSource = products;

            ProductSearchedCollection productSearchedCollection = ProductSearchedManager.GetProductsSearch(SearchWords);

            IEnumerable<Product> productCollection;

            int count = productSearchedCollection.Count();

            PagingTop.ProductCount = count;
            PagingBottom.ProductCount = count;

            switch (SortExpression)
            {
                case "rank": { productCollection = productSearchedCollection.OrderBy(p => p.Rank).Select(p => p.Product).Where(p => p.Visible = true); break; }
                case "rank desc": { productCollection = productSearchedCollection.OrderByDescending(p => p.Rank).Select(p => p.Product).Where(p => p.Visible = true); break; }
                case "Title": { productCollection = productSearchedCollection.Select(p => p.Product).Where(p => p.Visible = true).OrderBy(p => p.Title); break; }
                case "Title DESC": { productCollection = productSearchedCollection.Select(p => p.Product).Where(p => p.Visible = true).OrderByDescending(p => p.Title); break; }
                case "UnitPrice": { productCollection = productSearchedCollection.Select(p => p.Product).Where(p => p.Visible = true).OrderBy(p => p.UnitPrice); break; }
                case "UnitPrice DESC": { productCollection = productSearchedCollection.Select(p => p.Product).Where(p => p.Visible = true).OrderByDescending(p => p.UnitPrice); break; }
                case "TotalRating": { productCollection = productSearchedCollection.Select(p => p.Product).Where(p => p.Visible = true).OrderBy(p => p.TotalRating); break; }
                case "TotalRating DESC": { productCollection = productSearchedCollection.Select(p => p.Product).Where(p => p.Visible = true).OrderByDescending(p => p.TotalRating); break; }
                case "AddedDate": { productCollection = productSearchedCollection.Select(p => p.Product).Where(p => p.Visible = true).OrderBy(p => p.AddedDate); break; }
                case "AddedDate DESC": { productCollection = productSearchedCollection.Select(p => p.Product).Where(p => p.Visible = true).OrderByDescending(p => p.AddedDate); break; }
                default: { productCollection = productSearchedCollection.OrderBy(p => p.Rank).Select(p => p.Product).Where(p => p.Visible = true); break; }
            }

            productCollection = productCollection.Where((p, i) => ((i >= PagingTop.StartRowIndex) & (i < (PagingTop.StartRowIndex + MaximumRow))));

            dlstProducts.DataSource = productCollection;
            dlstProducts.DataBind();

            return count;
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            //
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
                    case "Rank":
                        {
                            if (SortExpression == "Rank")
                                SortExpression = "Rank DESC";
                            else
                                SortExpression = "Rank";
                            break;
                        }
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
            imgRankAsc.Visible = false;
            imgRankDesc.Visible = false;
            imgTitleAsc.Visible = false;
            imgTitleDesc.Visible = false;
            imgPriceAsc.Visible = false;
            imgPriceDesc.Visible = false;
            imgRatingAsc.Visible = false;
            imgRatingDesc.Visible = false;
            //imgNewAsc.Visible = false;
            //imgNewDesc.Visible = false;

            switch (sortexpression.ToLower())
            {
                case "rank": { imgRankAsc.Visible = true; break; }
                case "rank desc": { imgRankDesc.Visible = true; break; }
                case "title": { imgTitleAsc.Visible = true; break; }
                case "title desc": { imgTitleDesc.Visible = true; break; }
                case "unitprice": { imgPriceAsc.Visible = true; break; }
                case "unitprice desc": { imgPriceDesc.Visible = true; break; }
                case "totalrating": { imgRatingAsc.Visible = true; break; }
                case "totalrating desc": { imgRatingDesc.Visible = true; break; }
                //case "addeddate": { imgNewAsc.Visible = true; break; }
                //case "addeddate desc": { imgNewDesc.Visible = true; break; }
            }
        }
    }
}