using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace effetto.Sape
{
    [Serializable]
    public class SapeHost
    {
        public string Name { get; set; }
        public string OwnerId { get; set; }
        public string CheckCode { get; set; }
        public string ContextCheckCode { get; set; }
        public string Delimiter { get; set; }
        public DateTime LastSync { get; set; }
        public DateTime LastAccess { get; set; }
        public List<SapePage> Pages { get; set; }

        [NonSerialized]
        SapeConfigSection _config = null;
        private SapeConfigSection Config
        {
            get
            {
                if (_config==null)
                    _config = (SapeConfigSection)System.Configuration.ConfigurationManager.GetSection("effetto.Sape/SapeConfig");
                return _config;
            }
        }

        public SapeHost()
        {
            Pages = new List<SapePage>();
            Name = null;
            Delimiter = "";
            CheckCode = "";
            ContextCheckCode = "";
        }

        public bool IsThisHost(string host)
        {
            return Name.Trim().ToLower() == host.Trim().ToLower();
        }
        public SapePage GetPage()
        {
            SapeUrl url = new SapeUrl();
            return GetPage(url);
        }
        public SapePage GetPageOrDefault()
        {
            SapeUrl url = new SapeUrl();
            SapePage page = GetPage(url);
            if (page == null)
            {
                page = new SapePage();
                page.Url = new SapeUrl();
                page.Host = this;
            }
            return page;
        }
        public SapePage GetPage(SapeUrl url)
        {
            return GetPage(
                url,
                Config.UrlAnalyzer.Value,
                Config.QueryAnalyzer.Value,
                Config.QueryFilter.Value,
                Config.IgnoreCase.Value,
                Config.RussianNormalizer.Value);
        }

        public SapePage GetPage(SapeUrl url, Boolean analyzeUrl, Boolean analyzeQuery, Boolean useImportants, Boolean ignoreCase, Boolean normalizeRussian)
        {
            foreach (SapePage page in Pages)
                if (SapeUrl.Compare(url, page.Url, analyzeUrl, analyzeQuery, useImportants, ignoreCase)) return page;
            return null;
        }
    }
}
