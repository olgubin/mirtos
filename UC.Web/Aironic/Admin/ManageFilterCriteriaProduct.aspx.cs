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
using UC.BLL.Store;
using UC.UI.Admin.Controls;

namespace UC.UI.Admin
{
    public partial class ManageFilterCriteriaProduct : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (gvwFilters.Rows.Count > 0)
                    gvwFilters.SelectedIndex = 0;

                ddlDepartments.BindData();
            }
        }

        protected void gvwFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindFilterCriteria(0);
            BindProducts();
        }

        protected void gvwFilterCriteria_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindProducts();
        }

        protected void cbSelectAll_Click(object sender, EventArgs e)
        {
            CheckBox cbSelectAll = gvProducts.HeaderRow.FindControl("cbSelectAll") as CheckBox;

            if (cbSelectAll != null)
            {
                foreach (GridViewRow row in gvProducts.Rows)
                {
                    CheckBox cbProductInfo = row.FindControl("cbProductInfo") as CheckBox;

                    if (cbProductInfo != null)
                        cbProductInfo.Checked = cbSelectAll.Checked;
                }
            }
        }

        protected void gvProducts_DataBound(Object sender, EventArgs e)
        {
            if (gvProducts.HeaderRow != null)
            {
                Label lblAllProduct = gvProducts.HeaderRow.FindControl("lblAllProduct") as Label;

                if (lblAllProduct != null)
                {
                    lblAllProduct.Text = String.Format("Всего товаров: {0}", gvProducts.Rows.Count.ToString());
                }
            }
        }

        /// <summary>
        /// Обновление критериев фильтрации
        /// </summary>
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int FilterCriteriaID = 0;

                if (gvwFilterCriteria.SelectedValue != null)
                {
                    FilterCriteriaID = (int)gvwFilterCriteria.SelectedValue;

                    foreach (GridViewRow row in gvProducts.Rows)
                    {
                        CheckBox cbProductInfo = row.FindControl("cbProductInfo") as CheckBox;
                        HiddenField hfProductID = row.FindControl("hfProductID") as HiddenField;
                        HiddenField hfFilterCriteriaProductID = row.FindControl("hfFilterCriteriaProductID") as HiddenField;

                        int filterCriteriaProductID = int.Parse(hfFilterCriteriaProductID.Value);
                        int productID = int.Parse(hfProductID.Value);

                        if (filterCriteriaProductID > 0 && !cbProductInfo.Checked)
                            FilterCriteriaProductManager.DeleteFilterCriteriaProduct(filterCriteriaProductID);
                        if (filterCriteriaProductID > 0 && cbProductInfo.Checked)
                            FilterCriteriaProductManager.UpdateFilterCriteriaProduct(filterCriteriaProductID, productID, FilterCriteriaID);
                        if (filterCriteriaProductID == 0 && cbProductInfo.Checked)
                            FilterCriteriaProductManager.InsertFilterCriteriaProduct(productID, FilterCriteriaID);
                    }

                    lblFeedBack.Text = "Сохранение проведено успешно";

                    BindFilters(gvwFilters.SelectedIndex);
                    BindFilterCriteria(gvwFilterCriteria.SelectedIndex);
                    BindProducts();
                }
                else
                {
                    lblFeedBack.Text = "Не задан критерий фильтрации";
                }
            }
            catch
            {
                lblFeedBack.Text = "Ошибка при сохранении";
            }
        }

        protected void ddlDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindFilters(0);
            BindFilterCriteria(0);
            BindProducts();
        }

        private class ProductHelperClass
        {
            public int FilterCriteriaProductID { get; set; }
            public int FilterCriteriaID { get; set; }
            public int ProductID { get; set; }
            public string ProductInfo { get; set; }
            public string Criterion { get; set; }
            public bool IsMapped { get; set; }
        }

        protected void BindProducts()
        {
            if (ddlDepartments.SelectedDepartmentId > 0)
            {
                ProductDepartmentMappingCollection productDepartments = ProductDepartmentMappingManager.GetProductDepartmentMappingByDepartmentID(ddlDepartments.SelectedDepartmentId, false);

                int FilterCriteriaID = 0;

                if (gvwFilterCriteria.SelectedValue != null)
                    FilterCriteriaID = (int)gvwFilterCriteria.SelectedValue;

                FilterCriteriaProductCollection filterCriteriaProducts = FilterCriteriaProductManager.GetFilterCriteriaProductByFilterCriteriaID(FilterCriteriaID);

                List<ProductHelperClass> products = new List<ProductHelperClass>();

                for (int i = 0; i < productDepartments.Count; i++)
                {
                    FilterCriteriaProduct existinFilterCriteriaProduct = filterCriteriaProducts.FindFilterCriteriaProduct(FilterCriteriaID, productDepartments[i].ProductID);

                    ProductHelperClass rp = new ProductHelperClass();

                    if (existinFilterCriteriaProduct != null)
                    {
                        rp.FilterCriteriaProductID = existinFilterCriteriaProduct.FilterCriteriaProductID;
                        rp.FilterCriteriaID = existinFilterCriteriaProduct.FilterCriteriaID;
                        rp.ProductID = productDepartments[i].ProductID;
                        rp.ProductInfo = productDepartments[i].Product.Title;
                        rp.IsMapped = true;
                    }
                    else
                    {
                        rp.ProductID = productDepartments[i].ProductID;
                        rp.ProductInfo = productDepartments[i].Product.Title;
                        rp.IsMapped = false;
                    }

                    FilterCriteriaProductCollection fcps = FilterCriteriaProductManager.GetFilterCriteriaProductByProductID(productDepartments[i].ProductID);
                    foreach (FilterCriteriaProduct fcp in fcps)
                    {
                        if (fcp.FilterCriteria.FilterID == (int)gvwFilters.SelectedDataKey.Value)
                            rp.Criterion += fcp.FilterCriteria.Criterion + "<br/>";
                    }
 
                    products.Add(rp);
                }

                IEnumerable<ProductHelperClass> productCollection;

                productCollection = products.OrderBy(p => p.ProductInfo);

                gvProducts.DataSource = productCollection;
                gvProducts.DataBind();
            }
        }

        private class FilterHelperClass
        {
            public int FilterID { get; set; }
            public string Name { get; set; }
            public int Count { get; set; }
        }

        protected void BindFilters(int selectedIndex)
        {
            if (ddlDepartments.SelectedDepartmentId > 0)
            {
                DepartmentCollection departmens = DepartmentManager.GetBreadCrumb(ddlDepartments.SelectedDepartmentId);

                FilterDepartmentCollection filterDepartments = new FilterDepartmentCollection();

                foreach (Department dept in departmens)
                {
                    FilterDepartmentCollection filDepts = FilterDepartmentManager.GetFilterDepartmentByDepartmentID(dept.DepartmentID);

                    foreach (FilterDepartment item2 in filDepts)
                    {
                        if (filterDepartments.FindFilterDepartment(item2.FilterID, item2.DepartmentID) == null)
                        {
                            filterDepartments.Add(item2);
                        }
                    }
                }

                //Создаем вспомогательный класс для отображения
                List<FilterHelperClass> filters = new List<FilterHelperClass>();

                foreach (FilterDepartment item in filterDepartments)
                {
                    bool exist = false; 

                    foreach (FilterHelperClass item2 in filters)
                    {
                        if (item2.FilterID == item.FilterID)
                            exist = true;
                    }

                    if (!exist)
                    {
                        FilterHelperClass filter = new FilterHelperClass();

                        filter.FilterID = item.FilterID;
                        filter.Name = item.Filter.Name;
                        filter.Count = 0;

                        filters.Add(filter);
                    }
                }

                //Подсчитываем сколько товаров в фильтре для выбранного раздела
                ProductDepartmentMappingCollection products = ProductDepartmentMappingManager.GetProductDepartmentMappingByDepartmentID(ddlDepartments.SelectedDepartmentId, false);

                foreach (ProductDepartmentMapping product in products)
                {
                    FilterCriteriaProductCollection fcps = FilterCriteriaProductManager.GetFilterCriteriaProductByProductID(product.ProductID);

                    foreach (FilterCriteriaProduct fcp in fcps)
                    {
                        foreach (FilterHelperClass f in filters)
                        {
                            if (f.FilterID == fcp.FilterCriteria.FilterID)
                                f.Count++;
                        }
                    }
                }

                foreach (FilterHelperClass f in filters)
                {
                    if (f.Count > 0)
                        f.Name += String.Format(" ({0})", f.Count);
                }

                gvwFilters.DataSource = filters;
                gvwFilters.SelectedIndex = selectedIndex;
                gvwFilters.DataBind();
            }
        }

        private class FilterCriteriaHelperClass
        {
            public int FilterCriteriaID { get; set; }
            public int FilterID { get; set; }
            public string Criterion { get; set; }
            public int Count { get; set; }
        }

        protected void BindFilterCriteria(int selectedIndex)
        {
            if (gvwFilters.SelectedDataKey != null)
            {
                if ((int)gvwFilters.SelectedDataKey.Value > 0)
                {
                    FilterCriteriaCollection fcs = FilterCriteriaManager.GetFilterCriteriaByFilterID((int)gvwFilters.SelectedDataKey.Value);

                    //Создаем вспомогательный класс для отображения
                    List<FilterCriteriaHelperClass> criterions = new List<FilterCriteriaHelperClass>();

                    foreach (FilterCriteria item in fcs)
                    {
                        FilterCriteriaHelperClass criterion = new FilterCriteriaHelperClass();

                        criterion.FilterCriteriaID = item.FilterCriteriaID;
                        criterion.FilterID = item.FilterID;
                        criterion.Criterion = item.Criterion;
                        criterion.Count = 0;

                        criterions.Add(criterion);
                    }

                    //Подсчитываем сколько товаров в критерии фильтрации выбранного фильтра и раздела
                    ProductDepartmentMappingCollection products = ProductDepartmentMappingManager.GetProductDepartmentMappingByDepartmentID(ddlDepartments.SelectedDepartmentId, false);

                    foreach (ProductDepartmentMapping product in products)
                    {
                        FilterCriteriaProductCollection fcps = FilterCriteriaProductManager.GetFilterCriteriaProductByProductID(product.ProductID);

                        foreach (FilterCriteriaProduct fcp in fcps)
                        {
                            foreach (FilterCriteriaHelperClass item in criterions)
                            {
                                if (item.FilterCriteriaID == fcp.FilterCriteriaID)
                                    item.Count++;
                            }
                        }
                    }

                    foreach (FilterCriteriaHelperClass item in criterions)
                    {
                        if (item.Count > 0)
                            item.Criterion += String.Format(" ({0})", item.Count);
                    }

                    gvwFilterCriteria.DataSource = criterions;
                    gvwFilterCriteria.SelectedIndex = selectedIndex;
                    gvwFilterCriteria.DataBind();
                }
            }
        }
    }
}
