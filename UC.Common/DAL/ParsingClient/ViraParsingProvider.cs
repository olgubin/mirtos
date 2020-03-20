using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Web.Caching;
using System.Xml;
using System.Xml.XPath;
using System.Text;
using System.Text.RegularExpressions;

namespace UC.DAL.ParsingClient
{
    public class ViraParsingProvider : ParsingSiteProvider
    {
        /// <summary>
        /// возвращает указанное количество отсортированных товаров из БД каталога
        /// </summary>
        public override List<ParsingProductDetails> GetProducts(int catalogID)
        {
            List<ParsingProductDetails> products = new List<ParsingProductDetails>();


            //Собираем первый уровень ссылок и первый уровень каталога
            XmlDocument document = GetPageXml("http://shop.vira.ru");

            List<ParsingDepartmentDetails> department = new List<ParsingDepartmentDetails>();

            XmlNodeList links = document.SelectNodes("//a[@class='divMain']");
            foreach (XmlNode item in links)
            {
                //department.Add(new ParsingDepartmentDetails(0, new List<ParsingDepartmentDetails>(), item.ChildNodes[1].InnerText, "http://shop.vira.ru" + item.Attributes[2].Value));
                //для паблиш версии в ней xml парсер по дркгому устанавливает окончание незакрытого тега в итоге дочерний узел 1 а не 2 как в исходной
                department.Add(new ParsingDepartmentDetails(0, new List<ParsingDepartmentDetails>(), item.ChildNodes[0].InnerText, "http://shop.vira.ru" + item.Attributes[2].Value));
            }



            //Переходим по каждой ссылке > загружаем ссылку > выделяем подрубрики
            foreach (ParsingDepartmentDetails item in department)
            {
                item.Departments = GetSubSections(item.Url, ref products, item.Title, catalogID);

                //проверочный для одного узла
                //break;
            }

            //Проверочный
            //department[1].Departments = GetSubSections("http://shop.vira.ru/catalog-50-5050-0-0.html", ref products, "Проверочный", catalogID);




            for (int i = 0; i < products.Count; i++)
            {
                products[i] = ParseProductShort(products[i]);
            }

            //foreach (ParsingProductDetails product in products)
            //{
            //    product = ParseProductShort(product);
            //}

            return products;
        }

        /// <summary>
        /// Парсит подкатегории
        /// </summary>
        private List<ParsingDepartmentDetails> GetSubSections(string url, ref List<ParsingProductDetails> products, string departmentTitle, int catalogID)
        {
            List<ParsingDepartmentDetails> department = new List<ParsingDepartmentDetails>();

            XmlDocument document = GetPageXml(url);

            //из-за того, что у них могут быть товары еще и в корневой рубрике помимо подрубрик нужно парсить каждую страницу
            ParseProducts(document, ref products, departmentTitle, catalogID);

            XmlNodeList links = document.SelectNodes("//a[@class='big']");

            if (links.Count > 0)
            {
                foreach (XmlNode item in links)
                {
                    ParsingDepartmentDetails subsection = new ParsingDepartmentDetails(0, new List<ParsingDepartmentDetails>(), item.ChildNodes[0].InnerText, "http://shop.vira.ru" + item.Attributes[2].Value);
                    subsection.Departments = GetSubSections(subsection.Url, ref products, departmentTitle + " > " + subsection.Title, catalogID);
                    department.Add(subsection);

                    //для ускорения отладки
                    //break;
                }
            }

            return department;
        }

        /// <summary>
        /// Парсит страницы товаров
        /// </summary>
        private void ParseProducts(XmlDocument document, ref List<ParsingProductDetails> products, string departmentTitle, int catalogID)
        {
            //Получаем узлы содержащие описание товаров на текущей странице
            XmlNodeList productnodes = document.SelectNodes("//tr/td[@class='descr']/parent::*");

            ParsingProductDetails parsingProduct = null;

            int index = -1;

            foreach (XmlNode productnode in productnodes)
            {
                parsingProduct = ParseProductShort(productnode, departmentTitle, catalogID, products.Count);

                //..ищем если такой товар уже есть заменяем его, если нет добавляем его
                index = products.FindIndex(delegate(ParsingProductDetails product) { return (product.SKU == parsingProduct.SKU); });
                if (index >= 0)
                {
                    products[index] = parsingProduct;
                }
                else
                {
                    products.Add(parsingProduct);
                }
            }

            //получаем ссылки на другие страницы с описанием товаров
            XmlNodeList pages = document.SelectNodes("//nobr/a[contains(@href,'catalog')]");

            //если страницы еще есть, то проходим по ссылкам
            int i = 1;
            foreach (XmlNode page in pages)
            {
                document = GetPageXml("http://shop.vira.ru" + page.Attributes[0].Value);

                //Получаем узлы содержащие описание товаров на текущей странице
                XmlNodeList productnodes2 = document.SelectNodes("//tr/td[@class='descr']/parent::*");

                foreach (XmlNode productnode in productnodes2)
                {
                    parsingProduct = ParseProductShort(productnode, departmentTitle, catalogID, products.Count);

                    //..ищем если такой товар уже есть заменяем его, если нет добавляем его
                    index = products.FindIndex(delegate(ParsingProductDetails product) { return (product.SKU == parsingProduct.SKU); });
                    if (index >= 0)
                    {
                        products[index] = parsingProduct;
                    }
                    else
                    {
                        products.Add(parsingProduct);
                    }
                }

                i += 1;
                if (i > pages.Count / 2) { break; }
            }
        }

