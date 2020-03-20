using System;
//using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Globalization;
using UC.BLL.Store;

namespace UC.Services
{
    /// <summary>
    /// YandexMarket service
    /// </summary>
    public static class YandexMarketService
    {
        /// <summary>
        /// Generate yml file
        /// </summary>
        /// <returns></returns>
        public static string GenerateYML(string url, string shopName, string company)
        {
            TextWriter stringWriter = new StringWriter();
            
            stringWriter.Write("<?xml version=\"1.0\" encoding=\"windows-1251\"?><!DOCTYPE yml_catalog SYSTEM \"shops.dtd\">");
            //stringWriter.Write("<?xml version=\"1.0\" encoding=\"windows-1251\"?>");

            XmlTextWriter writer = new XmlTextWriter(stringWriter);
            writer.WriteStartElement("yml_catalog");
            writer.WriteAttributeString("date", DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
            writer.WriteStartElement("shop");

            writer.WriteElementString("name", shopName);
            writer.WriteElementString("company", company);
            writer.WriteElementString("url", url);
            writer.WriteStartElement("currencies");
            writer.WriteStartElement("currency");
            writer.WriteAttributeString("id", "RUR");
            writer.WriteAttributeString("rate", "1");
            writer.WriteEndElement(); //currency
            writer.WriteEndElement(); //currencies

            //добавление разделов

            writer.WriteStartElement("categories");

            DepartmentCollection departmentCollection = new DepartmentCollection();

            GetDepartments(departmentCollection, 0); //разделы каталогов
            //GetDepartments(writer, 0); //разделы каталогов

            foreach (Department department in departmentCollection)
            {
                writer.WriteStartElement("category");
                writer.WriteAttributeString("id", department.DepartmentID.ToString());
                if (department.ParentDepartmentID > 0)
                    writer.WriteAttributeString("parentId", department.ParentDepartmentID.ToString());

                writer.WriteString(department.Name + (!department.Published ? " (NV)" : ""));
                writer.WriteEndElement();
            }

            writer.WriteEndElement(); //categories

            //добавление товаров

            writer.WriteStartElement("offers");

            ProductCollection products = ProductManager.GetAllProducts(false);

            CultureInfo ci = new CultureInfo("en-us");

            foreach (Product item in products)
            {
                bool exist = false;

                foreach (Department item1 in departmentCollection)
                {
                    if (item1.DepartmentID == item.ProductDepartments[0].DepartmentID)
                    {
                        exist = true;
                        break;
                    }
                }

                if (exist && item.UnitPrice > 0)
                {
                    writer.WriteStartElement("offer");
                    writer.WriteAttributeString("id", item.ProductID.ToString());
                    //writer.WriteAttributeString("type", "vendor.model");

                    if (item.UnitsInStock > 0)
                        writer.WriteAttributeString("available", "true");
                    else
                        writer.WriteAttributeString("available", "false");

                    writer.WriteElementString("url", url+"ShowProduct.aspx?ID=" + item.ProductID.ToString());
                    writer.WriteElementString("price", CurrencyManager.ConvertCurrency(item.FinalPrice, item.Currency, CurrencyManager.WorkingCurrency).ToString("F2", ci));
                    writer.WriteElementString("currencyId", "RUR");
                    writer.WriteElementString("categoryId", item.ProductDepartments[0].DepartmentID.ToString());

                    if (!String.IsNullOrEmpty(item.FullImageUrl))
                        writer.WriteElementString("picture", item.FullImageUrl.Replace("~/", url));

                    //if (!String.IsNullOrEmpty(item.SmallImageUrl))
                    //{
                    //    //writer.WriteElementString("picture", item.SmallImageUrl.Replace("~/",url));
                    //    writer.WriteElementString("picture", url + "smallimage.aspx?ID=" + item.ProductID);
                    //}

                    writer.WriteElementString("delivery", "true");
                    writer.WriteElementString("name", item.Title);
                    writer.WriteElementString("vendor", item.Manufacturer.Title);
                    //writer.WriteElementString("model", item.Title);

                    writer.WriteEndElement();
                }
            }

            writer.WriteEndElement(); //offers

            writer.WriteEndElement(); //shop
            writer.WriteEndElement(); //yml_catalog

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
                if (department.ParentDepartmentID>0)
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
