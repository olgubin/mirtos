using System;
using System.Web.UI.WebControls;
using UC.BLL.Store;

namespace UC.UI.Admin.Controls
{
    public partial class SelectFilterCriteriaControl : System.Web.UI.UserControl
    {
        private int selectedFilterCriteriaId;
        public int SelectedFilterCriteriaId
        {
            get
            {
                return int.Parse(this.ddlFilterCriteria.SelectedItem.Value);
            }
            set
            {
                this.selectedFilterCriteriaId = value;
                this.ddlFilterCriteria.SelectedValue = value.ToString();
            }
        }

        public void BindData()
        {
            ddlFilterCriteria.Items.Clear();

            FilterCollection filterCollection = FilterManager.GetFilters();

            foreach (Filter filter in filterCollection)
            {
                ListItem item = new ListItem(filter.Name, "0");
                this.ddlFilterCriteria.Items.Add(item);

                FilterCriteriaCollection filterCriteriaCollection = FilterCriteriaManager.GetFilterCriteriaByFilterID(filter.FilterID);

                if (filterCriteriaCollection.Count > 0)
                {
                    foreach (FilterCriteria filterCriteria in filterCriteriaCollection)
                    {
                        ListItem filterCriteriaItem = new ListItem("---" + filterCriteria.Criterion, filterCriteria.FilterCriteriaID.ToString());
                        this.ddlFilterCriteria.Items.Add(filterCriteriaItem);

                        if (filterCriteria.FilterCriteriaID == this.selectedFilterCriteriaId)
                            item.Selected = true;
                    }
                }
            }

            this.ddlFilterCriteria.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
        
        public string CssClass
        {
            get
            {
                return ddlFilterCriteria.CssClass;
            }
            set
            {
                ddlFilterCriteria.CssClass = value;
            }
        }
    }
}