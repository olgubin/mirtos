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
using UC.UI;
using UC.BLL.Store;

namespace UC.UI.Controls
{
    public partial class DepartmentsInGridWithDescription : BaseWebPart
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
                DoBinding();
        }

        private int _RepeatColumns = -1;
        [Personalizable(PersonalizationScope.Shared),
        WebBrowsable,
        WebDisplayName("RepeatColumns"),
        WebDescription("Количество отображаемых столбцов")]
        public int RepeatColumns
        {
            get { return _RepeatColumns; }
            set { _RepeatColumns = value; }
        }

        protected void DoBinding()
        {
            int RepeatColumns = (this.RepeatColumns == -1 ? 2 : this.RepeatColumns);

            dlstDepartments.RepeatColumns = RepeatColumns;

            Department department = DepartmentManager.GetByDepartmentID(DepartmentID);

            if (department != null)
            {
                litTitle.Text = department.Name;

                DepartmentCollection departmentCollection = DepartmentManager.GetDepartments(DepartmentID);
                dlstDepartments.DataSource = departmentCollection;
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
                    Department department = (Department)e.Item.DataItem;

                    DepartmentCollection departmentCollection = DepartmentManager.GetDepartments(department != null ? department.DepartmentID : -1);
                    repeater.DataSource = departmentCollection;
                }
            }
        }
    }
}