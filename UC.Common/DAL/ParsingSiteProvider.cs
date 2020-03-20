using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Net;
using System.Text;
using UC.DAL.ParsingClient.HtmlToXml;

namespace UC.DAL
{
    public abstract class ParsingSiteProvider : DataAccess
    {
        static private ParsingSiteProvider _instance = null;

        /// <summary>
        /// Возвращает ссылку на провайдера переданного в качестве параметра
        /// </summary>
        public static ParsingSiteProvider Instance(string providerType)
        {
            if (_instance == null)
                _instance = (ParsingSiteProvider)Activator.CreateInstance(
                   Type.GetType(providerType));
            return _instance;
        }

        public ParsingSiteProvider()
        {
            this.ConnectionString = Globals.Settings.Parsing.ConnectionString;
            this.EnableCaching = Globals.Settings.Parsing.EnableCaching;
            this.CacheDuration = Globals.Settings.Parsing.CacheDuration;
        }

        //методы для работы с товарами
        public abstract List<ParsingProductDetails> GetProducts(int catalogID);
        //public abstract int GetProductCount();
        //public abstract ParsingProductDetails GetProductByID(int productID);

        /// <summary>
        /// Возвращает указанную страницу в xml формате
        /// </summary>
        protected virtual XmlDocument GetPageXml(string pageURL)
        {
            return ConvertHtmlToXml(GetPage(pageURL));
        }

        /// <summary>
        /// Возвращает символьный поток представляющий html код указанной страницы
        /// </summary>
        protected virtual StreamReader GetPage(string pageURL)
        {
            //Инициализация запроса
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create(pageURL);
            myHttpWebRequest.UserAgent = "Mozilla/5.0 (compatible; strbot/2.1;)";
            myHttpWebRequest.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
            myHttpWebRequest.Headers.Add("Accept-Language", "ru");

            //получение ответа
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();

            //записываем полученные данные в поток
            Stream stream = myHttpWebResponse.GetResponseStream();

            //определяем кодировку
            Encoding encoding = Encoding.GetEncoding("windows-1251");
            if (myHttpWebResponse.CharacterSet == "koi-8")
                encoding = Encoding.GetEncoding("koi-8");
            if (myHttpWebResponse.CharacterSet == "utf-8")
                encoding = Encoding.GetEncoding("utf-8");
            if (myHttpWebResponse.CharacterSet == "unicode")
                encoding = Encoding.Unicode;

            //Читаем поток с определенной кодировкой
            StreamReader myStreamReader = new StreamReader(stream, encoding);

            return myStreamReader;
        }

        /// <summary>
        /// Возвращает преобразованную в xml html код переданный в потоке
        /// </summary>
        protected virtual XmlDocument ConvertHtmlToXml(StreamReader stream)
        {
            //Загружаем страницу в XmlDocument:
            SgmlReader reader = new SgmlReader();
            reader.InputStream = new StringReader(stream.ReadToEnd());
            XmlDocument document = new XhtmlDocument(reader.NameTable);
            document.Load(reader);

            return document;
        }
    }
}
