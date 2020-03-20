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
    public partial class ManageProductAttributes : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gvwProductAttributes_SelectedIndexChanged(object sender, EventArgs e)
        {
            dvwProductAttribute.ChangeMode(DetailsViewMode.Edit);
        }

        protected void gvwProductAttributes_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            gvwProductAttributes.SelectedIndex = -1;
            gvwProductAttributes.DataBind();
            dvwProductAttribute.ChangeMode(DetailsViewMode.Insert);
        }

        protected void gvwProductAttributes_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton btn = e.Row.Cells[2].Controls[0] as ImageButton;
                btn.OnClientClick = "if (confirm('Подтвердите удаление') == false) return false;";
            }
        }

        protected void dvwProductAttribute_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            gvwProductAttributes.SelectedIndex = -1;
            gvwProductAttributes.DataBind();
        }

        protected void dvwProductAttribute_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            gvwProductAttributes.SelectedIndex = -1;
            gvwProductAttributes.DataBind();
        }

        protected void dvwProductAttribute_ItemCommand(object sender, DetailsViewCommandEventArgs e)
        {
            if (e.CommandName == "Cancel")
            {
                gvwProductAttributes.SelectedIndex = -1;
                gvwProductAttributes.DataBind();
            }
        }
    }
}