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
    public partial class DepartmentFiltersControl : System.Web.UI.UserControl
    {
        private int _departmentID;
        public int DepartmentID
        {
            get 
            {
                if (!String.IsNullOrEmpty(hfDepartmentID.Value))
                {
                    _departmentID = Int32.Parse(hfDepartmentID.Value);
                }
                else
                    _departmentID = 0;
 
                return _departmentID; 
            }
            set 
            { 
                _departmentID = value;

                hfDepartmentID.Value = _departmentID.ToString();

                //Заполнение списка разделов
                ddlFilters.BindData();

                //Заполнение таблицы разделов
                BindFilterDepartmentMapping();
            }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //if (DepartmentID > 0)
                //{
                //    //Заполнение списка разделов
                //    ddlFilters.BindData();

                //    //Заполнение таблицы разделов
                //    BindFilterDepartmentMapping();
                //}
            }
        }

        /// <summary>
        /// Привязка списка характеристик к таблице характеристик товара
        /// </summary>
        private void BindFilterDepartmentMapping()
        {
            FilterDepartmentCollection filterDepartment = FilterDepartmentManager.GetFilterDepartmentByDepartmentID(DepartmentID);

            if (filterDepartment.Count > 0)
            {
                gvFilterDepartment.Visible = true;
                gvFilterDepartment.DataSource = filterDepartment;
                gvFilterDepartment.DataBind();
            }
            else
                gvFilterDepartment.Visible = false;
        }

        /// <summary>
        /// Добавление раздела к товару
        /// </summary>
        protected void btnNewFilterDepartment_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlFilters.SelectedFilterId > 0)
                {
                    FilterDepartmentCollection filterDepartmentCollection = FilterDepartmentManager.GetFilterDepartmentByDepartmentID(DepartmentID);

                    if (filterDepartmentCollection.FindFilterDepartment(ddlFilters.SelectedFilterId, DepartmentID) == null)
                    {
                        int FilterID = ddlFilters.SelectedFilterId;

                        FilterDepartmentManager.InsertFilterDepartment(DepartmentID,
                            FilterID, txtNewDisplayOrder.Value);

                        lblNewFilterDepartment.Text = "Сохранение успешно проведено";

                        BindFilterDepartmentMapping();
                    }
                    else
                    {
                        lblNewFilterDepartment.Text = "Раздел уже существует";
                    }
                }
                else
                {
                    lblNewFilterDepartment.Text = "Не задан раздел";
                }
            }
            catch (Exception exc)
            {
                lblNewFilterDepartment.Text = "Ошибка при сохранении";
            }
        }

        /// <summary>
        /// Удаление товара из раздела
        /// </summary>
        protected void gvFilterDepartment_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int filterDepartmentID = (int)gvFilterDepartment.DataKeys[e.RowIndex]["FilterDepartmentID"];

            FilterDepartmentManager.DeleteFilterDepartment(filterDepartmentID);

            BindFilterDepartmentMapping();
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
                    foreach (GridViewRow row in gvFilterDepartment.Rows)
                    {
                        HiddenField hfFilterDepartmentID = row.FindControl("hfFilterDepartmentID") as HiddenField;
                        NumericTextBox txtDisplayOrder = row.FindControl("txtDisplayOrder") as NumericTextBox;

                        int filterDepartmentID = int.Parse(hfFilterDepartmentID.Value);
                        int displayOrder = txtDisplayOrder.Value;

                        FilterDepartment filterDepartment = FilterDepartmentManager.GetByFilterDepartmentID(filterDepartmentID);

                        if (filterDepartment != null)
                            FilterDepartmentManager.UpdateFilterDepartment(filterDepartment.FilterDepartmentID,
                               filterDepartment.DepartmentID, filterDepartment.FilterID, displayOrder);
                    }

                    lblAttribute.Text = "Сохранение проведено успешно";

                    BindFilterDepartmentMapping();
                }
                catch
                {
                    lblAttribute.Text = "Ошибка пр сохранении";
                }
            }
        }
    }
}
