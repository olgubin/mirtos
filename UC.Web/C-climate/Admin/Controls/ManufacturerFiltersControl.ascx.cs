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
    public partial class ManufacturerFiltersControl : System.Web.UI.UserControl
    {
        private int _manufacturerID;
        public int ManufacturerID
        {
            get 
            {
                if (!String.IsNullOrEmpty(hfManufacturerID.Value))
                {
                    _manufacturerID = Int32.Parse(hfManufacturerID.Value);
                }
                else
                    _manufacturerID = 0;

                return _manufacturerID; 
            }
            set 
            {
                _manufacturerID = value;

                hfManufacturerID.Value = _manufacturerID.ToString();

                //Заполнение списка разделов
                ddlFilters.BindData();

                //Заполнение таблицы разделов
                BindFilterManufacturerMapping();
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
        private void BindFilterManufacturerMapping()
        {
            FilterManufacturerCollection filterManufacturer = FilterManufacturerManager.GetFilterManufacturerByManufacturerID(ManufacturerID);

            if (filterManufacturer.Count > 0)
            {
                gvFilterManufacturer.Visible = true;
                gvFilterManufacturer.DataSource = filterManufacturer;
                gvFilterManufacturer.DataBind();
            }
            else
                gvFilterManufacturer.Visible = false;
        }

        /// <summary>
        /// Добавление раздела к товару
        /// </summary>
        protected void btnNewFilterManufacturer_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlFilters.SelectedFilterId > 0)
                {
                    FilterManufacturerCollection filterManufacturerCollection = FilterManufacturerManager.GetFilterManufacturerByManufacturerID(ManufacturerID);

                    if (filterManufacturerCollection.FindFilterManufacturer(ddlFilters.SelectedFilterId, ManufacturerID) == null)
                    {
                        int FilterID = ddlFilters.SelectedFilterId;

                        FilterManufacturerManager.InsertFilterManufacturer(ManufacturerID,
                            FilterID, txtNewDisplayOrder.Value);

                        lblNewFilterManufacturer.Text = "Сохранение успешно проведено";

                        BindFilterManufacturerMapping();
                    }
                    else
                    {
                        lblNewFilterManufacturer.Text = "Раздел уже существует";
                    }
                }
                else
                {
                    lblNewFilterManufacturer.Text = "Не задан раздел";
                }
            }
            catch (Exception exc)
            {
                lblNewFilterManufacturer.Text = "Ошибка при сохранении";
            }
        }

        /// <summary>
        /// Удаление товара из раздела
        /// </summary>
        protected void gvFilterManufacturer_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int filterManufacturerID = (int)gvFilterManufacturer.DataKeys[e.RowIndex]["FilterManufacturerID"];

            FilterManufacturerManager.DeleteFilterManufacturer(filterManufacturerID);

            BindFilterManufacturerMapping();
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
                    foreach (GridViewRow row in gvFilterManufacturer.Rows)
                    {
                        HiddenField hfFilterManufacturerID = row.FindControl("hfFilterManufacturerID") as HiddenField;
                        NumericTextBox txtDisplayOrder = row.FindControl("txtDisplayOrder") as NumericTextBox;

                        int filterManufacturerID = int.Parse(hfFilterManufacturerID.Value);
                        int displayOrder = txtDisplayOrder.Value;

                        FilterManufacturer filterManufacturer = FilterManufacturerManager.GetByFilterManufacturerID(filterManufacturerID);

                        if (filterManufacturer != null)
                            FilterManufacturerManager.UpdateFilterManufacturer(filterManufacturer.FilterManufacturerID,
                               filterManufacturer.ManufacturerID, filterManufacturer.FilterID, displayOrder);
                    }

                    lblAttribute.Text = "Сохранение проведено успешно";

                    BindFilterManufacturerMapping();
                }
                catch
                {
                    lblAttribute.Text = "Ошибка пр сохранении";
                }
            }
        }
    }
}
