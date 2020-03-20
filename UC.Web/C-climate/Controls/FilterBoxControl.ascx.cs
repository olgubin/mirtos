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
using System.Linq;
using UC;
using UC.UI;
using UC.BLL.Store;

namespace UC.UI.Controls
{
    public partial class FilterBoxControl : BaseWebPart
    {
        public delegate void FilteredEventHandler(object sender);
        public event FilteredEventHandler Filtered;

        int _departmentID = 0;
        public int DepartmentID
        {
            get
            {
                if (_departmentID == 0)
                {
                    // выбор ID раздела каталога из строки запроса
                    if (!string.IsNullOrEmpty(this.Request.QueryString["DepID"]))
                    {
                        _departmentID = int.Parse(this.Request.QueryString["DepID"]);
                    }
                }
                return _departmentID;
            }
        }

        int _manufacturerID = 0;
        public int ManufacturerID
        {
            get
            {
                if (_manufacturerID == 0)
                {
                    // выбор ID раздела каталога из строки запроса
                    if (!string.IsNullOrEmpty(this.Request.QueryString["ManID"]))
                    {
                        _manufacturerID = int.Parse(this.Request.QueryString["ManID"]);
                    }
                }
                return _manufacturerID;
            }
        }

        FilterCollection _filters;
        public FilterCollection Filters
        {
            get
            {
                if (_filters == null)
                {
                    if (DepartmentID > 0)
                    {
                        FilterDepartmentCollection fds = FilterDepartmentManager.GetFilterDepartmentByDepartmentID(DepartmentID);

                        _filters = new FilterCollection();

                        foreach (FilterDepartment item in fds)
                        {
                            _filters.Add(item.Filter);
                        }
                    }
                    else
                    {
                        FilterManufacturerCollection fms = FilterManufacturerManager.GetFilterManufacturerByManufacturerID(ManufacturerID);

                        _filters = new FilterCollection();

                        foreach (FilterManufacturer item in fms)
                        {
                            _filters.Add(item.Filter);
                        }
                    }
                }

                return _filters;
            }
        }

        public FilterCriteriaCollection GetFilterCriteriaByFilterID(int FilterID)
        {
            FilterControl fc = rowFilter.FindControl("fc" + FilterID.ToString()) as FilterControl;

            if (fc != null)
            {
                fc.DepartmentID = DepartmentID;
                fc.ManufacturerID = ManufacturerID;
                fc.FilterID = FilterID;
                return fc.FilterCriteria;
            }
            else
                return null;
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            CreateFilters();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                BindFilters();
            }
        }

        protected void CreateFilters()
        {
            if (Filters.Count > 0)
            {
                foreach (Filter item in Filters)
                {
                    FilterControl fc = (FilterControl)base.LoadControl("~/Controls/FilterControl.ascx");

                    fc.ID = "fc" + item.FilterID.ToString();

                    TableCell cell = new TableCell();

                    cell.Controls.Add(fc);

                    rowFilter.Cells.Add(cell);
                }
            }
            else
            {
                pnlFilterBox.Visible = false;
            }
        }

        protected void BindFilters()
        {
            foreach (Filter item in Filters)
            {
                FilterControl fc = rowFilter.FindControl("fc" + item.FilterID.ToString()) as FilterControl;

                if (fc != null)
                {
                    fc.DepartmentID = DepartmentID;
                    fc.ManufacturerID = ManufacturerID;
                    fc.FilterID = item.FilterID;
                    fc.DataBind(DepartmentID, ManufacturerID, item.FilterID);
                }
            }
        }

        protected void btnSelect_Click(object sender, ImageClickEventArgs e)
        {
            foreach (Filter item in Filters)
            {
                FilterControl fc = rowFilter.FindControl("fc" + item.FilterID.ToString()) as FilterControl;

                if (fc != null)
                {
                    fc.DepartmentID = DepartmentID;
                    fc.ManufacturerID = ManufacturerID;
                    fc.GetFilterCriteriaIsMarked(item.FilterID);
                }
            }

            if (Filtered != null)
            {
                Filtered(this);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            foreach (Filter item in Filters)
            {
                FilterControl fc = rowFilter.FindControl("fc" + item.FilterID.ToString()) as FilterControl;

                if (fc != null)
                {
                    fc.DepartmentID = DepartmentID;
                    fc.ManufacturerID = ManufacturerID;
                    fc.FilterID = item.FilterID;
                    fc.Clear();
                }
            }

            if (Filtered != null)
            {
                Filtered(this);
            }
        }
    }
}