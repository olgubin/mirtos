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

namespace UC.BLL.Statistics
{
    public class StatisticsReport : BaseStatistics
    {
        public StatisticsReport() { }

        /***********************************
        * ����������� ������
        ************************************/

        /// <summary>
        /// ���������� ���������� �� ���� ������
        /// </summary>
        public static StatisticsDetails ReportStatisticsAll()
        {
            // �� ���������� �����������, ��������� ������� ������������ ���������� ����������

            return StatisticsProvider.Instance.ReportStatistics(DateTime.Parse("2008-01-31"), DateTime.Now);
        }

        /// <summary>
        /// ���������� ���������� �� �� ���� �� 7 ����
        /// </summary>
        public static List<StatisticsDetails> ReportStatisticsDaily()
        {
            // ���������� �����������, ��� ���� ������ �� ���������� ������� ����

            List<StatisticsDetails> statistics = new List<StatisticsDetails>();

            for (int i = 0; i < 7; i++)
            {
                DateTime day = DateTime.Now.AddDays(-i);

                string key = "Statistics_Report_" + day.ToShortDateString() + "_" + day.ToShortDateString();

                if (BaseStatistics.Settings.EnableCaching && BizObject.Cache[key] != null)
                {
                    statistics.Add((StatisticsDetails)BizObject.Cache[key]);
                }
                else
                {
                    StatisticsDetails result = StatisticsProvider.Instance.ReportStatistics(day, day);

                    statistics.Add(result);

                    if (day.Date < DateTime.Now.Date)
                    {
                        BaseStatistics.CacheData(key, result);
                    }
                }
            }

            return statistics;
        }

        /// <summary>
        /// ���������� ���������� �� ������� � ������� 7 ������
        /// </summary>
        public static List<StatisticsDetails> ReportStatisticsWeekly()
        {
            // ���������� �����������, ��� ���� ������ �� ���������� ������� ����

            List<StatisticsDetails> statistics = new List<StatisticsDetails>();

            DateTime begin = DateTime.Now;
            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    begin = DateTime.Now;
                    break;
                case DayOfWeek.Tuesday:
                    begin = DateTime.Now.AddDays(-1);
                    break;
                case DayOfWeek.Wednesday:
                    begin = DateTime.Now.AddDays(-2);
                    break;
                case DayOfWeek.Thursday:
                    begin = DateTime.Now.AddDays(-3);
                    break;
                case DayOfWeek.Friday:
                    begin = DateTime.Now.AddDays(-4);
                    break;
                case DayOfWeek.Saturday:
                    begin = DateTime.Now.AddDays(-5);
                    break;
                case DayOfWeek.Sunday:
                    begin = DateTime.Now.AddDays(-6);
                    break;                    
            }

            for (int i = 0; i < 7; i++)
            {
                DateTime firstDay = begin.AddDays(-i * 7);
                DateTime lastDay = firstDay.AddDays(6);

                string key = "Statistics_Report_" + firstDay.ToShortDateString() + "_" + lastDay.ToShortDateString();

                if (BaseStatistics.Settings.EnableCaching && BizObject.Cache[key] != null)
                {
                    statistics.Add((StatisticsDetails)BizObject.Cache[key]);
                }
                else
                {
                    StatisticsDetails result = StatisticsProvider.Instance.ReportStatistics(firstDay, lastDay);

                    statistics.Add(result);

                    if (!(firstDay.Date < DateTime.Now.Date &  DateTime.Now.Date < lastDay.Date))
                    {
                        BaseStatistics.CacheData(key, result);
                    }
                }
            }

            return statistics;
        }

        /// <summary>
        /// ���������� ���������� �� ������� � ������� 7 �������
        /// </summary>
        public static List<StatisticsDetails> ReportStatisticsMonthly()
        {
            // ���������� �����������, ��� ���� ������ �� ���������� ������� ����

            List<StatisticsDetails> statistics = new List<StatisticsDetails>();

            for (int i = 0; i < 7; i++)
            {
                DateTime firstDay = new DateTime(DateTime.Now.AddMonths(-i).Year,DateTime.Now.AddMonths(-i).Month,1);
                DateTime lastDay = firstDay.AddDays(DateTime.DaysInMonth(firstDay.Year,firstDay.Month)-1);

                string key = "Statistics_Report_" + firstDay.ToShortDateString() + "_" + lastDay.ToShortDateString();

                if (BaseStatistics.Settings.EnableCaching && BizObject.Cache[key] != null)
                {
                    statistics.Add((StatisticsDetails)BizObject.Cache[key]);
                }
                else
                {
                    StatisticsDetails result = StatisticsProvider.Instance.ReportStatistics(firstDay, lastDay);

                    statistics.Add(result);

                    if (!(firstDay.Date < DateTime.Now.Date & DateTime.Now.Date < lastDay.Date))
                    {
                        BaseStatistics.CacheData(key, result);
                    }
                }
            }

            return statistics;
        }

        /// <summary>
        /// ���������� ���������� �������� �� ������� ����
        /// </summary>
        public static List<ReportPageDetails> ReportPages(string sortExpression, int startRowIndex, int maximumRows)
        {
            if (sortExpression == null)
                sortExpression = "";

            // �� ���������� �����������, ��������� ������� ������������ ���������� ����������

            List<ReportPageDetails> pages = StatisticsProvider.Instance.ReportPages(sortExpression, GetPageIndex(startRowIndex, maximumRows), maximumRows);

            return pages;
        }

