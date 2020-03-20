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
using UC.BLL.Gallery;
using UC.BLL.Images;

namespace UC.UI.Admin
{
    public partial class ManagePortfolio : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gvwPortfolio_SelectedIndexChanged(object sender, EventArgs e)
        {
            dvwPortfolio.ChangeMode(DetailsViewMode.Edit);
        }

        protected void gvwPortfolio_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            gvwPortfolio.SelectedIndex = -1;
            gvwPortfolio.DataBind();
            dvwPortfolio.ChangeMode(DetailsViewMode.Insert);
        }

        protected void gvwPortfolio_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton btn = e.Row.Cells[4].Controls[0] as ImageButton;
                btn.OnClientClick = "if (confirm('Подтвердите удаление') == false) return false;";
            }
        }

        protected void dvwPortfolio_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            gvwPortfolio.SelectedIndex = -1;
            gvwPortfolio.DataBind();
        }

        protected void dvwPortfolio_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
          gvwPortfolio.SelectedIndex = -1;
          gvwPortfolio.DataBind();
        }

        protected void dvwPortfolio_ItemCommand(object sender, DetailsViewCommandEventArgs e)
        {
            if (e.CommandName == "Cancel")
            {
                gvwPortfolio.SelectedIndex = -1;
                gvwPortfolio.DataBind();
            }
        }
    }
}