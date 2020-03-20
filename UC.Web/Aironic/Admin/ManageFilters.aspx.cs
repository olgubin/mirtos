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
using UC.BLL.Store;
using UC.UI.Admin.Controls;

namespace UC.UI.Admin
{
    public partial class ManageFilters : BasePage
    {
        private void DeselectFilter()
        {
            gvwFilters.SelectedIndex = -1;
            gvwFilters.DataBind();
            dvwFilter.ChangeMode(DetailsViewMode.Insert);
            panFilterCriteria.Visible = false;
        }

        private void DeselectFilterCriteria()
        {
            gvwFilterCriteria.SelectedIndex = -1;
            gvwFilterCriteria.DataBind();
            dvwFilterCriteria.ChangeMode(DetailsViewMode.Insert);
        }

        protected void gvwFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            dvwFilter.ChangeMode(DetailsViewMode.Edit);
            panFilterCriteria.Visible = true;
        }

        protected void gvwFilters_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            DeselectFilter();
        }

        protected void gvwFilters_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton btnDelete = e.Row.Cells[3].Controls[0] as ImageButton;
                btnDelete.OnClientClick = "if (confirm('Подтвердите удаление фильтра') == false) return false;";
            }
        }

        protected void dvwFilter_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            DeselectFilter();
        }

        protected void dvwFilter_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            DeselectFilter();
        }

        protected void dvwFilter_ItemCommand(object sender, DetailsViewCommandEventArgs e)
        {
            if (e.CommandName == "Cancel")
                DeselectFilter();
        }

        protected void dvwFilterCriteria_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            DeselectFilterCriteria();
        }

        protected void dvwFilterCriteria_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            DeselectFilterCriteria();
        }

        protected void dvwFilterCriteria_ItemCommand(object sender, DetailsViewCommandEventArgs e)
        {
            if (e.CommandName == "Cancel")
                DeselectFilterCriteria();
        }

        protected void gvwFilterCriteria_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton btn = e.Row.Cells[3].Controls[0] as ImageButton;
                btn.OnClientClick = "if (confirm('Подтвердите удаление критерия фильтрации') == false) return false;";
            }
        }

        protected void gvwFilterCriteria_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            DeselectFilterCriteria();
        }

        protected void gvwFilterCriteria_SelectedIndexChanged(object sender, EventArgs e)
        {
            dvwFilterCriteria.ChangeMode(DetailsViewMode.Edit);
        }

        /// <summary>
        /// Обновление критериев фильтрации
        /// </summary>
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    foreach (GridViewRow row in gvwFilterCriteria.Rows)
                    {
                        HiddenField hfFilterCriteriaID = row.FindControl("hfFilterCriteriaID") as HiddenField;
                        NumericTextBox txtFilterCriteriaDisplayOrder = row.FindControl("txtFilterCriteriaDisplayOrder") as NumericTextBox;

                        int filterCriteriaID = int.Parse(hfFilterCriteriaID.Value);
                        int displayOrder = txtFilterCriteriaDisplayOrder.Value;

                        FilterCriteria filterCriteria = FilterCriteriaManager.GetByFilterCriteriaID(filterCriteriaID);

                        if (filterCriteria != null)
                            FilterCriteriaManager.UpdateFilterCriteria(filterCriteria.FilterCriteriaID,
                               filterCriteria.FilterID, filterCriteria.Criterion, displayOrder);
                    }

                    lblAttribute.Text = "Сохранение проведено успешно";

                    gvwFilterCriteria.DataBind();
                }
                catch
                {
                    lblAttribute.Text = "Ошибка пр сохранении";
                }
            }
        }
    }
}
