using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace UC.DAL
{
    public static class SiteProvider
    {
        public static ArticlesProvider Articles
        {
            get { return ArticlesProvider.Instance; }
        }

        public static PollsProvider Polls
        {
            get { return PollsProvider.Instance; }
        }

        public static NewslettersProvider Newsletters
        {
            get { return NewslettersProvider.Instance; }
        }

        public static ForumsProvider Forums
        {
            get { return ForumsProvider.Instance; }
        }

        public static StoreProvider Store
        {
            get { return StoreProvider.Instance; }
        }

        public static SearchProvider Search
        {
            get { return SearchProvider.Instance; }
        }

        //public static StatisticsProvider Statistics
        //{
        //    get { return StatisticsProvider.Instance; }
        //}

        public static ParsingProvider Parsing
        {
            get { return ParsingProvider.Instance; }
        }

        public static ParsingSiteProvider ParsingSite(string providerType)
        {
            return ParsingSiteProvider.Instance(providerType);
        }

        public static FrameworkProvider Framework
        {
            get { return FrameworkProvider.Instance; }
        }
    }
}
