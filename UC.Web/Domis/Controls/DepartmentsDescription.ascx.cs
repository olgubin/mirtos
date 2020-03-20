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
   public partial class DepartmentsDescription : BaseWebPart
   {
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

           DepartmentCollection departmentCollection = DepartmentManager.GetDepartments(0);
           dlstDepartments.DataSource = departmentCollection;
           dlstDepartments.DataBind();
       }
   }
}