        /// <summary>
        /// Парсит краткое описание товара
        /// </summary>
        private ParsingProductDetails ParseProductShort(XmlNode node, string departmentTitle, int catalogID, int id)
        {
            ParsingProductDetails product = null;

            string smallImageUrl = "";
            string url = "";
            string title = "";
            string shortDescr = "";
            decimal price = 0.0m;
            string pricecount = "";
            string sku = "";

            #region Исправление: удаление галимого тега О

            string temp = node.OuterXml;
            temp = Regex.Replace(temp, "<o:p>", "");
            temp = Regex.Replace(temp, "</o:p>", "");

            #endregion

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(temp);

            XmlNodeList smallimagenodes = doc.SelectNodes("//img");
            foreach (XmlNode smallimagenode in smallimagenodes)
            {
                smallImageUrl = "http://shop.vira.ru/" + smallimagenode.Attributes[0].Value;
            }

            XmlNodeList titlenodes = doc.SelectNodes("//a[@class='verybig']");
            foreach (XmlNode titlenode in titlenodes)
            {
                url = "http://shop.vira.ru/" + titlenode.Attributes[0].Value;
                title = titlenode.ChildNodes[0].InnerText;
            }

            Regex r = new Regex("tovar-([0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            for (Match m = r.Match(url); m.Success; m = m.NextMatch())
            {
                sku = m.Groups[1].ToString();
                break;
            }

            XmlNodeList shortdescrnodes = doc.SelectNodes("//td[@class='descr']");
            foreach (XmlNode shortdescrnode in shortdescrnodes)
            {
                shortDescr = shortdescrnode.LastChild.InnerText;
            }

            XmlNodeList pricenodes = doc.SelectNodes("//form/td/span[@class='divMain']");
            foreach (XmlNode pricenode in pricenodes)
            {
                price = Convert.ToDecimal(pricenode.InnerText.Replace(".", ","));
            }

            XmlNodeList pricecountnodes = doc.SelectNodes("//form/td/strong");
            foreach (XmlNode pricecountnode in pricecountnodes)
            {
                pricecount = pricecountnode.InnerText;
            }

            product = new ParsingProductDetails(id, 0, url, catalogID, DateTime.Now, departmentTitle, title, shortDescr, "", sku, price, 0, 0, smallImageUrl, "", 0, false, false, false, false, "");

            return product;
        }

        /// <summary>
        /// Парсит полное описание товара
        /// </summary>
        private ParsingProductDetails ParseProductShort(ParsingProductDetails product)
        {
            string fullImageUrl = "";
            string longDescr = "";
            string error = "";

            //Загружаем страницу с полным описанием
            XmlDocument doc = GetPageXml(product.Url);

            //парсим артикул, полное описание и ссылку на большую картинку
            XmlNodeList fullimagenodes = doc.SelectNodes("//td/img[contains(@src,'ppic')]");
            foreach (XmlNode fullimagenode in fullimagenodes)
            {
                fullImageUrl = "http://shop.vira.ru/" + fullimagenode.Attributes[0].Value;
            }

            //Regex r = new Regex("Артикул:\\s*([0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            //XmlNode skunode = doc.SelectSingleNode("//td/span[@class='divHead']");
            //for (Match m = r.Match(skunode.ParentNode.InnerText); m.Success; m = m.NextMatch())
            //{
            //    sku = m.Groups[1].ToString();
            //    break;
            //}

            XmlNode longdescrnodes = doc.SelectSingleNode("//form[@target='shops_popup']");
            if (longdescrnodes != null)
            {
                XPathNavigator xnav = longdescrnodes.CreateNavigator();

                xnav.MoveToNext();
                xnav.MoveToNext();
                if (xnav.Name == "br" & xnav.IsEmptyElement) { xnav.MoveToNext(); }
                if (xnav.Name == "br" & xnav.IsEmptyElement) { xnav.MoveToNext(); }

                StringBuilder str = new StringBuilder("");
                do
                {
                    if (xnav.Name == "hr") { break; }
                    try
                    {
                        str.Append(xnav.OuterXml);
                    }
                    catch (Exception ex)
                    {
                        //throw new ApplicationException("Missing parameter on the querystring.");
                        error = ex.Message.ToString();
                        break;
                    }
                } while (xnav.MoveToNext());

                longDescr = str.ToString();
            }

            product.FullImageUrl = fullImageUrl;
            product.LongDescription = longDescr;
            product.Error = error;

            return product;
        }
    }
}
