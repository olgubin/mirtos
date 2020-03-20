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
using UC.BLL.Images;

namespace UC.UI.Admin
{
    public partial class ManageManufacturers : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UpdateTree(object sender)
        {
            gvwManufacturers.SelectedIndex = -1;
            gvwManufacturers.DataBind();
            ManufacturerFiltersControl.ManufacturerID = 0;
            ManufacturerLongDescriptionControl.ManufacturerID = 0;
        }

        protected void gvwManufacturers_SelectedIndexChanged(object sender, EventArgs e)
        {
            ManufacturerFiltersControl.ManufacturerID = Int32.Parse(gvwManufacturers.SelectedDataKey.Value.ToString());
            ManufacturerLongDescriptionControl.ManufacturerID = Int32.Parse(gvwManufacturers.SelectedDataKey.Value.ToString());
            ManufacturerDescription.ChangeMode(DetailsViewMode.Edit);
        }

        protected void gvwManufacturers_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.DataItem != null)
                {
                    ImageButton btn_visible = e.Row.Cells[0].Controls[0] as ImageButton;

                    if ((bool)DataBinder.Eval(e.Row.DataItem, "Published"))
                    {
                        btn_visible.ImageUrl = "~/Images/vis.gif";
                        btn_visible.ToolTip = "Видимый раздел";
                    }
                    else
                    {
                        btn_visible.ImageUrl = "~/Images/unvis.gif";
                        btn_visible.ToolTip = "Невидимый раздел";
                    }
                }
            }
        }


        protected void gvwManufacturers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Visible")
            {
                int manufacturerID = Convert.ToInt32(gvwManufacturers.DataKeys[Convert.ToInt32(e.CommandArgument)][0]);

                UC.BLL.Store.Manufacturer manufacturer = UC.BLL.Store.ManufacturerManager.GetManufacturerByID(manufacturerID);

                UC.BLL.Store.ManufacturerManager.VisibleManufacturer(manufacturerID, !manufacturer.Published);

                gvwManufacturers.DataBind();
            }
        }

    }
}