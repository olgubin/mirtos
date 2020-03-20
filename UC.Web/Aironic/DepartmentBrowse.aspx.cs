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
using UC.BLL.Store;

namespace UC.UI
{
    public partial class DepartmentBrowse : BasePage
    {
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                // получение раздела каталога по ID прверка есть ли такой раздел
                Department department = DepartmentManager.GetByDepartmentID(DepartmentID);

                if (department == null)
                {
                    Context.Response.StatusCode = 404;
                    throw new ApplicationException("Раздел не найден.");
                }
                else
                {
                    BreadCrumb.AddInActiveLink(department.Name);

                    BasePage.HeaderWrite(this.Page, department.MetaTitle, department.MetaKeywords, department.MetaDescription);
                }
            }
        }
    }
}