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
    public partial class ProductFilterCriteriaControl : System.Web.UI.UserControl
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
                    ddlFilterCriteria.BindData();

                    //Заполнение таблицы разделов
                    BindFilterCriteriaProduct();
                }
            }
        }

        /// <summary>
        /// Привязка списка характеристик к таблице характеристик товара
        /// </summary>
        private void BindFilterCriteriaProduct()
        {
            FilterCriteriaProductCollection filterCriteriaProduct = FilterCriteriaProductManager.GetFilterCriteriaProductByProductID(this.ProductID);

            if (filterCriteriaProduct.Count > 0)
            {
                gvFilterCriteriaProduct.Visible = true;
                gvFilterCriteriaProduct.DataSource = filterCriteriaProduct;
                gvFilterCriteriaProduct.DataBind();
            }
            else
                gvFilterCriteriaProduct.Visible = false;
        }

        /// <summary>
        /// Добавление раздела к товару
        /// </summary>
        protected void btnNewFilterCriteriaProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlFilterCriteria.SelectedFilterCriteriaId > 0)
                {
                    Product product = ProductManager.GetByProductID(this.ProductID);

                    FilterCriteriaProductCollection filterCriteriaProductCollection = FilterCriteriaProductManager.GetFilterCriteriaProductByProductID(this.ProductID);

                    if (filterCriteriaProductCollection.FindFilterCriteriaProduct(ddlFilterCriteria.SelectedFilterCriteriaId, this.ProductID) == null)
                    {
                        if (product != null)
                        {
                            int FilterCriteriaID = ddlFilterCriteria.SelectedFilterCriteriaId;

                            FilterCriteriaProductManager.InsertFilterCriteriaProduct(this.ProductID,
                                FilterCriteriaID);

                            lblNewFilterCriteriaProduct.Text = "Сохранение успешно проведено";

                            BindFilterCriteriaProduct();
                        }
                    }
                    else
                    {
                        lblNewFilterCriteriaProduct.Text = "Раздел уже существует";
                    }
                }
                else
                {
                    lblNewFilterCriteriaProduct.Text = "Не задан раздел";
                }
            }
            catch (Exception exc)
            {
                lblNewFilterCriteriaProduct.Text = "Ошибка при сохранении";
            }
        }

        /// <summary>
        /// Удаление товара из раздела
        /// </summary>
        protected void gvFilterCriteriaProduct_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int filterCriteriaProductID = (int)gvFilterCriteriaProduct.DataKeys[e.RowIndex]["FilterCriteriaProductID"];

            FilterCriteriaProductManager.DeleteFilterCriteriaProduct(filterCriteriaProductID);

            BindFilterCriteriaProduct();
        }

        protected void gvFilterCriteriaProduct_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                FilterCriteriaProduct filterCriteriaProduct = e.Row.DataItem as FilterCriteriaProduct;

                Label lbl = e.Row.FindControl("lblFilterCriteriaProduct") as Label;

                if (lbl != null)
                {
                    lbl.Text = filterCriteriaProduct.FilterCriteria.Filter.Name + "\\" + filterCriteriaProduct.FilterCriteria.Criterion;
                }
            }
        }
    }
}
