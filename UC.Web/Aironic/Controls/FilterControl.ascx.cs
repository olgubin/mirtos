using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using UC;
using UC.UI;
using UC.BLL.Store;

namespace UC.UI.Controls
{
    public partial class FilterControl : BaseWebPart
    {
        private const string SESSION = "UCFILTER{0}{1}{2}";

        bool _visible = true;
        public bool Visible
        {
            get { return _visible; }
            set
            {
                _visible = value;
                pnlFilter.Visible = _visible;
            }
        }

        public string SessionKey
        {
            get
            {
                return String.Format(SESSION, DepartmentID.ToString(), ManufacturerID.ToString(), FilterID.ToString());
            }
        }

        int _departmentID = 0;
        public int DepartmentID
        {
            get { return _departmentID; }
            set { _departmentID = value; }
        }

        int _manufacturerID = 0;
        public int ManufacturerID
        {
            get { return _manufacturerID; }
            set { _manufacturerID = value; }
        }

        int _filterID = 0;
        public int FilterID
        {
            get { return _filterID; }
            set { _filterID = value; }
        }

        FilterCriteriaCollection _filterCriteria;
        public FilterCriteriaCollection FilterCriteria
        {
            get
            {
                if (_filterCriteria == null)
                {
                    if (Session[SessionKey] != null)
                        _filterCriteria = (FilterCriteriaCollection)Session[SessionKey];
                }

                return _filterCriteria;
            }
            set
            {
                _filterCriteria = value;
                if (_filterCriteria == null)
                    Session.Remove(SessionKey);
                else
                    Session[SessionKey] = _filterCriteria;
            }
        }

        private class FilterCriteriaHelperClass
        {
            public int FilterCriteriaID { get; set; }
            public int FilterID { get; set; }
            public string Criterion { get; set; }
            public bool IsMarked { get; set; }
        }

        public void DataBind(int departmentID, int manufacturerID, int filterID)
        {
            FilterID = filterID;
            DepartmentID = departmentID;
            ManufacturerID = ManufacturerID;

            if (FilterID > 0)
            {
                Filter f = FilterManager.GetByFilterID(FilterID);

                lblName.Text = f.Name + ":";

                FilterCriteriaCollection fcps;

                List<FilterCriteriaHelperClass> fcpsByFilterID;

                if (ManufacturerID > 0)
                {
                    fcps = FilterManufacturerManager.GetFilterCriteriaByManufacturerID(ManufacturerID, true);

                    fcpsByFilterID = new List<FilterCriteriaHelperClass>();
                }
                else
                {
                    fcps = FilterDepartmentManager.GetFilterCriteriaByDepartmentID(DepartmentID, true);

                    fcpsByFilterID = new List<FilterCriteriaHelperClass>();
                }

                foreach (FilterCriteria item in fcps)
                {
                    if (item.FilterID == FilterID)
                    {
                        FilterCriteriaHelperClass fch = new FilterCriteriaHelperClass();

                        fch.FilterCriteriaID = item.FilterCriteriaID;
                        fch.FilterID = item.FilterID;
                        fch.Criterion = item.Criterion;

                        if (FilterCriteria != null)
                        {
                            foreach (FilterCriteria item2 in FilterCriteria)
                            {
                                if (fch.FilterCriteriaID == item2.FilterCriteriaID)
                                {
                                    fch.IsMarked = true;
                                    break;
                                }
                            }
                        }

                        fcpsByFilterID.Add(fch);
                    }
                }

                //if (fcpsByFilterID.Count > 0)
                //{
                gvFilterCriteria.DataSource = fcpsByFilterID;
                gvFilterCriteria.DataBind();
                //}
                //else
                //{
                //    Visible = false;
                //}
            }
            else
            {
                Visible = false;
            }
        }

        public void GetFilterCriteriaIsMarked(int filterID)
        {
            FilterID = filterID;

            FilterCriteriaCollection fc = new FilterCriteriaCollection();

            foreach (GridViewRow row in gvFilterCriteria.Rows)
            {
                CheckBox cbCriterion = row.FindControl("cbCriterion") as CheckBox;
                HiddenField hfFilterCriteriaID = row.FindControl("hfFilterCriteriaID") as HiddenField;

                if (cbCriterion != null)
                    if (cbCriterion.Checked == true)
                        fc.Add(FilterCriteriaManager.GetByFilterCriteriaID(int.Parse(hfFilterCriteriaID.Value)));
            }

            if (fc.Count > 0)
                FilterCriteria = fc;
            else
                FilterCriteria = null;
        }

        public void Clear()
        {
            foreach (GridViewRow row in gvFilterCriteria.Rows)
            {
                CheckBox cbCriterion = row.FindControl("cbCriterion") as CheckBox;

                if (cbCriterion != null)
                    cbCriterion.Checked = false;
            }

            FilterCriteria = null;
        }
    }
}