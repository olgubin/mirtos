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
using UC.Core;

namespace UC.UI
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string commonStoreName = SettingManager.GetSettingValue("Common.StoreName");
            string commonStoreDomen = SettingManager.GetSettingValue("Common.Domen");
            string commonStoreUrl = SettingManager.GetSettingValue("Common.StoreURL");
            string commonStorePhone = SettingManager.GetSettingValue("Common.Phone");
            string commonStoreWorkPeriod = SettingManager.GetSettingValue("Common.WorkPeriod");
            string commonStoreMailTo = SettingManager.GetSettingValue("Common.MailTo");
            string commonTitle = SettingManager.GetSettingValue("Common.Title");
            string commonDescription = SettingManager.GetSettingValue("Common.MetaDescription");
            string commonKeywords = SettingManager.GetSettingValue("Common.MetaKeywords");
            string commonYandex = SettingManager.GetSettingValue("Common.MetaYandex");
            string commonGoogle = SettingManager.GetSettingValue("Common.MetaGoogle");

            hlnkDomen.NavigateUrl = commonStoreUrl;
            hlnkDomen.Text = commonStoreDomen;

            hlnkMailTo.NavigateUrl = "mailto:" + commonStoreMailTo;
            hlnkMailTo.Text = commonStoreMailTo;

            hlnkLogo.NavigateUrl = commonStoreUrl;
            hlnkLogo.ToolTip = commonStoreName;

            litTel.Text = commonStorePhone;

            litFooter.Text = " " + commonStoreWorkPeriod + ", " + commonStorePhone + ", ";

            Helpers.RenderTitle(this.Page, commonTitle, false);
            Helpers.RenderMetaTag(this.Page, "keywords", commonKeywords, false);
            Helpers.RenderMetaTag(this.Page, "description", commonDescription, false);
            if (!String.IsNullOrEmpty(commonYandex))
                Helpers.AddMetaTag(this.Page, "yandex-verification", commonYandex);
            if (!String.IsNullOrEmpty(commonGoogle))
                Helpers.AddMetaTag(this.Page, "verify-v1", commonGoogle);
        }
    }
}