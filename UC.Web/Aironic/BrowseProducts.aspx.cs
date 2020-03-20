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
using UC;
using UC.BLL.Store;

namespace UC.UI
{
    public partial class BrowseProducts : BasePage
    {
        int _departmentID = 0;
        public int DepartmentID
        {
            get
            {
                if (_departmentID == 0)
                {
                    // ����� ID ������� �������� �� ������ �������
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
                    // ����� ID ������� �������� �� ������ �������
                    if (!string.IsNullOrEmpty(this.Request.QueryString["ManID"]))
                    {
                        _manufacturerID = int.Parse(this.Request.QueryString["ManID"]);
                    }
                }
                return _manufacturerID;
            }
        }

        private void CreateChildControlsTree()
        {
            Department department = DepartmentManager.GetByDepartmentID(this.DepartmentID);
            Manufacturer manufacturer = ManufacturerManager.GetManufacturerByID(ManufacturerID);

            if (department != null)
            {
                Control child = null;

                DepartmentTemplate departmentTemplate = department.DepartmentTemplate;
                if (departmentTemplate == null)
                    throw new Exception(string.Format("�� ������ ������ �������. DepartmentID={0}", department.DepartmentID));

                child = base.LoadControl(departmentTemplate.TemplatePath);
                this.ProductPlaceHolder.Controls.Add(child);
            }

            if (manufacturer != null)
            {
                Control child = null;

                child = base.LoadControl("~\\Controls\\Templates\\Departments\\ProductsInGrid.ascx");
                this.ProductPlaceHolder.Controls.Add(child);
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.CreateChildControlsTree();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // ������� ��������� ������ �� ���������� ������
            (this.Page as BasePage).LastPage = "";

            //if (!this.IsPostBack)
            //{
                // ��������� ������� �������� �� ID ������� ���� �� ����� ������
                Department department = DepartmentManager.GetByDepartmentID(DepartmentID);
                Manufacturer manufacturer = ManufacturerManager.GetManufacturerByID(ManufacturerID);

                if (DepartmentID != 0 && department == null)
                {
                    Context.Response.StatusCode = 404;
                    throw new ApplicationException("������ �� ������.");
                }

                if (ManufacturerID != 0 && manufacturer == null)
                {
                    Context.Response.StatusCode = 404;
                    throw new ApplicationException("������������� �� ������.");
                }

                if (manufacturer != null & department != null)
                {
                    //lblTitle.Text = department.Name;
                }
                else
                {
                    if (department != null)
                    {
                        DepartmentCollection departments = DepartmentManager.GetBreadCrumb(department.DepartmentID, Globals.Settings.Store.DepartmentRoot);

                        for (int i = 0; i < departments.Count; i++)
                        {
                            if (i == 0)
                            {
                                BreadCrumb.AddActiveLink(departments[i].Name, "~/DepartmentBrowse.aspx?DepID=" + departments[i].DepartmentID.ToString());
                            }
                            else
                            {
                                if (i == departments.Count - 1)
                                {
                                    BreadCrumb.AddInActiveLink(departments[i].Name);
                                }
                                else
                                {
                                    BreadCrumb.AddActiveLink(departments[i].Name, "~/BrowseProducts.aspx?DepID=" + departments[i].DepartmentID.ToString());
                                }
                            }
                        }

                        BasePage.HeaderWrite(this.Page, department.MetaTitle, department.MetaKeywords, department.Description);
                    }

                    if (manufacturer != null)
                    {
                        BreadCrumb.AddInActiveLink(manufacturer.Title);

                        BasePage.HeaderWrite(this.Page, manufacturer.MetaTitle, manufacturer.MetaKeywords, manufacturer.MetaDescription);
                    }
                }
            //}
        }
    }
}