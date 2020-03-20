using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using UC.BLL.Store;
using UC.Core;
using UC.SEOHelper;

namespace UC.UI.Controls
{
    public partial class SiteMap : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitializeSiteMap();
                //InitializeXmlSiteMap();
            }
        }

        private void InitializeSiteMap()
        {
            string menu = "";

            foreach (PageElement item in Globals.Settings.SiteMap.StaticPages)
            {
                menu += "<p><a href=\"" + SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/" + item.Page)) + "\">" + item.Name + "</a></p>";
            }

            menu += GetCategories(0, 0);

            _map.Text = menu;
        }

        protected string GetCategories(int ForParentEntityID, int padding)
        {
            StringBuilder tmpS = new StringBuilder();

            DepartmentCollection departmentCollection = DepartmentManager.GetAllDepartments(ForParentEntityID, false);

            for (int i = 0; i < departmentCollection.Count; i++)
            {
                Department department = departmentCollection[i];

                if (department.ParentDepartmentID == 0)
                    tmpS.Append("<p>");

                tmpS.Append(String.Format("<a href=\"{0}\" style=\"padding-left:{1}px\">{2}</a><br/>",
                                              SeoHelper.GetDepartmentUrl(department.DepartmentID), padding,
                                              department.Name));

                if (department.TemplateID != 2)
                {
                    if (DepartmentManager.GetAllDepartments(department.DepartmentID, true).Count > 0)
                        tmpS.Append(GetCategories(department.DepartmentID, padding + 17));
                }

                if (department.ParentDepartmentID == 0)
                    tmpS.Append("</p>");
            }

            return tmpS.ToString();
        }

        //private void InitializeXmlSiteMap()
        //{
        //    string menu = "<?xml version=\"1.0\"?>";

        //    menu += "<SiteMap>";

        //    foreach (PageElement item in Globals.Settings.SiteMap.StaticPages)
        //    {
        //        menu += "<siteMapNode title=\""
        //               + item.Name
        //               + "\" url=\"" + SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/" + item.Page)) + "\">" + "</siteMapNode>";
        //    }

        //    menu += GetXmlCategories(0);

        //    menu += "</SiteMap>";

        //    _xml.DocumentSource = menu;
        //}

        //protected string GetXmlCategories(int ForParentEntityID)
        //{
        //    StringBuilder tmpS = new StringBuilder(4096);

        //    DepartmentCollection departmentCollection = DepartmentManager.GetAllDepartments(ForParentEntityID, false);

        //    for (int i = 0; i < departmentCollection.Count; i++)
        //    {
        //        Department department = departmentCollection[i];

        //        tmpS.Append("<siteMapNode title=\""
        //            + XmlHelper.XmlEncodeAttribute(department.Name)
        //            + "\" url=\"" + XmlHelper.XmlEncodeAttribute(SeoHelper.GetDepartmentUrl(department.DepartmentID)) + "\">");

        //        if (DepartmentManager.GetAllDepartments(department.DepartmentID, true).Count > 0)
        //            tmpS.Append(GetXmlCategories(department.DepartmentID));

        //        tmpS.Append("</siteMapNode>");
        //    }
        //    return tmpS.ToString();
        //}
    }
}
