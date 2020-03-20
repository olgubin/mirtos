using System;
using System.Web.UI.WebControls;
using UC.BLL.Store;

namespace UC.UI.Admin.Controls
{
    public partial class SelectFilterControl : System.Web.UI.UserControl
    {
        private int selectedFilterId;
        public int SelectedFilterId
        {
            get
            {
                return int.Parse(this.ddlFilters.SelectedItem.Value);
            }
            set
            {
                this.selectedFilterId = value;
                this.ddlFilters.SelectedValue = value.ToString();
            }
        }

        public void BindData()
        {
            ddlFilters.Items.Clear();

            FilterCollection filterCollection = FilterManager.GetFilters();

            ddlFilters.DataSource = filterCollection;

            this.ddlFilters.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public string CssClass
        {
            get
            {
                return ddlFilters.CssClass;
            }
            set
            {
                ddlFilters.CssClass = value;
            }
        }
    }
}