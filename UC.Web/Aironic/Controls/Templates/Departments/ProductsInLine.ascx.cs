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
    public partial class ProductsInLine : BaseWebPart
    {
        private bool _userCanEdit = false;
        protected bool UserCanEdit
        {
            get { return _userCanEdit; }
            set { _userCanEdit = value; }
        }

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

        protected void Page_Init(object sender, EventArgs e)
        {
            UserCanEdit = (Page.User.Identity.IsAuthenticated &&
               (Page.User.IsInRole("Administrators") || Page.User.IsInRole("StoreKeepers")));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Department department = DepartmentManager.GetByDepartmentID(DepartmentID);

                if (department != null)
                {
                    lblTitle.Text = department.MetaTitle;
                }

                DoBinding();
            }
        }

        protected void DoBinding()
        {
            DepartmentCollection departmentCollection = DepartmentManager.GetDepartments(DepartmentID);
            dlstDepartments.DataSource = departmentCollection;
            dlstDepartments.DataBind();
        }

        protected void ucFilter_Filtered(Object sender)
        {
            DoBinding();
        }

        protected void gvwProducts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                if (!String.IsNullOrEmpty(e.CommandArgument.ToString()))
                {
                    int productID = Convert.ToInt32(e.CommandArgument);

                    GridView gv = (GridView)sender;

                    foreach (GridViewRow row in gv.Rows)
                    {
                        HiddenField hfProductID = row.FindControl("hfProductID") as HiddenField;

                        int index = int.Parse(hfProductID.Value);

                        if (index == productID)
                        {
                            TextBox txtQuantity = row.FindControl("txtQuantity") as TextBox;

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

                    DoBinding();
                }
            }
            if (e.CommandName == "Copy")
            {
                if (!String.IsNullOrEmpty(e.CommandArgument.ToString()))
                {
                    int productID = Convert.ToInt32(e.CommandArgument);

                    if (productID > 0)
                    {
                        // опирование товара
                        Product product = ProductManager.GetByProductID(productID);

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

                        // опируем характеристики товара
                        ProductAttributeMappingCollection productAttributeMappingCollection = ProductAttributeMappingManager.GetProductAttributeMappingByProductID(productID);
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

                        // опируем св€занные товары
                        ProductRelatedCollection productRelatedCollection = ProductRelatedManager.GetProductRelatedByProductID1(productID);
                        foreach (ProductRelated item in productRelatedCollection)
                        {
                            ProductRelatedManager.InsertProductRelated
                            (
                            productCopy.ProductID,
                            item.ProductID2,
                            item.DisplayOrder
                            );
                        }

                        // опируем разделы
                        ProductDepartmentMappingCollection productDepartmentMappingCollection = ProductDepartmentMappingManager.GetProductDepartmentMappingByProductID(productID);
                        foreach (ProductDepartmentMapping item in productDepartmentMappingCollection)
                        {
                            ProductDepartmentMappingManager.InsertProductDepartmentMapping
                            (
                            productCopy.ProductID,
                            item.DepartmentID,
                            item.DisplayOrder
                            );
                        }

                        // опируем критерии фильтрации
                        FilterCriteriaProductCollection filterCriteriaProductCollection = FilterCriteriaProductManager.GetFilterCriteriaProductByProductID(productID);
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
            if (e.CommandName == "Delete")
            {
                if (!String.IsNullOrEmpty(e.CommandArgument.ToString()))
                {
                    int productID = Convert.ToInt32(e.CommandArgument);

                    //удаление рисунков на товар
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

                    //удаление товара
                    ProductManager.DeleteProduct(productID);
                }
            }
        }

        /// <summary>
        /// ”даление товара из раздела
        /// </summary>
        protected void gvwProducts_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DoBinding();
        }

        protected void gvwProducts_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Panel panEditProduct = (Panel)e.Row.FindControl("panEditProduct");

                if (panEditProduct != null)
                    panEditProduct.Visible = this.UserCanEdit;
            }
        }

        private class ProductHelperClass
        {
            public int ProductID { get; set; }
            public string Title { get; set; }
            public double AverageRating { get; set; }
            public string SKU { get; set; }
            public decimal UnitPrice { get; set; }
            public int DiscountPercentage { get; set; }
            public decimal FinalPrice { get; set; }
            public int UnitsInStock { get; set; }
            public string Attr1 { get; set; }
            public string Attr2 { get; set; }
            public string Attr3 { get; set; }
            public string Attr4 { get; set; }
            public string Attr5 { get; set; }
            public string Attr6 { get; set; }
            public string Attr7 { get; set; }
            public string Attr8 { get; set; }
            public string Attr9 { get; set; }
        }

        protected void dlstDepartments_ItemCreated(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
                e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Department department = (Department)e.Item.DataItem;

                GridView gvwProducts = (GridView)e.Item.FindControl("gvwProducts");

                if (gvwProducts != null && department != null)
                {
                    //ѕолучаем коллекцию товаров раздела
                    IEnumerable<Product> productCollection;

                    ProductDepartmentMappingCollection productDepartmentCollection = ProductDepartmentMappingManager.GetProductDepartmentMappingByDepartmentID(department.DepartmentID, true);
                    productCollection = productDepartmentCollection.Select(p => p.Product);

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

                                productCollection = productCollection.Join(fcps, p => p.ProductID, o => o.ProductID, (p, o) => p);
                            }
                        }
                    }

                    //класс содержащий данные дл€ вывода в таблицу
                    List<ProductHelperClass> products = new List<ProductHelperClass>();

                    // ласс который будет использоватьс€ дл€ динамического формировани€ таблицы
                    ProductAttributeCollection productAttributeCollection = new ProductAttributeCollection();

                    foreach (Product item in productCollection)
                    {
                        ProductHelperClass rp = new ProductHelperClass();

                        rp.ProductID = item.ProductID;
                        //rp.Title = item.Title;
                        rp.Title = item.Model;
                        rp.AverageRating = item.AverageRating;
                        rp.SKU = item.SKU;
                        rp.UnitPrice = CurrencyManager.ConvertCurrency(item.Price, item.Currency, CurrencyManager.WorkingCurrency);
                        rp.DiscountPercentage = item.DiscountPercentage;
                        rp.FinalPrice = CurrencyManager.ConvertCurrency(item.FinalPrice, item.Currency, CurrencyManager.WorkingCurrency); 
                        rp.UnitsInStock = item.UnitsInStock;

                        ProductAttributeMappingCollection productAttributesMapping = null;

                        productAttributesMapping = ProductAttributeMappingManager.GetProductAttributeMappingByProductIDInShort(item.ProductID);

                        //цикл по характеристикам дл€ заполнени€ класса rp
                        foreach (ProductAttributeMapping item2 in productAttributesMapping)
                        {
                            // ищем характеристику в общем списке
                            bool compare = false;
                            for (int i = 0; i < productAttributeCollection.Count; i++)
                            {
                                if (productAttributeCollection[i] == item2.ProductAttribute)
                                {
                                    //если нашли то берем номер и указываем в классе rp свойству с таким номером значение
                                    compare = true;
                                    switch (i)
                                    {
                                        case 0:
                                            rp.Attr1 = item2.AttributeValue;
                                            break;
                                        case 1:
                                            rp.Attr2 = item2.AttributeValue;
                                            break;
                                        case 2:
                                            rp.Attr3 = item2.AttributeValue;
                                            break;
                                        case 3:
                                            rp.Attr4 = item2.AttributeValue;
                                            break;
                                        case 4:
                                            rp.Attr5 = item2.AttributeValue;
                                            break;
                                        case 5:
                                            rp.Attr6 = item2.AttributeValue;
                                            break;
                                        case 6:
                                            rp.Attr7 = item2.AttributeValue;
                                            break;
                                        case 7:
                                            rp.Attr8 = item2.AttributeValue;
                                            break;
                                        case 8:
                                            rp.Attr9 = item2.AttributeValue;
                                            break;
                                    }
                                    break;
                                }
                            }
                            //если не нашли добавл€ем в общий список и указываем соответствующему свойству значение
                            if (!compare)
                            {
                                productAttributeCollection.Add(item2.ProductAttribute);
                                switch (productAttributeCollection.Count - 1)
                                {
                                    case 0:
                                        rp.Attr1 = item2.AttributeValue;
                                        break;
                                    case 1:
                                        rp.Attr2 = item2.AttributeValue;
                                        break;
                                    case 2:
                                        rp.Attr3 = item2.AttributeValue;
                                        break;
                                    case 3:
                                        rp.Attr4 = item2.AttributeValue;
                                        break;
                                    case 4:
                                        rp.Attr5 = item2.AttributeValue;
                                        break;
                                    case 5:
                                        rp.Attr6 = item2.AttributeValue;
                                        break;
                                    case 6:
                                        rp.Attr7 = item2.AttributeValue;
                                        break;
                                    case 7:
                                        rp.Attr8 = item2.AttributeValue;
                                        break;
                                    case 8:
                                        rp.Attr9 = item2.AttributeValue;
                                        break;
                                }
                            }
                        }

                        products.Add(rp);
                    }

                    //формируем столбцы дополнительно
                    for (int i = 0; i < productAttributeCollection.Count; i++)
                    {
                        gvwProducts.Columns[i + 2].HeaderText = productAttributeCollection[i].Name;
                        gvwProducts.Columns[i + 2].Visible = true;
                    }

                    gvwProducts.DataSource = products;
                }
            }
        }
    }

    //public class GridViewTemplate : ITemplate
    //{
    //    private DataControlRowType templateType;
    //    private string columnName;
    //    private string fieldName;

    //    public GridViewTemplate(DataControlRowType type, string colname, string fName)
    //    {
    //        templateType = type;
    //        columnName = colname;
    //        fieldName = fName;
    //    }

    //    public void InstantiateIn(System.Web.UI.Control container)
    //    {
    //        // —оздаем конент дл€ различного типа строк
    //        switch (templateType)
    //        {
    //            case DataControlRowType.Header:
    //                Literal lc = new Literal();
    //                lc.Text = "<b>" + columnName + "</b>";
    //                container.Controls.Add(lc);
    //                break;
    //            case DataControlRowType.DataRow:
    //                Label attribute = new Label();
    //                attribute.DataBinding += new EventHandler(this.Attribute_DataBinding);
    //                container.Controls.Add(attribute);
    //                break;
    //            default:
    //                break;
    //        }
    //    }

    //    private void Attribute_DataBinding(Object sender, EventArgs e)
    //    {
    //        Label l = (Label)sender;
    //        GridViewRow row = (GridViewRow)l.NamingContainer;
    //        l.Text = DataBinder.Eval(row.DataItem, fieldName).ToString();
    //    }
    //}

    ////формируем столбцы дополнительно
    //for (int i = 0; i < productAttributeCollection.Count; i++)
    //{
    //    TemplateField customField = new TemplateField();

    //    switch (i)
    //    {
    //        case 0:
    //            customField.HeaderTemplate = new GridViewTemplate(DataControlRowType.Header, productAttributeCollection[i].Name, "Attr1");
    //            customField.ItemTemplate = new GridViewTemplate(DataControlRowType.DataRow, "---", "Attr1");
    //            break;
    //        case 1:
    //            customField.HeaderTemplate = new GridViewTemplate(DataControlRowType.Header, productAttributeCollection[i].Name, "Attr2");
    //            customField.ItemTemplate = new GridViewTemplate(DataControlRowType.DataRow, "---", "Attr2");
    //            break;
    //        case 2:
    //            customField.HeaderTemplate = new GridViewTemplate(DataControlRowType.Header, productAttributeCollection[i].Name, "Attr3");
    //            customField.ItemTemplate = new GridViewTemplate(DataControlRowType.DataRow, "---", "Attr3");
    //            break;
    //        case 3:
    //            customField.HeaderTemplate = new GridViewTemplate(DataControlRowType.Header, productAttributeCollection[i].Name, "Attr4");
    //            customField.ItemTemplate = new GridViewTemplate(DataControlRowType.DataRow, "---", "Attr4");
    //            break;
    //        case 4:
    //            customField.HeaderTemplate = new GridViewTemplate(DataControlRowType.Header, productAttributeCollection[i].Name, "Attr5");
    //            customField.ItemTemplate = new GridViewTemplate(DataControlRowType.DataRow, "---", "Attr5");
    //            break;
    //        case 5:
    //            customField.HeaderTemplate = new GridViewTemplate(DataControlRowType.Header, productAttributeCollection[i].Name, "Attr6");
    //            customField.ItemTemplate = new GridViewTemplate(DataControlRowType.DataRow, "---", "Attr6");
    //            break;
    //        case 6:
    //            customField.HeaderTemplate = new GridViewTemplate(DataControlRowType.Header, productAttributeCollection[i].Name, "Attr7");
    //            customField.ItemTemplate = new GridViewTemplate(DataControlRowType.DataRow, "---", "Attr7");
    //            break;
    //        case 7:
    //            customField.HeaderTemplate = new GridViewTemplate(DataControlRowType.Header, productAttributeCollection[i].Name, "Attr8");
    //            customField.ItemTemplate = new GridViewTemplate(DataControlRowType.DataRow, "---", "Attr8");
    //            break;
    //        case 8:
    //            customField.HeaderTemplate = new GridViewTemplate(DataControlRowType.Header, productAttributeCollection[i].Name, "Attr9");
    //            customField.ItemTemplate = new GridViewTemplate(DataControlRowType.DataRow, "---", "Attr9");
    //            break;
    //    }

    //    gvwProducts.Columns.Insert(i + 2, customField);
    //}
}