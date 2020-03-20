using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using UC.BLL.Store;

namespace UC.UI.Admin.Controls
{
    public partial class DepartmentGridControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //if (DepartmentID > 0)
                //{
                //    //Заполнение списка разделов
                //    ddlFilters.BindData();

                //    //Заполнение таблицы разделов
                //    BindFilterDepartmentMapping();
                //}
            }
        }
    }
}
