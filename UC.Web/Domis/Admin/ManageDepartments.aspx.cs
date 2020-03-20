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
using System.Text;
using UC;
using UC.Core;
using UC.BLL.Store;

namespace UC.UI.Admin
{
    public partial class ManageDepartments : BasePage
    {
        private int addedDepartmentId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitializeDepartmentTreeView();
            }
        }

        private void InitializeDepartmentTreeView()
        {
            string menu = GetCategories(0);
            menu = "<siteMapNode title=\"Departments\" url=\"" + string.Empty + "\">" + menu + "</siteMapNode>";
            ds.Data = menu;
            tvwDepartments.DataBind();
            tvwDepartments.CollapseAll();
            //tvwDepartments.ExpandAll();
            new TreeViewState().RestoreTreeView(tvwDepartments, this.GetType().ToString());
        }

        protected string GetCategories(int ForParentEntityID)
        {
            StringBuilder tmpS = new StringBuilder(4096);

            DepartmentCollection departmentCollection = DepartmentManager.GetAllDepartments(ForParentEntityID, true);

            for (int i = 0; i < departmentCollection.Count; i++)
            {
                Department department = departmentCollection[i];

                tmpS.Append("<siteMapNode title=\"" + department.DisplayOrder.ToString() + "-"
                    + XmlHelper.XmlEncodeAttribute(department.Name) + (!department.Published ? " (NV)" : "")
                    + "\" departmentID=\"" + XmlHelper.XmlEncodeAttribute(department.DepartmentID.ToString()) + "\">");

                if (DepartmentManager.GetAllDepartments(department.DepartmentID,true).Count > 0)
                    tmpS.Append(GetCategories(department.DepartmentID));

                tmpS.Append("</siteMapNode>");
            }
            return tmpS.ToString();
        }

        protected void tvwDepartments_SelectedNodeChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tvwDepartments.SelectedValue))
            {
                DepartmentFiltersControl.DepartmentID = Int32.Parse(tvwDepartments.SelectedValue);
                DepartmentLongDescriptionControl.DepartmentID = Int32.Parse(tvwDepartments.SelectedValue);
            }
            DepartmentDescription.ChangeMode(DetailsViewMode.Edit);
        }

        protected void tvwDepartments_Unload(object sender, EventArgs e)
        {
            // save the state of all nodes.
            new TreeViewState().SaveTreeView(tvwDepartments, this.GetType().ToString());
        }

        protected void UpdateTree(object sender)
        {
            InitializeDepartmentTreeView();
            DepartmentFiltersControl.DepartmentID = 0;
            DepartmentLongDescriptionControl.DepartmentID = 0;
        }
    }
}