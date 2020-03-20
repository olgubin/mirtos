using System;
using System.Web.UI.WebControls;
using UC.BLL.Store;

namespace UC.UI.Admin.Controls
{
    public partial class SelectDepartmentControl : System.Web.UI.UserControl
    {
        public delegate void SelectedIndexChangeEventHandler(object sender, EventArgs e);
        public event SelectedIndexChangeEventHandler SelectedIndexChange;

        public bool AutoPostBack
        {
            get
            {
                return this.ddlDepartments.AutoPostBack;
            }
            set
            {
                this.ddlDepartments.AutoPostBack = value;
            }
        }

        private int selectedDepartmentId;
        public int SelectedDepartmentId
        {
            get
            {
                if (this.ddlDepartments.SelectedItem == null)
                {
                    return 0;
                }
                else
                {
                    return int.Parse(this.ddlDepartments.SelectedItem.Value);
                }
            }
            set
            {
                this.selectedDepartmentId = value;
                this.ddlDepartments.SelectedValue = value.ToString();
            }
        }

        public void BindData()
        {
            ddlDepartments.Items.Clear();
            ddlDepartments.Items.Add(new ListItem("[ --- ]", "0"));
            BindData(0, "--");
        }

        public void BindData(int ForParentEntityID, string prefix)
        {
            DepartmentCollection departmentCollection = DepartmentManager.GetAllDepartments(ForParentEntityID, true);

            foreach (Department department in departmentCollection)
            {
                ListItem item = new ListItem(prefix + department.Name + (!department.Published ? " (NV)" : ""), department.DepartmentID.ToString());
                this.ddlDepartments.Items.Add(item);
                if (department.DepartmentID == this.selectedDepartmentId)
                    item.Selected = true;
                if (DepartmentManager.GetAllDepartments(department.DepartmentID, true).Count > 0)
                    BindData(department.DepartmentID, prefix + "--");
            }

            this.ddlDepartments.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public string CssClass
        {
            get
            {
                return ddlDepartments.CssClass;
            }
            set
            {
                ddlDepartments.CssClass = value;
            }
        }

        protected void ddlDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedIndexChange != null)
            {
                SelectedIndexChange(this, e);
            }
        }
    }
}