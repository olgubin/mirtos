using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace effetto.Sape
{
    [ToolboxData("<{0}:SapePageConfig runat=server></{0}:SapePageConfig>")]
    public class SapePageConfig : SapeControl
    {
        public SapePageConfig()
        {
            StoreInRequest();
        }
        private void StoreInRequest()
        {
            if (String.IsNullOrEmpty(this.ID)) this.ID = System.IO.Path.GetFileNameWithoutExtension(System.IO.Path.GetRandomFileName());
            if (Context.Items["SapePageConfig"] == null)
            {
                Context.Items["SapePageConfig"] = this.ID;
            }
            else
            {
                throw new Exception("Only one SapePageConfig alowed on page");
            }
        }
        public SapePageConfig(Boolean storeInRequest)
        {
            if (storeInRequest) StoreInRequest();
        }

        public static SapePageConfig GetPageConfig(Page page)
        {
            if (HttpContext.Current.Items["SapePageConfig"] == null)
            {
                return new SapePageConfig(false);
            }
            else
            {
                Control control = page.FindControl((String)HttpContext.Current.Items["SapePageConfig"]);
                if (control == null) return new SapePageConfig();
                return (SapePageConfig)control;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [Localizable(false)]
        public String Host { get; set; }
        public String PreferHost
        {
            get
            {
                if (!String.IsNullOrEmpty(Host))
                    return Host.ToLower();
                if (!String.IsNullOrEmpty(config.Host))
                    return config.Host.ToLower();
                return Context.Request.Url.Host.ToLower();
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [Localizable(false)]
        public Nullable<Boolean> UrlAnalyzer { get; set; }
        public Boolean PreferUrlAnalyzer
        {
            get
            {
                if (this.UrlAnalyzer.HasValue) return this.UrlAnalyzer.Value;
                if (config.UrlAnalyzer.HasValue) return config.UrlAnalyzer.Value;
                return false;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [Localizable(false)]
        public Nullable<Boolean> QueryAnalyzer { get; set; }
        public Boolean PreferQueryAnalyzer
        {
            get
            {
                if (this.QueryAnalyzer.HasValue) return this.QueryAnalyzer.Value;
                if (config.QueryAnalyzer.HasValue) return config.QueryAnalyzer.Value;
                return false;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [Localizable(false)]
        public Nullable<Boolean> QueryFilter { get; set; }
        public Boolean PreferQueryFilter
        {
            get
            {
                if (this.QueryFilter.HasValue) return this.QueryFilter.Value;
                if (config.QueryFilter.HasValue) return config.QueryFilter.Value;
                return false;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [Localizable(false)]
        public Nullable<Boolean> IgnoreCase { get; set; }
        public Boolean PreferIgnoreCase
        {
            get
            {
                if (this.IgnoreCase.HasValue) return this.IgnoreCase.Value;
                if (config.IgnoreCase.HasValue) return config.IgnoreCase.Value;
                return false;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [Localizable(false)]
        public String QueryParameters { get; set; }
        public String PreferQueryParameters
        {
            get
            {
                if (!String.IsNullOrEmpty(QueryParameters))
                    return QueryParameters;
                if (!String.IsNullOrEmpty(config.QueryParameters))
                    return config.QueryParameters;
                return "";
            }
        }


        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("00000000000000000000000000000000")]
        [Localizable(false)]
        public String UserId { get; set; }
        public String PreferUserId
        {
            get
            {
                if (!String.IsNullOrEmpty(UserId))
                    if (UserId != "00000000000000000000000000000000")
                        return UserId.ToLower();
                if (!String.IsNullOrEmpty(config.UserId))
                    if (config.UserId != "00000000000000000000000000000000")
                        return config.UserId.ToLower();
                throw new Exception("User Id not defined");
            }
        }
    
    }
}
