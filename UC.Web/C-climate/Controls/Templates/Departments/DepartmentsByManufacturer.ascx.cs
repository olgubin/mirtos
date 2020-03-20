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
using System.Linq;
using UC;
using UC.SEOHelper;
using UC.UI;
using UC.BLL.Store;

namespace UC.UI.Controls
{
    public partial class DepartmentsByManufacturer: BaseWebPart
    {
        int _departmentID = 0;
        public int DepartmentID
        {
            get
            {
                // выбор ID раздела каталога из строки запроса
                if (!string.IsNullOrEmpty(this.Request.QueryString["DepID"]))
                {
                    _departmentID = int.Parse(this.Request.QueryString["DepID"]);
                }
                else
                {
                    _departmentID = Globals.Settings.Store.DepartmentRoot;
                }

                return _departmentID;
            }
        }

        int _manufacturerID = 0;
        public int ManufacturerID
        {
            get
            {
                // выбор ID раздела каталога из строки запроса
                if (!string.IsNullOrEmpty(this.Request.QueryString["ManID"]))
                {
                    _manufacturerID = int.Parse(this.Request.QueryString["ManID"]);
                }
                else
                {
                    _manufacturerID = 0;
                }

                return _manufacturerID;
            }
        }

        private class DepartmentHelperClass
        {
            public int DepartmentID { get; set; }
            public string Name { get; set; }
            public string NavigateUrl { get; set; }
            public string ImageUrl { get; set; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DoBinding();
            }
        }

        protected void DoBinding()
        {
            List<DepartmentHelperClass> departments = new List<DepartmentHelperClass>();

            DepartmentCollection departmentCollection = DepartmentManager.GetDepartments(DepartmentID);

            if (ManufacturerID > 0)
            {
                Manufacturer manufacturer = ManufacturerManager.GetManufacturerByID(ManufacturerID);

                litTitle.Text = manufacturer.Title;
                //litBrands.Text = manufacturer.Title;
                imgManufacturer.ImageUrl = manufacturer.ImageUrl;
                lblDescription.Text = manufacturer.Description;
                lblLongDescription.Text = manufacturer.LongDescription;

                DepartmentCollection departmentByManufacturerIDCollection = DepartmentManager.GetByManufacturerID(ManufacturerID);

                foreach (Department item in departmentCollection)
                {
                    foreach (Department item2 in departmentByManufacturerIDCollection)
                    {
                        if (item.DepartmentID == item2.DepartmentID)
                        {
                            DepartmentHelperClass dpt = new DepartmentHelperClass();
                            dpt.DepartmentID = item.DepartmentID;
                            dpt.Name = item.Name + " " + manufacturer.Title;
                            dpt.NavigateUrl = SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/Departments.aspx?" + "DepID=" + item.DepartmentID.ToString() + "&ManID=" + ManufacturerID.ToString()));
                            dpt.ImageUrl = item.ImageUrl;
                            departments.Add(dpt);
                        }
                    }
                }
            }
            else
            {
                foreach (Department item in departmentCollection)
                {
                    DepartmentHelperClass dpt = new DepartmentHelperClass();
                    dpt.DepartmentID = item.DepartmentID;
                    dpt.Name = item.Name;
                    dpt.NavigateUrl = SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/Departments.aspx?" + "DepID=" + item.DepartmentID.ToString()));
                    dpt.ImageUrl = item.ImageUrl;
                    departments.Add(dpt);
                }
            }

            dlstDepartments.DataSource = departments;
            dlstDepartments.DataBind();
        }

        protected void dlstDepartments_ItemCreated(object sender, DataListItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item ||
                e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Repeater repeater = (Repeater)e.Item.FindControl("rptrSubDepartments");

                DataList repeater = (DataList)e.Item.FindControl("rptrSubDepartments");

                if (repeater != null)
                {
                    List<DepartmentHelperClass> departments = new List<DepartmentHelperClass>();

                    DepartmentHelperClass department = (DepartmentHelperClass)e.Item.DataItem;

                    DepartmentCollection departmentCollection = DepartmentManager.GetDepartments(department != null ? department.DepartmentID : -1);

                    if (ManufacturerID > 0)
                    {
                        Manufacturer manufacturer = ManufacturerManager.GetManufacturerByID(ManufacturerID);

                        DepartmentCollection departmentByManufacturerIDCollection = DepartmentManager.GetByManufacturerID(ManufacturerID);

                        foreach (Department item in departmentCollection)
                        {
                            foreach (Department item2 in departmentByManufacturerIDCollection)
                            {
                                if (item.DepartmentID == item2.DepartmentID)
                                {
                                    DepartmentHelperClass dpt = new DepartmentHelperClass();
                                    dpt.DepartmentID = item.DepartmentID;
                                    //dpt.Name = item.Name + " " + manufacturer.Title;
                                    dpt.Name = item.Name;
                                    dpt.NavigateUrl = SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/Departments.aspx?" + "DepID=" + item.DepartmentID.ToString() + "&ManID=" + ManufacturerID.ToString()));
                                    dpt.ImageUrl = item.ImageUrl;
                                    departments.Add(dpt);
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (Department item in departmentCollection)
                        {
                            DepartmentHelperClass dpt = new DepartmentHelperClass();
                            dpt.DepartmentID = item.DepartmentID;
                            dpt.Name = item.Name;
                            dpt.NavigateUrl = SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/Departments.aspx?" + "DepID=" + item.DepartmentID.ToString()));
                            dpt.ImageUrl = item.ImageUrl;
                            departments.Add(dpt);
                        }
                    }

                    repeater.DataSource = departments;
                }
            }
        }
    }
}