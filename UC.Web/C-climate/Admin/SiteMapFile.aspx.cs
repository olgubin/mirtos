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
using UC.DAL;
using UC.Core;
using UC.Services;

namespace UC.UI.Admin
{
    public partial class SiteMapFile : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string siteMap = SiteMapService.GenerateSiteMap(SettingManager.GetSettingValue("Common.StoreURL"));
                string filePath = string.Format("{0}{1}", HttpContext.Current.Request.PhysicalApplicationPath, "sitemap.xml");
                using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                using (StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default))
                {
                    sw.Write(siteMap);
                }
                //lblResult.Text = string.Format("Froogle feed has been successfully generated. <a href=\"{0}files/froogle/{1}\" target=\"_blank\" \">Click here</a> to see generated feed", CommonHelper.GetStoreHTTPLocation(false), fileName);
                lblResult.Text = "���� sitemap.xml ������� ������������ � �������� � �������� ��������";
            }
            catch (Exception exc)
            {
                lblResult.Text = "������ ��� ��������� ����� sitemap.xml";
            }




            //if (!this.IsPostBack)
            //{
            //    if (SiteProvider.Framework.GetSiteMap(Globals.Settings.SiteUrl))
            //    {
            //        lblTitle.Text = "���� sitemap.xml ������� ������������ � �������� � �������� ��������";
            //    }
            //    else
            //    {
            //        lblTitle.ForeColor = System.Drawing.Color.Red;
            //        lblTitle.Text = "������ ��� ��������� ����� sitemap.xml";
            //    }
            //}
        }
    }
}