        /// <summary>
        /// ���������� ����� ���������� ������� � ����������
        /// </summary>
        public static int ReportPagesCount()
        {
            // �� ���������� �����������, ��������� ������� ������������ ���������� ����������

            int �ount = 0;

            �ount = StatisticsProvider.Instance.ReportPagesCount();

            return �ount;
        }

        /// <summary>
        /// ���������� ������� �� ��������� ������
        /// </summary>
        public static List<ReportRequestDetails> ReportRequestsByUrl(string sortExpression, int startRowIndex, int maximumRows, string url)
        {
            if (sortExpression == null)
                sortExpression = "";

            // �� ���������� �����������, ��������� ������� ������������ ���������� ����������

            List<ReportRequestDetails> request = StatisticsProvider.Instance.ReportRequestsByUrl(sortExpression, GetPageIndex(startRowIndex, maximumRows), maximumRows, url);

            return request;
        }

        /// <summary>
        /// ���������� ����� ���������� ������� ��� ������� �� ��������� ������
        /// </summary>
        public static int ReportRequestsByUrlCount(string url)
        {
            // �� ���������� �����������, ��������� ������� ������������ ���������� ����������

            int �ount = 0;

            �ount = StatisticsProvider.Instance.ReportRequestsByUrlCount(url);

            return �ount;
        }

        /// <summary>
        /// ���������� ������� �� ���������� �����
        /// </summary>
        public static List<ReportRequestDetails> ReportRequestsByIP(string sortExpression, int startRowIndex, int maximumRows, string ip)
        {
            if (sortExpression == null)
                sortExpression = "";

            // �� ���������� �����������, ��������� ������� ������������ ���������� ����������

            List<ReportRequestDetails> request = StatisticsProvider.Instance.ReportRequestsByIP(sortExpression, GetPageIndex(startRowIndex, maximumRows), maximumRows, ip);

            return request;
        }

        /// <summary>
        /// ���������� ����� ���������� �������� �� ���������� �����
        /// </summary>
        public static int ReportRequestsByIPCount(string ip)
        {
            // �� ���������� �����������, ��������� ������� ������������ ���������� ����������

            int �ount = 0;

            �ount = StatisticsProvider.Instance.ReportRequestsByIPCount(ip);

            return �ount;
        }

        /// <summary>
        /// ���������� ������� �� ������
        /// </summary>
        public static List<ReportRequestDetails> ReportRequestsByDate(string sortExpression, int startRowIndex, int maximumRows, DateTime firstDate, DateTime lastDate)
        {
            if (sortExpression == null)
                sortExpression = "";

            // �� ���������� �����������, ��������� ������� ������������ ���������� ����������

            List<ReportRequestDetails> requests = StatisticsProvider.Instance.ReportRequestsByDate(sortExpression, GetPageIndex(startRowIndex, maximumRows), maximumRows, firstDate, lastDate);

            return requests;
        }

        /// <summary>
        /// ���������� ����� ���������� �������� �� ������
        /// </summary>
        public static int ReportRequestsByDateCount(DateTime firstDate, DateTime lastDate)
        {
            // �� ���������� �����������, ��������� ������� ������������ ���������� ����������

            int �ount = 0;

            �ount = StatisticsProvider.Instance.ReportRequestsByDateCount(firstDate, lastDate);

            return �ount;
        }

        /// <summary>
        /// ���������� �������� � ����������� �� ������
        /// </summary>
        public static List<ReportSearchDetails> ReportSearchesByDate(string sortExpression, int startRowIndex, int maximumRows, DateTime firstDate, DateTime lastDate)
        {
            if (sortExpression == null)
                sortExpression = "";

            // �� ���������� �����������, ��������� ������� ������������ ���������� ����������

            List<ReportSearchDetails> searches = StatisticsProvider.Instance.ReportSearchesByDate(sortExpression, GetPageIndex(startRowIndex, maximumRows), maximumRows, firstDate, lastDate);

            return searches;
        }

        /// <summary>
        /// ���������� ����� ���������� ��������� � ����������� �� ������
        /// </summary>
        public static int ReportSearchesByDateCount(DateTime firstDate, DateTime lastDate)
        {
            // �� ���������� �����������, ��������� ������� ������������ ���������� ����������

            int �ount = 0;

            �ount = StatisticsProvider.Instance.ReportSearchesByDateCount(firstDate, lastDate);

            return �ount;
        }

        /// <summary>
        /// ���������� �������� � ������ ������
        /// </summary>
        public static List<ReportSiteDetails> ReportSitesByDate(string sortExpression, int startRowIndex, int maximumRows, DateTime firstDate, DateTime lastDate)
        {
            if (sortExpression == null)
                sortExpression = "";

            // �� ���������� �����������, ��������� ������� ������������ ���������� ����������

            List<ReportSiteDetails> sites = StatisticsProvider.Instance.ReportSitesByDate(sortExpression, GetPageIndex(startRowIndex, maximumRows), maximumRows, firstDate, lastDate);

            return sites;
        }

        /// <summary>
        /// ���������� ����� ���������� ��������� � ����������� �� ������
        /// </summary>
        public static int ReportSitesByDateCount(DateTime firstDate, DateTime lastDate)
        {
            // �� ���������� �����������, ��������� ������� ������������ ���������� ����������

            int �ount = 0;

            �ount = StatisticsProvider.Instance.ReportSitesByDateCount(firstDate, lastDate);

            return �ount;
        }
    }
}
