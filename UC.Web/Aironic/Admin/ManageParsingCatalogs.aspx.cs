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

namespace UC.UI.Admin
{
    public partial class ManageParsingCatalogs : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gvwCatalogs_SelectedIndexChanged(object sender, EventArgs e)
        {
            dvwCatalog.ChangeMode(DetailsViewMode.Edit);
        }

        protected void gvwCatalogs_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            gvwCatalogs.SelectedIndex = -1;
            gvwCatalogs.DataBind();
            dvwCatalog.ChangeMode(DetailsViewMode.Insert);
        }

        protected void gvwCatalogs_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton btn = e.Row.Cells[2].Controls[0] as ImageButton;
                btn.OnClientClick = "if (confirm('Подтвердите удаление каталога!') == false) return false;";
            }
        }

        protected void dvwCatalog_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            gvwCatalogs.SelectedIndex = -1;
            gvwCatalogs.DataBind();
        }

        protected void dvwCatalog_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            gvwCatalogs.SelectedIndex = -1;
            gvwCatalogs.DataBind();
        }

        protected void dvwCatalog_ItemCommand(object sender, DetailsViewCommandEventArgs e)
        {
            if (e.CommandName == "Cancel")
            {
                gvwCatalogs.SelectedIndex = -1;
                gvwCatalogs.DataBind();
            }
        }
    }
}