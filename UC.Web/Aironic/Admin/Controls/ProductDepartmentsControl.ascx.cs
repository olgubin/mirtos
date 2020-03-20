using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using UC.BLL.Store;

namespace UC.UI.Admin.Controls
{
    public partial class ProductDepartmentsControl : System.Web.UI.UserControl
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
                if (ProductID > 0)
                {
                    //Заполнение списка разделов
                    ddlDepartments.BindData();

                    //Заполнение таблицы разделов
                    BindProductDepartmentMapping();
                }
            }
        }

        /// <summary>
        /// Привязка списка характеристик к таблице характеристик товара
        /// </summary>
        private void BindProductDepartmentMapping()
        {
            ProductDepartmentMappingCollection productDepartmentMapping = ProductDepartmentMappingManager.GetProductDepartmentMappingByProductID(this.ProductID);

            if (productDepartmentMapping.Count > 0)
            {
                gvProductDepartmentMapping.Visible = true;
                gvProductDepartmentMapping.DataSource = productDepartmentMapping;
                gvProductDepartmentMapping.DataBind();
            }
            else
                gvProductDepartmentMapping.Visible = false;
        }

        /// <summary>
        /// Добавление раздела к товару
        /// </summary>
        protected void btnNewProductDepartment_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlDepartments.SelectedDepartmentId > 0)
                {

                    Product product = ProductManager.GetByProductID(this.ProductID);

                    ProductDepartmentMappingCollection productDepartments = product.ProductDepartments;

                    if (productDepartments.FindProductDepartment(this.ProductID, ddlDepartments.SelectedDepartmentId) == null)
                    {
                        if (product != null)
                        {
                            int DepartmentID = ddlDepartments.SelectedDepartmentId;

                            ProductDepartmentMappingManager.InsertProductDepartmentMapping(this.ProductID,
                                DepartmentID, txtNewProductDepartmentMappingDisplayOrder.Value);

                            lblNewProductDepartment.Text = "Сохранение успешно проведено";

                            BindProductDepartmentMapping();
                        }
                    }
                    else
                    {
                        lblNewProductDepartment.Text = "Раздел уже существует";
                    }
                }
                else
                {
                    lblNewProductDepartment.Text = "Не задан раздел";
                }
            }
            catch (Exception exc)
            {
                lblNewProductDepartment.Text = "Ошибка при сохранении";
            }
        }

        /// <summary>
        /// Удаление товара из раздела
        /// </summary>
        protected void gvProductDepartmentMapping_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int productDepartmentMappingID = (int)gvProductDepartmentMapping.DataKeys[e.RowIndex]["ProductDepartmentID"];

            ProductDepartmentMappingManager.DeleteProductDepartment(productDepartmentMappingID);

            BindProductDepartmentMapping();
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
                    foreach (GridViewRow row in gvProductDepartmentMapping.Rows)
                    {
                        HiddenField hfProductDepartmentMappingID = row.FindControl("hfProductDepartmentMappingID") as HiddenField;
                        NumericTextBox txtProductDepartmentMappingDisplayOrder = row.FindControl("txtProductDepartmentMappingDisplayOrder") as NumericTextBox;

                        int productDepartmentMappingID = int.Parse(hfProductDepartmentMappingID.Value);
                        int displayOrder = txtProductDepartmentMappingDisplayOrder.Value;

                        ProductDepartmentMapping productDepartmentMapping = ProductDepartmentMappingManager.GetByProductDepartmentMappingID(productDepartmentMappingID);

                        if (productDepartmentMapping != null)
                            ProductDepartmentMappingManager.UpdateProductDepartmentMapping(productDepartmentMapping.ProductDepartmentID,
                               productDepartmentMapping.ProductID, productDepartmentMapping.DepartmentID, displayOrder);
                    }

                    lblAttribute.Text = "Сохранение проведено успешно";

                    BindProductDepartmentMapping();
                }
                catch
                {
                    lblAttribute.Text = "Ошибка пр сохранении";
                }
            }
        }

        protected void gvProductDepartmentMapping_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ProductDepartmentMapping productDepartmentMapping = e.Row.DataItem as ProductDepartmentMapping;

                Label lbl = e.Row.FindControl("lblProductDepartment") as Label;

                if (lbl != null)
                {
                    DepartmentCollection departments = DepartmentManager.GetBreadCrumb(productDepartmentMapping.DepartmentID);

                    string dept = "";

                    foreach(Department item in departments)
                    {
                        dept += "\\" + item.Name;
                    }

                    dept = dept.Remove(0, 1);

                    lbl.Text = dept;
                }
            }
        }
    }
}
