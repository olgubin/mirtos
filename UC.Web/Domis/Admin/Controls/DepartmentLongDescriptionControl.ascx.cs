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
using FredCK.FCKeditorV2;
using UC.BLL.Store;

namespace UC.UI.Admin.Controls
{
    public partial class DepartmentLongDescriptionControl : System.Web.UI.UserControl
    {
        private int _departmentID;
        public int DepartmentID
        {
            get
            {
                if (!String.IsNullOrEmpty(hfDepartmentID.Value))
                {
                    _departmentID = Int32.Parse(hfDepartmentID.Value);
                }
                else
                    _departmentID = 0;

                return _departmentID; 
            }
            set
            {
                _departmentID = value;

                hfDepartmentID.Value = _departmentID.ToString();

                txtLongDescription.Value = DepartmentManager.GetDepartmentLongDescription(_departmentID);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string baseUrl = Page.Request.ApplicationPath;
            if (!baseUrl.EndsWith("/"))
                baseUrl = baseUrl + "/";

            txtLongDescription.BasePath = baseUrl + "FCKeditor/";
        }

        /// <summary>
        /// Обновление расширенного описания
        /// </summary>
        protected void btnUpdateDepartmentLongDescription_Click(object sender, EventArgs e)
        {
            try
            {
                if (DepartmentManager.UpdateDepartmentLongDescription(DepartmentID, txtLongDescription.Value))
                {
                    lblbtnUpdateDepartmentLongDescription.Text = "Сохранение успешно проведено";
                }
                else
                {
                    lblbtnUpdateDepartmentLongDescription.Text = "Ошибка при сохранении";
                }
            }
            catch (Exception exc)
            {
                lblbtnUpdateDepartmentLongDescription.Text = "Ошибка при сохранении";
            }
        }
    }
}
