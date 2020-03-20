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
using UC;
using UC.UI;
using UC.BLL.Store;

namespace UC.UI.Controls
{
    public partial class DepartmentMenu : BaseWebPart
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }

        protected void BindData()
        {
            DepartmentCollection departmentCollection = DepartmentManager.GetDepartments(Globals.Settings.Store.DepartmentRoot);

            DepartmentCollection departments = new DepartmentCollection();

            foreach (Department item in departmentCollection)
            {
                departments.AddRange(DepartmentManager.GetDepartments(item.DepartmentID));
            }

            repDepartments.DataSource = departments;
            repDepartments.DataBind();
        }

        protected void repDepartments_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
                e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Department department = (Department) e.Item.DataItem;

                Repeater repSubDepartments = (Repeater) e.Item.FindControl("repSubDepartments");

                if (repSubDepartments != null && department != null)
                {
                    DepartmentCollection departmentCollection = DepartmentManager.GetDepartments(department.DepartmentID);

                    repSubDepartments.DataSource = departmentCollection;
                    //repSubDepartments.DataBind();
                }
            }


            //if (e.Item.ItemType == ListItemType.Item ||
            //    e.Item.ItemType == ListItemType.AlternatingItem)
            //{
            //    Department department = (Department)e.Item.DataItem;

            //    GridView gvwProducts = (GridView)e.Item.FindControl("gvwProducts");

            //    if (gvwProducts != null && department != null)
            //    {
            //        //Получаем коллекцию товаров раздела
            //        IEnumerable<Product> productCollection;

            //        ProductDepartmentMappingCollection productDepartmentCollection = ProductDepartmentMappingManager.GetProductDepartmentMappingByDepartmentID(department.DepartmentID, true);
            //        productCollection = productDepartmentCollection.Select(p => p.Product);

            //        //учитываем фильтрацию
            //        foreach (Filter item in ucFilter.Filters)
            //        {
            //            FilterCriteriaCollection fc = ucFilter.GetFilterCriteriaByFilterID(item.FilterID);

            //            if (fc != null)
            //            {
            //                if (fc.Count > 0)
            //                {
            //                    FilterCriteriaProductCollection fcps = new FilterCriteriaProductCollection();

            //                    foreach (FilterCriteria item2 in fc)
            //                    {
            //                        fcps.AddRange(FilterCriteriaProductManager.GetFilterCriteriaProductByFilterCriteriaID(item2.FilterCriteriaID));
            //                    }

            //                    productCollection = productCollection.Join(fcps, p => p.ProductID, o => o.ProductID, (p, o) => p);
            //                }
            //            }
            //        }

            //        //класс содержащий данные для вывода в таблицу
            //        List<ProductHelperClass> products = new List<ProductHelperClass>();

            //        //Класс который будет использоваться для динамического формирования таблицы
            //        ProductAttributeCollection productAttributeCollection = new ProductAttributeCollection();

            //        foreach (Product item in productCollection)
            //        {
            //            ProductHelperClass rp = new ProductHelperClass();

            //            rp.ProductID = item.ProductID;
            //            //rp.Title = item.Title;
            //            rp.Title = item.Model;
            //            rp.AverageRating = item.AverageRating;
            //            rp.SKU = item.SKU;
            //            rp.UnitPrice = CurrencyManager.ConvertCurrency(item.Price, item.Currency, CurrencyManager.WorkingCurrency);
            //            rp.DiscountPercentage = item.DiscountPercentage;
            //            rp.FinalPrice = CurrencyManager.ConvertCurrency(item.FinalPrice, item.Currency, CurrencyManager.WorkingCurrency);
            //            rp.UnitsInStock = item.UnitsInStock;

            //            ProductAttributeMappingCollection productAttributesMapping = null;

            //            productAttributesMapping = ProductAttributeMappingManager.GetProductAttributeMappingByProductIDInShort(item.ProductID);

            //            //цикл по характеристикам для заполнения класса rp
            //            foreach (ProductAttributeMapping item2 in productAttributesMapping)
            //            {
            //                // ищем характеристику в общем списке
            //                bool compare = false;
            //                for (int i = 0; i < productAttributeCollection.Count; i++)
            //                {
            //                    if (productAttributeCollection[i] == item2.ProductAttribute)
            //                    {
            //                        //если нашли то берем номер и указываем в классе rp свойству с таким номером значение
            //                        compare = true;
            //                        switch (i)
            //                        {
            //                            case 0:
            //                                rp.Attr1 = item2.AttributeValue;
            //                                break;
            //                            case 1:
            //                                rp.Attr2 = item2.AttributeValue;
            //                                break;
            //                            case 2:
            //                                rp.Attr3 = item2.AttributeValue;
            //                                break;
            //                            case 3:
            //                                rp.Attr4 = item2.AttributeValue;
            //                                break;
            //                            case 4:
            //                                rp.Attr5 = item2.AttributeValue;
            //                                break;
            //                            case 5:
            //                                rp.Attr6 = item2.AttributeValue;
            //                                break;
            //                            case 6:
            //                                rp.Attr7 = item2.AttributeValue;
            //                                break;
            //                            case 7:
            //                                rp.Attr8 = item2.AttributeValue;
            //                                break;
            //                            case 8:
            //                                rp.Attr9 = item2.AttributeValue;
            //                                break;
            //                        }
            //                        break;
            //                    }
            //                }
            //                //если не нашли добавляем в общий список и указываем соответствующему свойству значение
            //                if (!compare)
            //                {
            //                    productAttributeCollection.Add(item2.ProductAttribute);
            //                    switch (productAttributeCollection.Count - 1)
            //                    {
            //                        case 0:
            //                            rp.Attr1 = item2.AttributeValue;
            //                            break;
            //                        case 1:
            //                            rp.Attr2 = item2.AttributeValue;
            //                            break;
            //                        case 2:
            //                            rp.Attr3 = item2.AttributeValue;
            //                            break;
            //                        case 3:
            //                            rp.Attr4 = item2.AttributeValue;
            //                            break;
            //                        case 4:
            //                            rp.Attr5 = item2.AttributeValue;
            //                            break;
            //                        case 5:
            //                            rp.Attr6 = item2.AttributeValue;
            //                            break;
            //                        case 6:
            //                            rp.Attr7 = item2.AttributeValue;
            //                            break;
            //                        case 7:
            //                            rp.Attr8 = item2.AttributeValue;
            //                            break;
            //                        case 8:
            //                            rp.Attr9 = item2.AttributeValue;
            //                            break;
            //                    }
            //                }
            //            }

            //            products.Add(rp);
            //        }

            //        //формируем столбцы дополнительно
            //        for (int i = 0; i < productAttributeCollection.Count; i++)
            //        {
            //            gvwProducts.Columns[i + 2].HeaderText = productAttributeCollection[i].Name;
            //            gvwProducts.Columns[i + 2].Visible = true;
            //        }

            //        gvwProducts.DataSource = products;
            //    }
            //}
        }
}
}