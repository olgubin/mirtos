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
using UC.UI;
using UC.BLL.Store;

namespace UC.UI.Controls
{
    public partial class DepartmentMenu : BaseWebPart
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }

        protected void BindData()
        {
            //TODO: parent only are shown now
            DepartmentCollection departmentCollection = DepartmentManager.GetDepartments(Globals.Settings.Store.DepartmentRoot);
            dlstDepartments.DataSource = departmentCollection;
            dlstDepartments.DataBind();
        }
    }
}