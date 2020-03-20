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
using UC.DAL;

namespace UC.BLL.Parsing
{
    public class ParsingCatalog : BaseParsing
    {
        private int _id = 0;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _title = "";
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private string _siteProviderType = "";
        public string SiteProviderType
        {
            get { return _siteProviderType; }
            set { _siteProviderType = value; }
        }

        private DateTime _updateDate = DateTime.Now;
        public DateTime UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = value; }
        }

        public ParsingCatalog(int id, string title, string siteProviderType, DateTime updateDate)
        {
            this.ID = id;
            this.Title = title;
            this.SiteProviderType = siteProviderType;
            this.UpdateDate = updateDate;
        }

        /***********************************
        * Статические методы
        ************************************/

        /// <summary>
        /// Возвращает коллекцию каталогов
        /// </summary>
        public static List<ParsingCatalog> GetCatalogs()
        {
            List<ParsingCatalog> catalogs = null;
            string key = "Parsing_Catalogs";

            if (BaseParsing.Settings.EnableCaching && BizObject.Cache[key] != null)
            {
                catalogs = (List<ParsingCatalog>)BizObject.Cache[key];
            }
            else
            {
                List<ParsingCatalogDetails> recordset = SiteProvider.Parsing.GetCatalogs();
                catalogs = GetParsingCatalogListFromParsingCatalogDetailsList(recordset);
                BaseParsing.CacheData(key, catalogs);
            }
            return catalogs;
        }

        /// <summary>
        /// Возвращает каталог по его ID
        /// </summary>
        public static ParsingCatalog GetCatalogByID(int catalogID)
        {
            ParsingCatalog catalog = null;
            string key = "Parsing_Catalog_" + catalogID.ToString();

            if (BaseParsing.Settings.EnableCaching && BizObject.Cache[key] != null)
            {
                catalog = (ParsingCatalog)BizObject.Cache[key];
            }
            else
            {
                catalog = GetParsingCatalogFromParsingCatalogDetails(SiteProvider.Parsing.GetCatalogByID(catalogID));
                BaseParsing.CacheData(key, catalog);
            }
            return catalog;
        }

        /// <summary>
        /// Обновляет существующий каталог
        /// </summary>
        public static bool UpdateCatalog(int ID, string title, string siteProviderType)
        {
            ParsingCatalogDetails record = new ParsingCatalogDetails(ID, title, siteProviderType, DateTime.Now);
            bool ret = SiteProvider.Parsing.UpdateCatalog(record);
            BizObject.PurgeCacheItems("parsing_catalog");
            return ret;
        }

        /// <summary>
        /// удаляет существующий каталог
        /// </summary>
        public static bool DeleteCatalog(int ID)
        {
            bool ret = SiteProvider.Parsing.DeleteCatalog(ID);
            new RecordDeletedEvent("parsingcatalog", ID, null).Raise();
            BizObject.PurgeCacheItems("parsing_catalog");
            return ret;
        }

        /// <summary>
        /// создает новый каталог
        /// </summary>
        public static int InsertCatalog(string title, string siteProviderType)
        {
            ParsingCatalogDetails record = new ParsingCatalogDetails(0, title, siteProviderType, DateTime.Now);
            int ret = SiteProvider.Parsing.InsertCatalog(record);
            BizObject.PurgeCacheItems("parsing_catalog");
            return ret;
        }

        /// <summary>
        /// Изменяет дату обновления каталога
        /// </summary>
        public static bool RefreshCatalog(int ID)
        {
            bool ret = SiteProvider.Parsing.RefreshCatalog(ID, DateTime.Now);
            BizObject.PurgeCacheItems("parsing_catalog");
            return ret;
        }

        /// <summary>
        /// Возвращает тип провайдера каталога по его ID
        /// </summary>
        public static string GetProviderTypeByID(int catalogID)
        {
            ParsingCatalog catalog = null;
            string key = "Parsing_Catalog_" + catalogID.ToString();

            if (BaseParsing.Settings.EnableCaching && BizObject.Cache[key] != null)
            {
                catalog = (ParsingCatalog)BizObject.Cache[key];
            }
            else
            {
                catalog = GetParsingCatalogFromParsingCatalogDetails(SiteProvider.Parsing.GetCatalogByID(catalogID));
                BaseParsing.CacheData(key, catalog);
            }
            return catalog.SiteProviderType;
        }

        /// <summary>
        /// Возвращае объект ParsingCatalog заполненный данными из объекта ParsingCatalogDetails
        /// </summary>
        private static ParsingCatalog GetParsingCatalogFromParsingCatalogDetails(ParsingCatalogDetails record)
        {
            if (record == null)
                return null;
            else
            {
                return new ParsingCatalog(record.ID, record.Title, record.SiteProviderType, record.UpdateDate);
            }
        }

        /// <summary>
        /// Возвращает список объектов ParsingCatalog заполненный данными из списка объектов ParsingCatalogDetails
        /// </summary>
        private static List<ParsingCatalog> GetParsingCatalogListFromParsingCatalogDetailsList(List<ParsingCatalogDetails> recordset)
        {
            List<ParsingCatalog> catalogs = new List<ParsingCatalog>();
            foreach (ParsingCatalogDetails record in recordset)
                catalogs.Add(GetParsingCatalogFromParsingCatalogDetails(record));
            return catalogs;
        }
    }
}