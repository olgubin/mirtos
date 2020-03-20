using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using FredCK.FCKeditorV2;
using UC.Core;
using UC.BLL.Store;

namespace UC.UI.Admin.Controls
{
    public partial class DepartmentDescriptionControl : System.Web.UI.UserControl
    {
        public delegate void ItemInsertedEventHandler(object sender);
        public event ItemInsertedEventHandler ItemInserted;

        public delegate void ItemUpdatedEventHandler(object sender);
        public event ItemUpdatedEventHandler ItemUpdated;

        public delegate void ItemDeletedEventHandler(object sender);
        public event ItemDeletedEventHandler ItemDeleted;

        public delegate void ItemCancelEventHandler(object sender);
        public event ItemCancelEventHandler ItemCancel;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dvwDepartment.ChangeMode(DetailsViewMode.Insert);
            }
        }

        protected void dvwDepartment_ItemCreated(object sender, EventArgs e)
        {
            SelectDepartmentControl parentDepartment = dvwDepartment.FindControl("ParentDepartment") as SelectDepartmentControl;
            if (parentDepartment != null)
                parentDepartment.BindData();

            SelectDepartmentTemplateControl ddlDepartmentTemplate = dvwDepartment.FindControl("ddlDepartmentTemplate") as SelectDepartmentTemplateControl;
            if (ddlDepartmentTemplate != null)
                ddlDepartmentTemplate.BindData();

            if (dvwDepartment.CurrentMode == DetailsViewMode.Insert)
            {
                TextBox txtDisplayOrder = dvwDepartment.FindControl("txtDisplayOrder") as TextBox;
                txtDisplayOrder.Text = "0";
            }
        }

        protected void dvwDepartment_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            if (ItemInserted != null)
            {
                ItemInserted(this);
            }
        }

        protected void dvwDepartment_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            if (ItemUpdated != null)
            {
                ItemUpdated(this);
            }
        }

        protected void dvwDepartment_ItemDeleted(object sender, DetailsViewDeletedEventArgs e)
        {
            dvwDepartment.ChangeMode(DetailsViewMode.Insert);

            if (ItemDeleted != null)
            {
                ItemDeleted(this);
            }
        }

        protected void dvwDepartment_ItemCommand(object sender, DetailsViewCommandEventArgs e)
        {
            if (e.CommandName == "Cancel")
            {
                if (ItemCancel != null)
                {
                    ItemCancel(this);
                }
            }
        }

        public void ChangeMode(DetailsViewMode newMode)
        {
            dvwDepartment.ChangeMode(newMode);
        }
    }
}
