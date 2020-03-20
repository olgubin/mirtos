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
    public partial class DepartmentsInGrid2 : BaseWebPart
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
                DoBinding();
        }

        private class DepartmentHelperClass
        {
            public int DepartmentId { get; set; }
            public string Name { get; set; }
            public string ImageUrl { get; set; }
            public string NavigateUrl { get; set; }
        }

        protected void DoBinding()
        {
            //Department department = DepartmentManager.GetByDepartmentID(DepartmentID);

            //litTitle.Text = department.Name;

            //DepartmentCollection departmentCollection = DepartmentManager.GetDepartments(DepartmentID);
            //dlstDepartments.DataSource = departmentCollection;
            //dlstDepartments.DataBind();

            Department department = DepartmentManager.GetByDepartmentID(DepartmentID);

            if (department != null)
            {
                litTitle.Text = department.Name;

                if (!String.IsNullOrEmpty(department.LongDescription))
                {
                    _litLongDescription.Visible = true;
                    _litLongDescription.Text = department.LongDescription;
                }

                List<DepartmentHelperClass> departments = new List<DepartmentHelperClass>();

                DepartmentCollection departmentCollection = DepartmentManager.GetDepartments(DepartmentID);

                if (ManufacturerID > 0)
                {
                    DepartmentCollection departmentByManufacturerIDCollection = DepartmentManager.GetByManufacturerID(ManufacturerID);

                    Manufacturer manufacturer = ManufacturerManager.GetManufacturerByID(ManufacturerID);

                    foreach (Department item in departmentCollection)
                    {
                        foreach (Department item2 in departmentByManufacturerIDCollection)
                        {
                            if (item.DepartmentID == item2.DepartmentID)
                            {
                                DepartmentHelperClass dpt = new DepartmentHelperClass();
                                dpt.DepartmentId = item.DepartmentID;
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
                        dpt.DepartmentId = item.DepartmentID;
                        dpt.Name = item.Name;
                        dpt.NavigateUrl = UC.SEOHelper.SeoHelper.GetDepartmentUrl(item.DepartmentID); //"~/Departments.aspx?" + "DepID=" + item.DepartmentID.ToString();
                        dpt.ImageUrl = item.ImageUrl;
                        departments.Add(dpt);
                    }
                }

                dlstDepartments.DataSource = departments;
                dlstDepartments.DataBind();
            }
        }

        protected void dlstDepartments_ItemCreated(object sender, DataListItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item ||
                e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater repeater = (Repeater)e.Item.FindControl("rptrSubDepartments");

                if (repeater != null)
                {
                    //Department department = (Department)e.Item.DataItem;

                    //DepartmentCollection departmentCollection = DepartmentManager.GetDepartments(department != null ? department.DepartmentID : -1);
                    //repeater.DataSource = departmentCollection;

                    if (ManufacturerID <= 0)
                    {
                        DepartmentHelperClass department = (DepartmentHelperClass) e.Item.DataItem;

                        DepartmentCollection departmentCollection =
                            DepartmentManager.GetDepartments(department != null ? department.DepartmentId : -1);
                        repeater.DataSource = departmentCollection;
                    }

                    //DepartmentHelperClass department = (DepartmentHelperClass)e.Item.DataItem;

                    //List<DepartmentHelperClass> departments = new List<DepartmentHelperClass>();

                    //DepartmentCollection departmentCollection = DepartmentManager.GetDepartments(department != null ? department.DepartmentId : -1);

                    //if (ManufacturerID > 0)
                    //{
                    //    DepartmentCollection departmentByManufacturerIDCollection = DepartmentManager.GetByManufacturerID(ManufacturerID);

                    //    foreach (Department item in departmentCollection)
                    //    {
                    //        foreach (Department item2 in departmentByManufacturerIDCollection)
                    //        {
                    //            if (item.DepartmentID == item2.DepartmentID)
                    //            {
                    //                DepartmentHelperClass dpt = new DepartmentHelperClass();
                    //                dpt.DepartmentId = item.DepartmentID;
                    //                dpt.Name = item.Name;
                    //                dpt.ImageUrl = item.ImageUrl;
                    //                departments.Add(dpt);
                    //            }
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    foreach (Department item in departmentCollection)
                    //    {
                    //        DepartmentHelperClass dpt = new DepartmentHelperClass();
                    //        dpt.DepartmentId = item.DepartmentID;
                    //        dpt.Name = item.Name;
                    //        dpt.ImageUrl = item.ImageUrl;
                    //        departments.Add(dpt);
                    //    }
                    //}

                    //dlstDepartments.DataSource = departments;
                    //dlstDepartments.DataBind();
                }
            }
        }
    }
}