using System;
using System.Configuration;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Globalization;
using UC.BLL.Store;
using UC.BLL.Articles;

namespace UC.Services
{
    /// <summary>
    /// SiteMap file
    /// </summary>
    public static class SiteMapService
    {
        public static SiteMapElement Settings
        {
            get { return Globals.Settings.SiteMap; }
        }

        /// <summary>
        /// Generate sitemap file
        /// </summary>
        /// <returns></returns>
        public static string GenerateSiteMap(string url)
        {
            TextWriter stringWriter = new StringWriter();

            stringWriter.Write("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");

            XmlTextWriter writer = new XmlTextWriter(stringWriter);
            writer.WriteStartElement("urlset");
            writer.WriteAttributeString("xmlns", "http://www.sitemaps.org/schemas/sitemap/0.9");

            foreach (PageElement item in Settings.StaticPages)
            {
                writer.WriteStartElement("url");
                writer.WriteElementString("loc", url + item.Page);
                writer.WriteEndElement();
            }

            List<Category> articleCategory = Category.GetCategories();

            foreach(Category item in articleCategory)
            {
                writer.WriteStartElement("url");
                writer.WriteElementString("loc", url + "Articles.aspx?CatID=" + item.ID.ToString());
                writer.WriteEndElement();
            }

            List<Article> articles = Article.GetArticles(true);

            foreach(Article item in articles)
            {
                writer.WriteStartElement("url");
                writer.WriteElementString("loc", url + "Article.aspx?ID=" + item.ID.ToString());
                writer.WriteEndElement();
            }

            //List<Newsletter> newsletters = Newsletter.GetNewsletters();

            //foreach(Article item in articles)
            //{
            //    writer.WriteStartElement("url");
            //    writer.WriteElementString("loc", url + "Article.aspx?ID=" + item.ID.ToString());
            //    writer.WriteEndElement();
            //}


            DepartmentCollection departmentCollection = new DepartmentCollection();

            GetDepartments(departmentCollection, Globals.Settings.Store.DepartmentRoot); //разделы каталогов

            foreach (Department item in departmentCollection)
            {
                writer.WriteStartElement("url");
                //writer.WriteElementString("loc", url + "Departments.aspx?DepID=" + item.DepartmentID.ToString());
                writer.WriteElementString("loc", SEOHelper.SeoHelper.GetDepartmentUrl(item.DepartmentID));
                writer.WriteEndElement();
            }

            ManufacturerCollection manufacturerCollection = ManufacturerManager.GetManufacturers(false);

            foreach (Manufacturer item in manufacturerCollection)
            {
                writer.WriteStartElement("url");
                writer.WriteElementString("loc", url + "Departments.aspx?ManID=" + item.ManufacturerID.ToString());
                writer.WriteEndElement();
            }

            ProductCollection products = ProductManager.GetAllProducts(false);

            foreach (Product item in products)
            {
                writer.WriteStartElement("url");
                writer.WriteElementString("loc", url + "ShowProduct.aspx?ID=" + item.ProductID.ToString());
                writer.WriteEndElement();
            }

            writer.WriteEndElement(); //urlset

            string result = stringWriter.ToString();

            return result;
        }

        private static void GetDepartments(XmlTextWriter writer, int parentID)
        {
            DepartmentCollection departmentCollection = DepartmentManager.GetAllDepartments(parentID, false);

            foreach (Department department in departmentCollection)
            {
                writer.WriteStartElement("category");
                writer.WriteAttributeString("id", department.DepartmentID.ToString());
                if (department.ParentDepartmentID > 0)
                    writer.WriteAttributeString("parentId", department.ParentDepartmentID.ToString());

                writer.WriteString(department.Name + (!department.Published ? " (NV)" : ""));
                writer.WriteEndElement();

                GetDepartments(writer, department.DepartmentID);
            }
        }

        private static void GetDepartments(DepartmentCollection departmentCollection, int parentID)
        {
            DepartmentCollection departments = DepartmentManager.GetAllDepartments(parentID, false);

            foreach (Department department in departments)
            {
                departmentCollection.Add(department);

                GetDepartments(departmentCollection, department.DepartmentID);
            }

            //departmentCollection = DepartmentManager.GetAllDepartments(parentID, false);

            //foreach (Department department in departmentCollection)
            //{
            //    GetDepartments(departmentCollection, department.DepartmentID);
            //}
        }
    }
}
