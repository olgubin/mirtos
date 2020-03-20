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
        /// ���������� ������ �� ���������� ����������� � �������� ���������
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

        //������ ��� ������ � ��������
        public abstract List<ParsingProductDetails> GetProducts(int catalogID);
        //public abstract int GetProductCount();
        //public abstract ParsingProductDetails GetProductByID(int productID);

        /// <summary>
        /// ���������� ��������� �������� � xml �������
        /// </summary>
        protected virtual XmlDocument GetPageXml(string pageURL)
        {
            return ConvertHtmlToXml(GetPage(pageURL));
        }

        /// <summary>
        /// ���������� ���������� ����� �������������� html ��� ��������� ��������
        /// </summary>
        protected virtual StreamReader GetPage(string pageURL)
        {
            //������������� �������
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create(pageURL);
            myHttpWebRequest.UserAgent = "Mozilla/5.0 (compatible; strbot/2.1;)";
            myHttpWebRequest.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
            myHttpWebRequest.Headers.Add("Accept-Language", "ru");

            //��������� ������
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();

            //���������� ���������� ������ � �����
            Stream stream = myHttpWebResponse.GetResponseStream();

            //���������� ���������
            Encoding encoding = Encoding.GetEncoding("windows-1251");
            if (myHttpWebResponse.CharacterSet == "koi-8")
                encoding = Encoding.GetEncoding("koi-8");
            if (myHttpWebResponse.CharacterSet == "utf-8")
                encoding = Encoding.GetEncoding("utf-8");
            if (myHttpWebResponse.CharacterSet == "unicode")
                encoding = Encoding.Unicode;

            //������ ����� � ������������ ����������
            StreamReader myStreamReader = new StreamReader(stream, encoding);

            return myStreamReader;
        }

        /// <summary>
        /// ���������� ��������������� � xml html ��� ���������� � ������
        /// </summary>
        protected virtual XmlDocument ConvertHtmlToXml(StreamReader stream)
        {
            //��������� �������� � XmlDocument:
            SgmlReader reader = new SgmlReader();
            reader.InputStream = new StringReader(stream.ReadToEnd());
            XmlDocument document = new XhtmlDocument(reader.NameTable);
            document.Load(reader);

            return document;
        }
    }
}
