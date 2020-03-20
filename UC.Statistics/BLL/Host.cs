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
    public class Host : BaseStatistics
    {
        private string _ip = "";
        public string IP
        {
            get { return _ip; }
            set { _ip = value; }
        }

        private DateTime _firstDate = DateTime.Now;
        public DateTime FirstDate
        {
            get { return _firstDate; }
            set { _firstDate = value; }
        }

        private DateTime _lastDate = DateTime.Now;
        public DateTime LastDate
        {
            get { return _lastDate; }
            set { _lastDate = value; }
        }

        private int _sessionCount = 0;
        public int SessionCount
        {
            get { return _sessionCount; }
            set { _sessionCount = value; }
        }

        private int _requestCount = 0;
        public int RequestCount
        {
            get { return _requestCount; }
            set { _requestCount = value; }
        }

        public Host(string ip, DateTime firstDate, DateTime lastDate, int sessionCount, int requestCount)
        {
            this.IP = ip; 
            this.FirstDate = firstDate;
            this.LastDate = lastDate;
            this.SessionCount = sessionCount;
            this.RequestCount = requestCount;
        }

        /***********************************
        * ����������� ������
        ************************************/

        /// <summary>
        /// ���������� ��������� ���������� �� ����������� �����,
        /// ���������� ��������� � ���������� ��������, ����������� � ���� �������
        /// </summary>
        public static List<Host> GetHosts(string sortExpression, int startRowIndex, int maximumRows)
        {
            // �� ���������� �����������, ��������� ������� ������������ ���������� ����������

            if (sortExpression == null)
                sortExpression = "";

            List<Host> hosts = null;

            List<HostDetails> recordset = StatisticsProvider.Instance.GetHosts(sortExpression, GetPageIndex(startRowIndex, maximumRows), maximumRows);
            hosts = GetHostListFromHostDetailsList(recordset);

            return hosts;
        }

        /// <summary>
        /// ���������� ����� ���������� ������
        /// </summary>
        public static int GetHostCount()
        {
            // �� ���������� �����������, ��������� ������� ������������ ���������� ����������

            int hostCount = 0;

            hostCount = StatisticsProvider.Instance.GetHostCount();

            return hostCount;
        }

        /// <summary>
        /// ���������� ���� �� �� ������
        /// </summary>
        public static Host GetHostByIP(string IP)
        {
            Host host = null;

            host = GetHostFromHostDetails(StatisticsProvider.Instance.GetHostByIP(IP));

            return host;
        }

        /// <summary>
        /// ���������� ������ Host ����������� ������� �� HostDetails
        /// </summary>
        private static Host GetHostFromHostDetails(HostDetails record)
        {
            if (record == null)
                return null;
            else
            {
                return new Host(record.IP, record.FirstDate, record.LastDate, record.SessionCount, record.RequestCount);
            }
        }

        /// <summary>
        /// ���������� ������ �������� Host ����������� ������� �� ������ �������� HostDetails
        /// </summary>
        private static List<Host> GetHostListFromHostDetailsList(List<HostDetails> recordset)
        {
            List<Host> hosts = new List<Host>();
            foreach (HostDetails record in recordset)
                hosts.Add(GetHostFromHostDetails(record));
            return hosts;
        }
    }
}
