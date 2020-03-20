using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace effetto.Sape
{
    [DefaultProperty("UserId")]
    public abstract class SapeControl : Control
    {
        protected SapeConfigSection config;
        protected SapePageConfig pageConfig;
        protected SapeHost host;
        protected SapePage page;
        protected SapeUser user;

        protected override void OnInit(EventArgs e)
        {
            pageConfig = SapePageConfig.GetPageConfig(Page);
            user = SapeFactory.Factory.GetUser(pageConfig.PreferUserId);
            if (user != null)
            {
                host = user.GetHost(pageConfig.PreferHost);
                if (host != null)
                {
                    page = host.GetPage(new SapeUrl(Context.Request.RawUrl, pageConfig.PreferQueryParameters), pageConfig.PreferUrlAnalyzer, pageConfig.PreferQueryAnalyzer, pageConfig.PreferQueryFilter, pageConfig.PreferIgnoreCase, config.RussianNormalizer.Value);
                }
            }
            base.OnInit(e);
        }

        public SapeControl()
        {
            config = (SapeConfigSection)System.Configuration.ConfigurationManager.GetSection("effetto.Sape/SapeConfig");
        }
 

        protected Boolean IsSapeBot
        {
            get
            {
                if (Context.Request.Cookies["sape_cookie"] != null)
                    if (!String.IsNullOrEmpty(Context.Request.Cookies["sape_cookie"].Value))
                        if (Context.Request.Cookies["sape_cookie"].Value.ToLower() == pageConfig.PreferUserId)
                            return true;
                return false;
            }
        }


    }
}
