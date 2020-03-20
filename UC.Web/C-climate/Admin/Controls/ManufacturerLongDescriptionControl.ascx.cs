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
    public partial class ManufacturerLongDescriptionControl : System.Web.UI.UserControl
    {
        private int _manufacturerID;
        public int ManufacturerID
        {
            get
            {
                if (!String.IsNullOrEmpty(hfManufacturerID.Value))
                {
                    _manufacturerID = Int32.Parse(hfManufacturerID.Value);
                }
                else
                    _manufacturerID = 0;

                return _manufacturerID; 
            }
            set
            {
                _manufacturerID = value;

                hfManufacturerID.Value = _manufacturerID.ToString();

                txtLongDescription.Value = ManufacturerManager.GetManufacturerLongDescription(_manufacturerID);
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
        protected void btnUpdateManufacturerLongDescription_Click(object sender, EventArgs e)
        {
            try
            {
                if (ManufacturerManager.UpdateManufacturerLongDescription(ManufacturerID, txtLongDescription.Value))
                {
                    lblbtnUpdateManufacturerLongDescription.Text = "Сохранение успешно проведено";
                }
                else
                {
                    lblbtnUpdateManufacturerLongDescription.Text = "Ошибка при сохранении";
                }
            }
            catch (Exception exc)
            {
                lblbtnUpdateManufacturerLongDescription.Text = "Ошибка при сохранении";
            }
        }
    }
}
