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
    public partial class Departments : BasePage
    {
        int _departmentID = 0;
        public int DepartmentID
        {
            get
            {
                if (_departmentID == 0)
                {
                    try
                    {
                        // выбор ID раздела каталога из строки запроса
                        if (!string.IsNullOrEmpty(this.Request.QueryString["DepID"]))
                        {
                            _departmentID = int.Parse(this.Request.QueryString["DepID"]);
                        }
                    }
                    catch 
                    {
                        _departmentID = -1;
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
                    try
                    {
                        // выбор ID раздела каталога из строки запроса
                        if (!string.IsNullOrEmpty(this.Request.QueryString["ManID"]))
                        {
                            _manufacturerID = int.Parse(this.Request.QueryString["ManID"]);
                        }
                    }
                    catch
                    {
                        _manufacturerID = -1;
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
                    throw new Exception(string.Format("Не указан шаблон раздела. DepartmentID={0}", department.DepartmentID));

                child = base.LoadControl(departmentTemplate.TemplatePath);
                this.ProductPlaceHolder.Controls.Add(child);
            }
            else
            {
                if (manufacturer != null)
                {
                    Control child = null;

                    child = base.LoadControl("~\\Controls\\Templates\\Departments\\DepartmentsByManufacturer.ascx");
                    //child = base.LoadControl("~\\Controls\\Templates\\Departments\\ProductsInGrid.ascx");
                    this.ProductPlaceHolder.Controls.Add(child);
                }
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.CreateChildControlsTree();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // очищаем возможную ссылку на результаты поиска
            (this.Page as BasePage).LastPage = "";

            //if (!this.IsPostBack)
            //{
            // получение раздела каталога по ID прверка есть ли такой раздел
            Department department = DepartmentManager.GetByDepartmentID(DepartmentID);
            Manufacturer manufacturer = ManufacturerManager.GetManufacturerByID(ManufacturerID);

            if (DepartmentID != 0 && department == null)
            {
                Context.Response.StatusCode = 404;

                this.Title = "404 Not Found";

                pnlContent.Visible = false;

                ctrl404.Visible = true;

                //throw new ApplicationException("Раздел не найден.");
            }

            if (ManufacturerID != 0 && manufacturer == null)
            {
                Context.Response.StatusCode = 404;

                this.Title = "404 Not Found";

                pnlContent.Visible = false;

                ctrl404.Visible = true;

                //throw new ApplicationException("Производитель не найден.");
            }

            if (department != null)
            {
                DepartmentCollection departments = DepartmentManager.GetBreadCrumb(department.DepartmentID, Globals.Settings.Store.DepartmentRoot);

                for (int i = 0; i < departments.Count; i++)
                {
                    if (departments.Count - i == 0)
                    {
                        //BreadCrumb.AddActiveLink(departments[i].Name, "~/Departments.aspx?DepID=" + departments[i].DepartmentID.ToString());
                        BreadCrumb.AddActiveLink(departments[i].Name, UC.SEOHelper.SeoHelper.GetDepartmentUrl(departments[i].DepartmentID));
                        
                    }
                    else
                    {
                        if (i == departments.Count - 1)
                        {
                            if (manufacturer != null)
                            {
                                //BreadCrumb.AddActiveLink(departments[i].Name, "~/Departments.aspx?DepID=" + departments[i].DepartmentID.ToString());
                                BreadCrumb.AddActiveLink(departments[i].Name, UC.SEOHelper.SeoHelper.GetDepartmentUrl(departments[i].DepartmentID));

                                BreadCrumb.AddInActiveLink(manufacturer.Title);
                            }
                            else
                            {
                                BreadCrumb.AddInActiveLink(departments[i].Name);
                            }
                        }
                        else
                        {
                            //BreadCrumb.AddActiveLink(departments[i].Name, "~/Departments.aspx?DepID=" + departments[i].DepartmentID.ToString());
                            BreadCrumb.AddActiveLink(departments[i].Name, UC.SEOHelper.SeoHelper.GetDepartmentUrl(departments[i].DepartmentID));
                        }
                    }
                }

                if (manufacturer != null)
                {
                    BasePage.HeaderWrite(this.Page, department.MetaTitle, department.MetaKeywords, department.MetaDescription);
                }
                else
                {
                    BasePage.HeaderWrite(this.Page, department.MetaTitle, department.MetaKeywords, department.MetaDescription);
                }
            }
            else
            {
                if (manufacturer != null)
                {
                    BreadCrumb.AddInActiveLink(manufacturer.Title);

                    BasePage.HeaderWrite(this.Page, manufacturer.MetaTitle, manufacturer.MetaKeywords, manufacturer.MetaDescription);
                }
            }
        }
    }
}