using System;
using System.Web.UI.WebControls;
using UC.BLL.Store;

namespace UC.UI.Admin.Controls
{
    public partial class SelectDepartmentTemplateControl : System.Web.UI.UserControl
    {
        private int selectedDepartmentTemplateId;
        public int SelectedDepartmentTemplateId
        {
            get
            {
                if (this.ddlDepartmentTemplates.SelectedItem != null)
                {
                    return int.Parse(this.ddlDepartmentTemplates.SelectedItem.Value);
                }
                else
                    return 0;
            }
            set
            {
                this.selectedDepartmentTemplateId = value;
                if (value > 0)
                {
                    this.ddlDepartmentTemplates.SelectedValue = value.ToString();
                }
            }
        }

        public void BindData()
        {
            ddlDepartmentTemplates.Items.Clear();

            DepartmentTemplateCollection departmentTemplates = DepartmentTemplateManager.GetAllDepartmentTemplates();

            ddlDepartmentTemplates.DataSource = departmentTemplates;

            this.ddlDepartmentTemplates.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public string CssClass
        {
            get
            {
                return ddlDepartmentTemplates.CssClass;
            }
            set
            {
                ddlDepartmentTemplates.CssClass = value;
            }
        }
    }
}