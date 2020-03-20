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
    public partial class ManageDepartmentTemplates : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gvwDepartmentTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            dvwDepartmentTemplate.ChangeMode(DetailsViewMode.Edit);
        }

        protected void gvwDepartmentTemplate_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            gvwDepartmentTemplate.SelectedIndex = -1;
            gvwDepartmentTemplate.DataBind();
            dvwDepartmentTemplate.ChangeMode(DetailsViewMode.Insert);
        }

        protected void gvwDepartmentTemplate_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton btn = e.Row.Cells[4].Controls[0] as ImageButton;
                btn.OnClientClick = "if (confirm('Подтвердите удаление') == false) return false;";
            }
        }

        protected void dvwDepartmentTemplate_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            gvwDepartmentTemplate.SelectedIndex = -1;
            gvwDepartmentTemplate.DataBind();
        }

        protected void dvwDepartmentTemplate_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            gvwDepartmentTemplate.SelectedIndex = -1;
            gvwDepartmentTemplate.DataBind();
        }

        protected void dvwDepartmentTemplate_ItemCommand(object sender, DetailsViewCommandEventArgs e)
        {
            if (e.CommandName == "Cancel")
            {
                gvwDepartmentTemplate.SelectedIndex = -1;
                gvwDepartmentTemplate.DataBind();
            }
        }
    }
}
