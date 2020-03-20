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
using UC.BLL.Images;

namespace UC.UI.Controls
{
    public partial class ParsingProductListing : BaseWebPart
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

        int _filtr = 0;
        public int Filtr
        {
            get
            {
                if (_filtr == 0)
                {
                    // выбор ID раздела каталога из строки запроса
                    if (!string.IsNullOrEmpty(this.Request.QueryString["f"]))
                    {
                        _filtr = int.Parse(this.Request.QueryString["f"]);
                    }
                }
                return _filtr;
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

                lblTitle.Text = "Каталог " + catalog.Title + " от " + catalog.UpdateDate.ToString("f");

                ddlView.SelectedIndex = Filtr;

                PageSizeRender(MaximumRow);
                SortingRender(SortExpression);

                //Очистка кэша для загрузки обновленного каталога
                //ParsingProduct.RefreshProducts(catalog.SiteProviderType); --сделал только при щелчке, чтобы можно было вернуться к каталогу

                PagingTop.ProductCount = ParsingProduct.GetProductCount(CatalogID, Filtr);
                PagingTop.MaximumRow = MaximumRow;

                PagingBottom.ProductCount = ParsingProduct.GetProductCount(CatalogID, Filtr);
                PagingBottom.MaximumRow = MaximumRow;
            }

            //List<ParsingProduct> products = ParsingProduct.GetProducts(CatalogID, SortExpression, PagingTop.StartRowIndex, MaximumRow);
            //dlstProducts.DataSource = products;
            //dlstProducts.DataBind();
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            List<ParsingProduct> products = ParsingProduct.GetProducts(CatalogID, SortExpression, PagingTop.StartRowIndex, MaximumRow, ddlView.SelectedIndex);
            dlstProducts.DataSource = products;
            dlstProducts.DataBind();
        }

        protected void ddlView_SelectedIndexChanged(object sender, EventArgs e)
        {
            //PagingTop.ProductCount = ParsingProduct.GetProductCount(CatalogID, ddlView.SelectedIndex);
            //PagingTop.MaximumRow = MaximumRow;
            //PagingTop.PagingRender(1);

            //PagingBottom.ProductCount = ParsingProduct.GetProductCount(CatalogID, ddlView.SelectedIndex);
            //PagingBottom.MaximumRow = MaximumRow;
            //PagingBottom.PagingRender(1);

            Response.Redirect("ManageParsingProducts.aspx?CatalogID=" + CatalogID.ToString() + "&f=" + ddlView.SelectedIndex.ToString());
        }

