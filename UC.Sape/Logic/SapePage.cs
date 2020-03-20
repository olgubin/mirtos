using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace effetto.Sape
{
    [Serializable]
    public class SapePage
    {
        //public String RawUrl { get; set; }
        public SapeUrl Url { get; set; }
        public SapeHost Host { get; set; }

        public List<SapeLinkBase> Links { get; set; }


        public SapePage()
        {
            Links = new List<SapeLinkBase>();
        }

        private Dictionary<String, SapeContextLink> linksWithStrings;
        private void PrecessKeys()
        {
            linksWithStrings = new Dictionary<String, SapeContextLink>();
            List<SapeContextLink> links = GetContextLinks();
            foreach (SapeContextLink l in links)
            {
                string text = l.RawLink;
                text = System.Text.RegularExpressions.Regex.Replace(text, "<[^>]*>", "");
                linksWithStrings.Add(text, l);
            }
        }
        public string MakeContextLinks(string input)
        {
            if (linksWithStrings != null)
                foreach (String key in linksWithStrings.Keys)
                {
                    input = input.Replace(key, linksWithStrings[key].RawLink);
                }
            return input;
        }
        public string GetLinksAsString()
        {
            return GetLinksAsString(0, Links.Count - 1);
        }
        public string GetLinksAsString(int from, int to)
        {
            string result = "";
            if (IsSapeBot)
                result += "<sape_noindex>";
            int i;
            List<SapeLink> links = GetLinks();
            for (i = 0; i < links.Count; i++)
            {
                if ((i >= from) && (i <= to))
                {
                    result += links[i].RawLink + Host.Delimiter;
                }
            }
            if (IsSapeBot)
                result += "</sape_noindex>";
            if (IsSapeBot || config.ForceCheckCode.Value)
            {
                result += Host.CheckCode;
            }
            return result;
        }
        private SapeConfigSection config
        {
            get
            {
                return (SapeConfigSection)System.Configuration.ConfigurationManager.GetSection("effetto.Sape/SapeConfig");
            }
        }
        protected Boolean IsSapeBot
        {
            get
            {
                if (HttpContext.Current.Request.Cookies["sape_cookie"] != null)
                    if (!String.IsNullOrEmpty(HttpContext.Current.Request.Cookies["sape_cookie"].Value))
                        if (HttpContext.Current.Request.Cookies["sape_cookie"].Value.ToLower() == Host.OwnerId)
                            return true;
                return false;
            }
        }
        public List<SapeLink> GetLinks()
        {
            List<SapeLink> result = new List<SapeLink>();
            foreach (SapeLinkBase link in Links)
                if (link is SapeLink)
                    result.Add((SapeLink)link);
            return result;
        }

        public List<SapeContextLink> GetContextLinks()
        {
            List<SapeContextLink> result = new List<SapeContextLink>();
            foreach (SapeLinkBase link in Links)
                if (link is SapeContextLink)
                    result.Add((SapeContextLink)link);
            return result;
        }
    }
}
