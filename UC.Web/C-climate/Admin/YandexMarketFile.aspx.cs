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
using System.Web.Profile;
using System.Text.RegularExpressions;
using System.IO;
using UC;
using UC.Core;
using UC.Services;

namespace UC.UI.Admin
{
    public partial class YandexMarketFile : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!this.IsPostBack)
            //{
            //    if (SiteProvider.Framework.GetSiteMap(Globals.Settings.SiteUrl))
            //    {
            //        lblTitle.Text = "Файл sitemap.xml успешно сгенерирован и размещен в корневом каталоге";
            //    }
            //    else
            //    {
            //        lblTitle.ForeColor = System.Drawing.Color.Red;
            //        lblTitle.Text = "Ошибка при генерации файла sitemap.xml";
            //    }
            //}
        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    string generatedYML = YandexMarketService.GenerateYML(SettingManager.GetSettingValue("Common.StoreURL"), SettingManager.GetSettingValue("Common.Domen"), SettingManager.GetSettingValue("Common.Company"));
                    string fileName = SettingManager.GetSettingValue("Common.Domen");
                    fileName = fileName.Replace(".", "_").ToLower();
                    fileName = string.Format("{0}.xml", fileName);
                    string filePath = string.Format("{0}{1}", HttpContext.Current.Request.PhysicalApplicationPath, fileName);
                    using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                    using (StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default))
                    {
                        sw.Write(generatedYML);
                    }
                    //lblResult.Text = string.Format("Froogle feed has been successfully generated. <a href=\"{0}files/froogle/{1}\" target=\"_blank\" \">Click here</a> to see generated feed", CommonHelper.GetStoreHTTPLocation(false), fileName);
                    lblResult.Text = "Файл успешно сохранен";
                }
                catch (Exception exc)
                {
                    lblResult.Text = "Ошибка при создании файла YML";
                }
            }
        }
    }
}