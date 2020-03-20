using System;
using System.Data;
using System.Xml;
using System.Text;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace UC.DAL
{
    public abstract class FrameworkProvider : DataAccess
    {
        static private FrameworkProvider _instance = null;
        /// <summary>
        /// возвращает провайдера определенного в конфигурации
        /// </summary>
        static public FrameworkProvider Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (FrameworkProvider)Activator.CreateInstance(
                       Type.GetType(Globals.Settings.Framework.ProviderType));
                return _instance;
            }
        }

        public FrameworkProvider()
        {
            this.ConnectionString = Globals.Settings.Framework.ConnectionString;
        }

        // метод дл€ генерации карты сайта
        public abstract bool GetSiteMap(string siteUrl);

        // методы дл€ контрол€ и очистки Ѕƒ
        public abstract int GetAnonymousUsersCount();
        public abstract int GetInnactivesProfileCount();
        public abstract int GetWebEventsCount();
        public abstract bool DeleteAnonymousUsers(int addDays);
        public abstract bool DeleteInnactiveProfiles(int addDays);
        public abstract bool DeleteWebEvents();

        /// <summary>
        /// генерит файл sitemap.xml из полученных данных
        /// </summary>
        protected virtual bool GetSiteMapFromReader(XmlReader reader)
        {
            XmlDocument doc = new XmlDocument();

            StringBuilder str = new StringBuilder();
            str.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            str.Append("<urlset xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\">");

            try
            {
                while (reader.Read())
                {
                    if (reader.Name == "loc" &&
                        reader.NodeType == XmlNodeType.Element)
                    {
                        str.Append("<url>");
                        str.Append(reader.ReadOuterXml());
                        str.Append("</url>");
                    }
                }

                str.Append("</urlset>");

                doc.LoadXml(str.ToString());

                doc.Save(AppDomain.CurrentDomain.BaseDirectory+"\\sitemap.xml");

                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
