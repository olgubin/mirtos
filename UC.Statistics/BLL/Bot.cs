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
    public class Bot : BaseStatistics
    {
        private int _botID = 0;
        public int BotID
        {
            get { return _botID; }
            set { _botID = value; }
        }
        
        private int _searchEngineID = 0;
        public int SearchEngineID
        {
            get { return _searchEngineID; }
            set { _searchEngineID = value; }
        }

        private string _mask = "";
        public string Mask
        {
            get { return _mask; }
            set { _mask = value; }
        }

        public Bot(int botID, int searchEngineID, string mask)
        {
            this.BotID = botID;
            this.SearchEngineID = searchEngineID;
            this.Mask = mask;
        }

        /***********************************
        * ����������� ������
        ************************************/

        /// <summary>
        /// ��������� �������������� ������
        /// </summary>
        public static int GetBotID(string userAgent)
        {
            int ret = -1;
            List<Bot> bots = GetBots();
            foreach (Bot item in bots)
            {
                Regex mask = new Regex(item.Mask.Replace("%", "(.*?)"), RegexOptions.Compiled | RegexOptions.IgnoreCase);
                if (mask.IsMatch(userAgent == null ? "" : userAgent))
                {
                    ret = item.BotID;
                }
            }
            return ret;
        }

        /// <summary>
        /// ���������� ��������� ��������� �������
        /// </summary>
        public static List<Bot> GetBots()
        {
            List<Bot> bots = null;
            string key = "Statistics_Bots";

            if (BaseStatistics.Settings.EnableCaching && BizObject.Cache[key] != null)
            {
                bots = (List<Bot>)BizObject.Cache[key];
            }
            else
            {
                List<BotDetails> recordset = StatisticsProvider.Instance.GetBots();
                bots = GetBotListFromBotDetailsList(recordset);
                BaseStatistics.CacheData(key, bots);
            }
            return bots;
        }

        /// <summary>
        /// ���������� ������ Bot ����������� ������� �� BotDetails
        /// </summary>
        private static Bot GetBotFromBotDetails(BotDetails record)
        {
            if (record == null)
                return null;
            else
            {
                return new Bot(record.BotID, record.SearchEngineID, record.Mask);
            }
        }

        /// <summary>
        /// ���������� ������ �������� Bot ����������� ������� �� ������ �������� BotDetails
        /// </summary>
        private static List<Bot> GetBotListFromBotDetailsList(List<BotDetails> recordset)
        {
            List<Bot> bots = new List<Bot>();
            foreach (BotDetails record in recordset)
                bots.Add(GetBotFromBotDetails(record));
            return bots;
        }

    }
}
