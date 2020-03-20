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
using System.IO;
using UC;

namespace UC.UI.Admin
{
    public partial class ManageProductTypes : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gvwProductTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            dvwProductType.ChangeMode(DetailsViewMode.Edit);
        }

        protected void gvwProductTypes_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            gvwProductTypes.SelectedIndex = -1;
            gvwProductTypes.DataBind();
            dvwProductType.ChangeMode(DetailsViewMode.Insert);
        }

        protected void gvwProductTypes_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton btn = e.Row.Cells[2].Controls[0] as ImageButton;
                btn.OnClientClick = "if (confirm('Подтвердите удаление') == false) return false;";
            }
        }

        protected void dvwProductType_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            gvwProductTypes.SelectedIndex = -1;
            gvwProductTypes.DataBind();
        }

        protected void dvwProductType_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            gvwProductTypes.SelectedIndex = -1;
            gvwProductTypes.DataBind();
        }

        protected void dvwProductType_ItemCommand(object sender, DetailsViewCommandEventArgs e)
        {
            if (e.CommandName == "Cancel")
            {
                gvwProductTypes.SelectedIndex = -1;
                gvwProductTypes.DataBind();
            }
        }
    }
}