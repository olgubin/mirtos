using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Web;

namespace effetto.Sape
{
    [Serializable]  
    public class SapeUrl
    {
        public String RawUrl{get; private set;}

        [NonSerialized]
        SapeConfigSection _config = null;
        private SapeConfigSection Config
        {
            get
            {
                if (_config == null)
                    _config = (SapeConfigSection)System.Configuration.ConfigurationManager.GetSection("effetto.Sape/SapeConfig");
                return _config;
            }
        }

        private string importantParams;
        public String Path
        {
            get
            {
                if (RawUrl.Contains("?"))
                {
                    string path;
                    path = RawUrl.Substring(0, RawUrl.IndexOf("?"));
                    path = CutLastSlash(path);
                    return path;
                }
                else
                {
                    return RawUrl;
                }
            }
        }
        public String PathWithoutDefaultDocument
        {
            get
            {
                string path = Path;
                SapeConfigSection config = (SapeConfigSection)System.Configuration.ConfigurationManager.GetSection("effetto.Sape/SapeConfig");
                foreach (SapeDefaultPage doc in config.DefaultDocuments)
                {
                    if (path.EndsWith(doc.Name, true, null))
                    {
                        path = path.Substring(0, path.Length - doc.Name.Length);
                        path = CutLastSlash(path);
                        return (path);
                    }
                }
                return CutLastSlash(path);
            }
        }

        public String Query
        {
            get
            {
                if (RawUrl.Contains("?"))
                {
                    return RawUrl.Substring(RawUrl.IndexOf("?") + 1);
                }
                else
                {
                    return null;
                }
            }
        }
        public NameValueCollection QueryParams
        {
            get
            {
                NameValueCollection result = new NameValueCollection();
                string query = Query;
                if (query == null) return result;
                while (query.EndsWith("&"))
                    query = query.Substring(0, Query.Length - 1);
                string[] queryParams = query.Split('&');
                if (queryParams == null) return result;
                if (queryParams.Length == 0) return result;
                foreach (String s in queryParams)
                {
                    if (s.Contains("="))
                    {
                        int index = s.IndexOf("=");
                        if ((index != s.Length - 1) && (index != 0))
                        {
                            String paramName = s.Split('=')[0];
                            String paramValue = s.Substring(index + 1);
                            if ((paramName.Length > 0) && (paramValue.Length > 0))
                                result.Add(paramName, paramValue);
                        }
                    }
                }
                return result;
            }
        }
        public List<String> ImportantParamsList
        {
            get
            {
                List<String> result = new List<string>();
                if (importantParams.Length == 0) return result;
                string[] queryParams = importantParams.Split(',');
                foreach (String s in queryParams)
                {
                    result.Add(s.Trim());
                }
                return result;
            }
        }
        private NameValueCollection ImportantQueryParams
        {
            get
            {
                NameValueCollection queryParams = QueryParams;
                List<String> importantParamsList = ImportantParamsList;
                if (importantParamsList.Count == 0) return queryParams;
                int i = 0;
                while (i < queryParams.Keys.Count)
                {
                    if (importantParamsList.Contains(queryParams.Keys[i].ToLower()))
                    {
                        i++;
                    }
                    else
                    {
                        queryParams.Remove(queryParams.Keys[i]);
                    }                    
                }
                return queryParams;
            }
        }
        private string CutLastSlash(string url)
        {
            while (url.EndsWith("/"))
            {
                url = url.Substring(0, url.Length - 1);
            }
            return url;
        }
        public SapeUrl()
        {
            this.RawUrl = HttpContext.Current.Request.RawUrl;
            this.importantParams = "";
        }
        public SapeUrl(String rawUrl)
            : this(rawUrl, "")
        {
        }
        public SapeUrl(String rawUrl, String getParams)
        {
            if (Config.RussianNormalizer.GetValueOrDefault())
                this.RawUrl = RussianNormalizer.GetFixedUrl(rawUrl);
            else
                this.RawUrl = rawUrl;            
            this.importantParams = getParams.ToLower();
        }
        public static bool Compare(SapeUrl url1, SapeUrl url2, Boolean analyzeUrl, Boolean analyzeQuery, Boolean useImportants, Boolean ignoreCase)
        {
            if (analyzeUrl)
            {
                if (analyzeQuery)
                {
                    if (String.Compare(url1.PathWithoutDefaultDocument, url2.PathWithoutDefaultDocument, ignoreCase) != 0) return false;
                    NameValueCollection url1Params;
                    NameValueCollection url2Params;
                    if (useImportants)
                    {
                            url1Params = url1.ImportantQueryParams;
                            url2Params = url2.ImportantQueryParams;
                            foreach (String key in url1Params.Keys)
                            {
                                if (url2Params[key] == null) return false;
                                if (String.Compare(url2Params[key], url1Params[key], ignoreCase) != 0) return false;
                            }
                            foreach (String key in url2Params.Keys)
                            {
                                if (url1Params[key] == null) return false;
                                if (String.Compare(url2Params[key], url1Params[key], ignoreCase) != 0) return false;
                            }
                        return true;
                    }
                    else
                    {
                        url1Params = url1.QueryParams;
                        url2Params = url2.QueryParams;
                        foreach (String key in url1Params.Keys)
                        {
                            if (url2Params[key] == null) return false;
                            if (String.Compare(url2Params[key], url1Params[key], ignoreCase) != 0) return false;
                        }
                        foreach (String key in url2Params.Keys)
                        {
                            if (url1Params[key] == null) return false;
                            if (String.Compare(url1Params[key], url2Params[key], ignoreCase) != 0) return false;
                        }
                    }
                    return true;
                }
                else
                {
                    return
                        String.Compare(url1.PathWithoutDefaultDocument, url2.PathWithoutDefaultDocument, ignoreCase) == 0
                        &&
                        String.Compare(url1.Query, url2.Query, ignoreCase) == 0;
                }
            }
            else
            {
                 return String.Compare(url1.RawUrl, url2.RawUrl, ignoreCase) == 0;
            }
        }
    }
}