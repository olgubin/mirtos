using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Security;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using FredCK.FCKeditorV2;
using UC;
using UC.Core;

namespace UC.UI.Admin
{
    public partial class CommonSettings : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            txtStoreName.Text = SettingManager.GetSettingValue("Common.StoreName");
            txtStoreURL.Text = SettingManager.GetSettingValue("Common.StoreURL");
            txtDomen.Text = SettingManager.GetSettingValue("Common.Domen");
            txtCompany.Text = SettingManager.GetSettingValue("Common.Company");
            txtPhone.Text = SettingManager.GetSettingValue("Common.Phone");
            txtWorkPeriod.Text = SettingManager.GetSettingValue("Common.WorkPeriod");
            txtMailTo.Text = SettingManager.GetSettingValue("Common.MailTo");
            txtZakazTo.Text = SettingManager.GetSettingValue("Common.ZakazTo");
            headerTitle.Text = SettingManager.GetSettingValue("Common.Title");
            headerDescription.Text = SettingManager.GetSettingValue("Common.MetaDescription");
            headerKeywords.Text = SettingManager.GetSettingValue("Common.MetaKeywords");
            headerYandexVerification.Text = SettingManager.GetSettingValue("Common.MetaYandex");
            headerGoogleVerification.Text = SettingManager.GetSettingValue("Common.MetaGoogle");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    SettingManager.SetParam("Common.StoreName", txtStoreName.Text, string.Empty);
                    SettingManager.SetParam("Common.StoreURL", txtStoreURL.Text, string.Empty);
                    SettingManager.SetParam("Common.Domen", txtDomen.Text, string.Empty);
                    SettingManager.SetParam("Common.Company", txtCompany.Text, string.Empty);
                    SettingManager.SetParam("Common.Phone", txtPhone.Text, string.Empty);
                    SettingManager.SetParam("Common.WorkPeriod", txtWorkPeriod.Text, string.Empty);
                    SettingManager.SetParam("Common.MailTo", txtMailTo.Text, string.Empty);
                    SettingManager.SetParam("Common.ZakazTo", txtZakazTo.Text, string.Empty);
                    SettingManager.SetParam("Common.Title", headerTitle.Text, string.Empty);
                    SettingManager.SetParam("Common.MetaDescription", headerDescription.Text, string.Empty);
                    SettingManager.SetParam("Common.MetaKeywords", headerKeywords.Text, string.Empty);
                    SettingManager.SetParam("Common.MetaYandex", headerYandexVerification.Text, string.Empty);
                    SettingManager.SetParam("Common.MetaGoogle", headerGoogleVerification.Text, string.Empty);

                    Response.Redirect("CommonSettings.aspx");
                }
                catch { }
            }
        }
    }
}