        protected void btnRefreshCatalog_Click(object sender, EventArgs e)
        {
            //Очистка кэша для загрузки обновленного каталога
            //ParsingProduct.PurgeCache(ParsingCatalog.GetProviderTypeByID(CatalogID));
            this.Response.Redirect("RefreshParsingCatalog.aspx?CatalogID=" + CatalogID.ToString());
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

        //Выполняются операции по обновлению информации у связанного товара
        protected void dlstProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dlstProducts.SelectedValue != null)
            {
                int parsingProductID = Convert.ToInt32(dlstProducts.SelectedValue);

                CheckBox chkRefreshPrice = dlstProducts.SelectedItem.FindControl("chkRefreshPrice") as CheckBox;
                CheckBox chkRefImg = dlstProducts.SelectedItem.FindControl("chkRefImg") as CheckBox;
                CheckBox chkRefShortDescr = dlstProducts.SelectedItem.FindControl("chkRefShortDescr") as CheckBox;
                CheckBox chkRefLongDescr = dlstProducts.SelectedItem.FindControl("chkRefLongDescr") as CheckBox;

                if (chkRefreshPrice != null &
                    chkRefImg != null &
                    chkRefShortDescr != null &
                    chkRefLongDescr != null)
                {
                    ParsingProduct parsingProduct = ParsingProduct.GetProductByID(CatalogID, parsingProductID);

                    Product product = null;
                    string smallImageUrl = "";
                    string fullImageUrl = "";

                    if (chkRefImg.Checked)
                    {
                        if (!String.IsNullOrEmpty(parsingProduct.FullImageUrl))
                        {
                            smallImageUrl = Images.GetSmallImageUrl(parsingProduct.LinkID.ToString(), parsingProduct.FullImageUrl, Globals.Settings.Images.WatermarkText, Globals.Settings.Images.WatermarkFontSize, Globals.Settings.Images.SmallImageWidth, Globals.Settings.Images.SmallImageHeight);
                            fullImageUrl = Images.GetFullImageUrl(parsingProduct.LinkID.ToString(), parsingProduct.FullImageUrl, Globals.Settings.Images.WatermarkImagePath, Globals.Settings.Images.FullImageWidth, Globals.Settings.Images.FullImageHeight);
                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(parsingProduct.SmallImageUrl))
                            {
                                smallImageUrl = Images.GetSmallImageUrl(parsingProduct.LinkID.ToString(), parsingProduct.SmallImageUrl, Globals.Settings.Images.WatermarkText, Globals.Settings.Images.WatermarkFontSize, Globals.Settings.Images.SmallImageWidth, Globals.Settings.Images.SmallImageHeight);
                                fullImageUrl = Images.GetFullImageUrl(parsingProduct.LinkID.ToString(), parsingProduct.SmallImageUrl, Globals.Settings.Images.WatermarkImagePath, Globals.Settings.Images.FullImageWidth, Globals.Settings.Images.FullImageHeight);
                            }
                        }
                    }

                    if (parsingProduct.LinkID != 0)
                    {
                        product = ProductManager.GetByProductID(parsingProduct.LinkID);

                        ProductManager.UpdateProduct
                            (
                            product.ProductID,
                            //product.Title,
                            product.ProductTypeID,
                            product.Model,
                            (chkRefShortDescr.Checked ? parsingProduct.ShortDescription : product.ShortDescription),
                            (chkRefLongDescr.Checked ? parsingProduct.LongDescription : product.LongDescription),
                            0,
                            product.SKU,
                            0,
                            (chkRefreshPrice.Checked ? parsingProduct.UnitPrice : product.UnitPrice),
                            product.DiscountPercentage,
                            0,
                            product.UnitsInStock,
                            (!String.IsNullOrEmpty(smallImageUrl) ? smallImageUrl : product.SmallImageUrl),
                            (!String.IsNullOrEmpty(fullImageUrl) ? fullImageUrl : product.FullImageUrl),
                            product.Visible
                            );

                        ParsingProduct.PurgeCache();
                    }
                }
            }
        }

        protected void DeleteParsingProduct(Object sender, CommandEventArgs e)
        {
            if (!String.IsNullOrEmpty(e.CommandName))
            {
                if (e.CommandName == "Delete" & e.CommandArgument != null)
                {
                    ParsingProduct.DeleteProduct(Int32.Parse(e.CommandArgument.ToString()));
                }
            }
        }

        protected void ProductChangeView(Object sender, CommandEventArgs e)
        {
            if (!String.IsNullOrEmpty(e.CommandName))
            {
                if (e.CommandName == "ChangeVisible" & e.CommandArgument != null)
                {
                    Product product = ProductManager.GetByProductID(Int32.Parse(e.CommandArgument.ToString()));

                    if (product != null)
                    {
                        ProductManager.ChangeVisible(product.ProductID, !product.Visible);
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
                    case "Department":
                        {
                            if (SortExpression == "DepartmentTitle")
                                SortExpression = "DepartmentTitle DESC";
                            else
                                SortExpression = "DepartmentTitle";
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
            imgTitleAsc.Visible = false;
            imgTitleDesc.Visible = false;
            imgPriceAsc.Visible = false;
            imgPriceDesc.Visible = false;
            imgRatingAsc.Visible = false;
            imgRatingDesc.Visible = false;
            imgNewAsc.Visible = false;
            imgNewDesc.Visible = false;
            imgDepartmentAsc.Visible = false;
            imgDepartmentDesc.Visible = false;

            switch (sortexpression)
            {
                case "Title": { imgTitleAsc.Visible = true; break; }
                case "Title DESC": { imgTitleDesc.Visible = true; break; }
                case "UnitPrice": { imgPriceAsc.Visible = true; break; }
                case "UnitPrice DESC": { imgPriceDesc.Visible = true; break; }
                case "TotalRating": { imgRatingAsc.Visible = true; break; }
                case "TotalRating DESC": { imgRatingDesc.Visible = true; break; }
                case "AddedDate": { imgNewAsc.Visible = true; break; }
                case "AddedDate DESC": { imgNewDesc.Visible = true; break; }
                case "DepartmentTitle": { imgDepartmentAsc.Visible = true; break; }
                case "DepartmentTitle DESC": { imgDepartmentDesc.Visible = true; break; }
            }
        }
        protected void btnInsertProductInDepartment_Click(object sender, EventArgs e)
        {
            foreach (DataListItem item in dlstProducts.Items)
            {
                CheckBox chk = (CheckBox)item.FindControl("chk");
                //HtmlInputCheckBox chk = (HtmlInputCheckBox)item.FindControl("chk");

                if (chk != null)
                {
                    bool b = chk.Checked;

                    if (b)
                    {
                        chk.Checked = false;

                        Literal lit = (Literal)item.FindControl("litID");
                        if (lit != null)
                        {
                            int parsingProductID = Int32.Parse(lit.Text);

                            //получаем идентификатор раздела из списка
                            int departmentID = Int32.Parse(ddlDepartments.SelectedValue);

                            //если этого товара еще нет в нашем каталоге, то добавляем его с указанием раздела
                            //если этот товар уже есть в нашем каталоге, то обновляем его
                            ParsingProduct parsingProduct = ParsingProduct.GetProductByID(CatalogID, parsingProductID);

                            Product product = null;
                            int productID = 0;
                            string smallImageUrl = "";
                            string fullImageUrl = "";

                            if (parsingProduct.LinkID == 0) //т.е. связанного товара в базе нет
                            {
                                //добавляем товар - добавление товара происходит без правил

                                //..добавляем товар в основной каталог
                                //productID = Product.InsertProduct(departmentID, parsingProduct.Title, 0, parsingProduct.ShortDescription, parsingProduct.LongDescription,
                                product = ProductManager.InsertProduct
                                    (
                                    0,
                                    parsingProduct.Title, 
                                    parsingProduct.ShortDescription, 
                                    parsingProduct.LongDescription,
                                    0,
                                    parsingProduct.SKU, 
                                    0,
                                    parsingProduct.UnitPrice, 
                                    parsingProduct.DiscountPercentage, 
                                    0,
                                    parsingProduct.UnitsInStock, 
                                    "", 
                                    "",
                                    true);

                                //..обновляем товар каталога, поскольку внесли в него изменения - добавили связанный товар
                                parsingProduct.LinkID = product.ProductID;
                                parsingProduct.Update();
                            }
                            else
                            {
                                productID = parsingProduct.LinkID;
                            }

                            //..загружаем изображение для преобразования и получения ссылок
                            //if (!String.IsNullOrEmpty(parsingProduct.FullImageUrl))
                            //{
                            //    //..если картинка большого формата есть, то преобразуем из нее
                            //    smallImageUrl = Images.GetSmallImageUrl(productID.ToString(), parsingProduct.FullImageUrl);
                            //    fullImageUrl = Images.GetFullImageUrl(productID.ToString(), parsingProduct.FullImageUrl);
                            //}
                            //else
                            //{
                            //    //..если нет большого, то проверяем есть ли маленький и если есть сохраняем
                            //    if (!String.IsNullOrEmpty(parsingProduct.SmallImageUrl))
                            //    {
                            //        smallImageUrl = Images.GetSmallImageUrl(productID.ToString(), parsingProduct.SmallImageUrl);
                            //    }
                            //}

                            smallImageUrl = Images.GetSmallImageUrl(productID.ToString(), parsingProduct.SmallImageUrl, Globals.Settings.Images.WatermarkText, Globals.Settings.Images.WatermarkFontSize, Globals.Settings.Images.SmallImageWidth, Globals.Settings.Images.SmallImageHeight);
                            fullImageUrl = Images.GetFullImageUrl(productID.ToString(), parsingProduct.FullImageUrl, Globals.Settings.Images.WatermarkImagePath, Globals.Settings.Images.FullImageWidth, Globals.Settings.Images.FullImageHeight);

                            //if (smallImageUrl != "" | fullImageUrl != "")
                            //{
                            //bool resultUpdate = Product.UpdateProduct(productID, departmentID, parsingProduct.Title, 0, parsingProduct.ShortDescription, parsingProduct.LongDescription,
                            ProductManager.UpdateProduct
                                (
                                productID, 
                                0,
                                parsingProduct.Title, 
                                parsingProduct.ShortDescription, 
                                parsingProduct.LongDescription,
                                0, 
                                parsingProduct.SKU, 
                                0,
                                parsingProduct.UnitPrice, 
                                parsingProduct.DiscountPercentage, 
                                0,
                                parsingProduct.UnitsInStock, 
                                smallImageUrl, 
                                fullImageUrl,
                                true
                                );

                            ParsingProduct.PurgeCache();
                            //}
                        }
                    }
                }
            }

            ParsingProduct.PurgeCache();
        }

        /// <summary>
        /// Обновление цен выделенных товаров
        /// </summary>
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            bool isPrice = chkPrice.Checked;
            bool isImg = chkImg.Checked;
            bool isShortDescr = chkShortDescr.Checked;
            bool isLongDescr = chkLongDescr.Checked;

            if (isPrice || isImg || isShortDescr || isLongDescr)
            {
                foreach (DataListItem item in dlstProducts.Items)
                {
                    CheckBox chk = (CheckBox)item.FindControl("chk");

                    if (chk != null)
                    {
                        bool b = chk.Checked;

                        if (b)
                        {
                            chk.Checked = false;

                            Literal lit = (Literal)item.FindControl("litID");
                            if (lit != null)
                            {
                                int parsingProductID = Int32.Parse(lit.Text);

                                ParsingProduct parsingProduct = ParsingProduct.GetProductByID(CatalogID, parsingProductID);

                                if (parsingProduct.LinkID != 0)
                                {
                                    Product product = ProductManager.GetByProductID(parsingProduct.LinkID);

                                    string smallImageUrl = "";
                                    string fullImageUrl = "";

                                    if (isImg)
                                    {
                                        if (!String.IsNullOrEmpty(parsingProduct.FullImageUrl))
                                        {
                                            smallImageUrl = Images.GetSmallImageUrl(parsingProduct.LinkID.ToString(), parsingProduct.FullImageUrl, Globals.Settings.Images.WatermarkText, Globals.Settings.Images.WatermarkFontSize, Globals.Settings.Images.SmallImageWidth, Globals.Settings.Images.SmallImageHeight);
                                            fullImageUrl = Images.GetFullImageUrl(parsingProduct.LinkID.ToString(), parsingProduct.FullImageUrl, Globals.Settings.Images.WatermarkImagePath, Globals.Settings.Images.FullImageWidth, Globals.Settings.Images.FullImageHeight);
                                        }
                                        else
                                        {
                                            if (!String.IsNullOrEmpty(parsingProduct.SmallImageUrl))
                                            {
                                                smallImageUrl = Images.GetSmallImageUrl(parsingProduct.LinkID.ToString(), parsingProduct.SmallImageUrl, Globals.Settings.Images.WatermarkText, Globals.Settings.Images.WatermarkFontSize, Globals.Settings.Images.SmallImageWidth, Globals.Settings.Images.SmallImageHeight);
                                                fullImageUrl = Images.GetFullImageUrl(parsingProduct.LinkID.ToString(), parsingProduct.SmallImageUrl, Globals.Settings.Images.WatermarkImagePath, Globals.Settings.Images.FullImageWidth, Globals.Settings.Images.FullImageHeight);
                                            }
                                        }
                                    }

                                    ProductManager.UpdateProduct
                                        (
                                        product.ProductID,
                                        0,
                                        product.Title,
                                        (isShortDescr ? parsingProduct.ShortDescription : product.ShortDescription),
                                        (isLongDescr ? parsingProduct.LongDescription : product.LongDescription),
                                        product.ManufacturerID,
                                        product.SKU,
                                        0,
                                        (isPrice ? parsingProduct.UnitPrice : product.UnitPrice),
                                        product.DiscountPercentage,
                                        0,
                                        product.UnitsInStock,
                                        (!String.IsNullOrEmpty(smallImageUrl) ? smallImageUrl : product.SmallImageUrl),
                                        (!String.IsNullOrEmpty(fullImageUrl) ? fullImageUrl : product.FullImageUrl),
                                        product.Visible);
                                }
                            }
                        }
                    }
                }
                ParsingProduct.PurgeCache();
            }
        }
    }
}