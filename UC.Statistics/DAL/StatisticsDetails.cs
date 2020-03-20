using System;
using System.Data;
using System.Configuration;
using System.Web;

namespace UC.DAL
{
    public class StatisticsDetails
    {
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

        private int _sessionsCount = 0;
        public int SessionsCount
        {
            get { return _sessionsCount; }
            set { _sessionsCount = value; }
        }

        private int _hostsCount = 0;
        public int HostsCount
        {
            get { return _hostsCount; }
            set { _hostsCount = value; }
        }

        private int _uniqueHostsCount = 0;
        public int UniqueHostsCount
        {
            get { return _uniqueHostsCount; }
            set { _uniqueHostsCount = value; }
        }

        private int _sitesCount = 0;
        public int SitesCount
        {
            get { return _sitesCount; }
            set { _sitesCount = value; }
        }

        private int _searchCount = 0;
        public int SearchCount
        {
            get { return _searchCount; }
            set { _searchCount = value; }
        }

        private int _hitsCount = 0;
        public int HitsCount
        {
            get { return _hitsCount; }
            set { _hitsCount = value; }
        }

        private int _botsCount = 0;
        public int BotsCount
        {
            get { return _botsCount; }
            set { _botsCount = value; }
        }

        private int _botsRequestsCount = 0;
        public int BotsRequestsCount
        {
            get { return _botsRequestsCount; }
            set { _botsRequestsCount = value; }
        }

        public StatisticsDetails() { }

        public StatisticsDetails(DateTime firstDate, DateTime lastDate, int sessionsCount, int hostsCount, int uniqueHostsCount,
                                 int sitesCount, int searchCount, int hitsCount, int botsCount, int botsRequestsCount)
        {
            this.FirstDate = firstDate;
            this.LastDate = lastDate;
            this.SessionsCount = sessionsCount;
            this.HostsCount = hostsCount;
            this.UniqueHostsCount = uniqueHostsCount;
            this.SitesCount = sitesCount;
            this.SearchCount = searchCount;
            this.HitsCount = hitsCount;
            this.BotsCount = botsCount;
            this.BotsRequestsCount = botsRequestsCount;
        }
    }
}
