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
using System.Text.RegularExpressions;
using UC.DAL;

namespace UC.BLL.Statistics
{
    public class Keyword : BaseStatistics
    {
        private int _keywordID = 0;
        public int KeywordID
        {
            get { return _keywordID; }
            set { _keywordID = value; }
        }

        private string _keywords = "";
        public string Keywords
        {
            get { return _keywords; }
            set { _keywords = value; }
        }

        public Keyword(int keywordID, string keywords)
        {
            this.KeywordID = keywordID;
            this.Keywords = keywords;
        }

        /***********************************
        * Статические методы
        ************************************/

        /// <summary>
        /// Поиск и получение идентификатора ключевого слова
        /// </summary>
        public static int GetKeywordID(HttpContext context, string keywordMask)
        {
            int ret = -1;
            string keyword = "";
            foreach (string param in HttpUtility.UrlDecode(context.Request.UrlReferrer.Query,System.Text.Encoding.UTF8).Split(new char[] { '?', '&' }))
            {
                if (param.StartsWith(keywordMask))
                {
                    keyword = param.Replace(keywordMask, "");
                    break;
                }
            }

            // определение что кодировка не UTF8 если присутстуют символовы 65533
            int encoding = 0;
            for (int i = 0; i < keyword.Length; i++)
            {
                Char ch1 = keyword[i];
                if (ch1 == 65533)
                {
                    encoding += 1;
                    if (encoding > 3) break;
                }
            }

            //if (keyword.Contains("????"))
            //if (!Regex.IsMatch(keyword,@"[а-яА-Яa-zA-Z]"))
            if (encoding > 3)
            {
                keyword = "";
                foreach (string param in HttpUtility.UrlDecode(context.Request.UrlReferrer.Query, System.Text.Encoding.Default).Split(new char[] { '?', '&' }))
                {
                    if (param.StartsWith(keywordMask))
                    {
                        keyword = param.Replace(keywordMask, "");
                        break;
                    }
                }
            }

            List<Keyword> keywords = GetKeywords();

            foreach (Keyword item in keywords)
            {
                if (keyword.ToLower() == item.Keywords)
                {
                    ret = item.KeywordID;
                    break;
                }
            }
            if (ret == -1) { ret = InsertKeyword(keyword.ToLower()); }
            return ret;
        }

        /// <summary>
        /// Добавление поисковой фразы
        /// </summary>
        public static int InsertKeyword(string keyword)
        {
            KeywordDetails record = new KeywordDetails(0, keyword);
            int ret = StatisticsProvider.Instance.InsertKeyword(record);
            BizObject.PurgeCacheItems("statistics_keyword");
            return ret;
        }



        /// <summary>
        /// Возвращает коллекцию поисковых фраз
        /// </summary>
        public static List<Keyword> GetKeywords()
        {
            List<Keyword> keywords = null;
            string key = "Statistics_Keywords";

            if (BaseStatistics.Settings.EnableCaching && BizObject.Cache[key] != null)
            {
                keywords = (List<Keyword>)BizObject.Cache[key];
            }
            else
            {
                List<KeywordDetails> recordset = StatisticsProvider.Instance.GetKeywords();
                keywords = GetKeywordListFromKeywordDetailsList(recordset);
                BaseStatistics.CacheData(key, keywords);
            }
            return keywords;
        }

        /// <summary>
        /// Возвращает объект Keyword заполненный данными из KeywordDetails
        /// </summary>
        private static Keyword GetKeywordFromKeywordDetails(KeywordDetails record)
        {
            if (record == null)
                return null;
            else
            {
                return new Keyword(record.KeywordID, record.Keywords);
            }
        }

        /// <summary>
        /// Возвращает список объектов Keyword заполненный данными из списка объектов KeywordDetails
        /// </summary>
        private static List<Keyword> GetKeywordListFromKeywordDetailsList(List<KeywordDetails> recordset)
        {
            List<Keyword> keywords = new List<Keyword>();
            foreach (KeywordDetails record in recordset)
                keywords.Add(GetKeywordFromKeywordDetails(record));
            return keywords;
        }
    }
}
