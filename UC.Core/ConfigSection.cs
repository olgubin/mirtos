using System;
using System.Data;
using System.Configuration;
using System.Web.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace UC
{
    public class UCSection : ConfigurationSection
    {
        [ConfigurationProperty("defaultConnectionStringName", DefaultValue = "LocalSqlServer")]
        public string DefaultConnectionStringName
        {
            get { return (string)base["defaultConnectionStringName"]; }
            set { base["connectionStdefaultConnectionStringNameringName"] = value; }
        }

        [ConfigurationProperty("defaultCacheDuration", DefaultValue = "600")]
        public int DefaultCacheDuration
        {
            get { return (int)base["defaultCacheDuration"]; }
            set { base["defaultCacheDuration"] = value; }
        }

        [ConfigurationProperty("contactForm", IsRequired = true)]
        public ContactFormElement ContactForm
        {
            get { return (ContactFormElement)base["contactForm"]; }
        }

        [ConfigurationProperty("articles", IsRequired = true)]
        public ArticlesElement Articles
        {
            get { return (ArticlesElement)base["articles"]; }
        }

        [ConfigurationProperty("polls", IsRequired = true)]
        public PollsElement Polls
        {
            get { return (PollsElement)base["polls"]; }
        }

        [ConfigurationProperty("newsletters", IsRequired = true)]
        public NewslettersElement Newsletters
        {
            get { return (NewslettersElement)base["newsletters"]; }
        }

        [ConfigurationProperty("forums", IsRequired = true)]
        public ForumsElement Forums
        {
            get { return (ForumsElement)base["forums"]; }
        }

        [ConfigurationProperty("store", IsRequired = true)]
        public StoreElement Store
        {
            get { return (StoreElement)base["store"]; }
        }

        [ConfigurationProperty("productFeatured", IsRequired = true)]
        public ProductFeaturedElement ProductFeatured
        {
            get { return (ProductFeaturedElement)base["productFeatured"]; }
        }

        [ConfigurationProperty("search", IsRequired = true)]
        public SearchElement Search
        {
            get { return (SearchElement)base["search"]; }
        }

        [ConfigurationProperty("statistics", IsRequired = true)]
        public StatisticsElement Statistics
        {
            get { return (StatisticsElement)base["statistics"]; }
        }

        [ConfigurationProperty("parsing", IsRequired = true)]
        public ParsingElement Parsing
        {
            get { return (ParsingElement)base["parsing"]; }
        }

        [ConfigurationProperty("framework", IsRequired = true)]
        public FrameworkElement Framework
        {
            get { return (FrameworkElement)base["framework"]; }
        }

        [ConfigurationProperty("siteMap", IsRequired = true)]
        public SiteMapElement SiteMap
        {
            get { return (SiteMapElement)base["siteMap"]; }
        }

        [ConfigurationProperty("images", IsRequired = true)]
        public ImagesElement Images
        {
            get { return (ImagesElement)base["images"]; }
        }
    }

    public class ContactFormElement : ConfigurationElement
    {
        [ConfigurationProperty("mailSubject", IsRequired = true)]
        public string MailSubject
        {
            get { return (string)base["mailSubject"]; }
            set { base["mailSubject"] = value; }
        }

        [ConfigurationProperty("mailTo", IsRequired = true)]
        public string MailTo
        {
            get { return (string)base["mailTo"]; }
            set { base["mailTo"] = value; }
        }

        [ConfigurationProperty("mailCC")]
        public string MailCC
        {
            get { return (string)base["mailCC"]; }
            set { base["mailCC"] = value; }
        }
    }

    public class ArticlesElement : ConfigurationElement
    {
        [ConfigurationProperty("connectionStringName")]
        public string ConnectionStringName
        {
            get { return (string)base["connectionStringName"]; }
            set { base["connectionStringName"] = value; }
        }

        public string ConnectionString
        {
            get
            {
                // Return the base class' ConnectionString property.
                // The name of the connection string to use is retrieved from the site's 
                // custom config section and is used to read the setting from the <connectionStrings> section
                // If no connection string name is defined for the <articles> element, the
                // parent section's DefaultConnectionString prop is used.
                string connStringName = (string.IsNullOrEmpty(this.ConnectionStringName) ?
                   Globals.Settings.DefaultConnectionStringName : this.ConnectionStringName);
                return WebConfigurationManager.ConnectionStrings[connStringName].ConnectionString;
            }
        }

        [ConfigurationProperty("providerType", DefaultValue = "UC.DAL.SqlClient.SqlArticlesProvider")]
        public string ProviderType
        {
            get { return (string)base["providerType"]; }
            set { base["providerType"] = value; }
        }

        [ConfigurationProperty("ratingLockInterval", DefaultValue = "15")]
        public int RatingLockInterval
        {
            get { return (int)base["ratingLockInterval"]; }
            set { base["ratingLockInterval"] = value; }
        }

        [ConfigurationProperty("pageSize", DefaultValue = "10")]
        public int PageSize
        {
            get { return (int)base["pageSize"]; }
            set { base["pageSize"] = value; }
        }

        [ConfigurationProperty("lastArticleSize", DefaultValue = "5")]
        public int LastArticleSize
        {
            get { return (int)base["lastArticleSize"]; }
            set { base["lastArticleSize"] = value; }
        }

        [ConfigurationProperty("rssItems", DefaultValue = "5")]
        public int RssItems
        {
            get { return (int)base["rssItems"]; }
            set { base["rssItems"] = value; }
        }

        [ConfigurationProperty("enableCaching", DefaultValue = "true")]
        public bool EnableCaching
        {
            get { return (bool)base["enableCaching"]; }
            set { base["enableCaching"] = value; }
        }

        [ConfigurationProperty("cacheDuration")]
        public int CacheDuration
        {
            get
            {
                int duration = (int)base["cacheDuration"];
                return (duration > 0 ? duration : Globals.Settings.DefaultCacheDuration);
            }
            set { base["cacheDuration"] = value; }
        }
    }

    public class PollsElement : ConfigurationElement
    {
        [ConfigurationProperty("connectionStringName")]
        public string ConnectionStringName
        {
            get { return (string)base["connectionStringName"]; }
            set { base["connectionStringName"] = value; }
        }

        public string ConnectionString
        {
            get
            {
                string connStringName = (string.IsNullOrEmpty(this.ConnectionStringName) ?
                   Globals.Settings.DefaultConnectionStringName : this.ConnectionStringName);
                return WebConfigurationManager.ConnectionStrings[connStringName].ConnectionString;
            }
        }

        [ConfigurationProperty("providerType", DefaultValue = "UC.DAL.SqlClient.SqlPollsProvider")]
        public string ProviderType
        {
            get { return (string)base["providerType"]; }
            set { base["providerType"] = value; }
        }

        [ConfigurationProperty("votingLockInterval", DefaultValue = "15")]
        public int VotingLockInterval
        {
            get { return (int)base["votingLockInterval"]; }
            set { base["votingLockInterval"] = value; }
        }

        [ConfigurationProperty("votingLockByCookie", DefaultValue = "true")]
        public bool VotingLockByCookie
        {
            get { return (bool)base["votingLockByCookie"]; }
            set { base["votingLockByCookie"] = value; }
        }

        [ConfigurationProperty("votingLockByIP", DefaultValue = "true")]
        public bool VotingLockByIP
        {
            get { return (bool)base["votingLockByIP"]; }
            set { base["votingLockByIP"] = value; }
        }

        [ConfigurationProperty("archiveIsPublic", DefaultValue = "false")]
        public bool ArchiveIsPublic
        {
            get { return (bool)base["archiveIsPublic"]; }
            set { base["archiveIsPublic"] = value; }
        }

        [ConfigurationProperty("enableCaching", DefaultValue = "true")]
        public bool EnableCaching
        {
            get { return (bool)base["enableCaching"]; }
            set { base["enableCaching"] = value; }
        }

        [ConfigurationProperty("cacheDuration")]
        public int CacheDuration
        {
            get
            {
                int duration = (int)base["cacheDuration"];
                return (duration > 0 ? duration : Globals.Settings.DefaultCacheDuration);
            }
            set { base["cacheDuration"] = value; }
        }
    }

    public class NewslettersElement : ConfigurationElement
    {
        [ConfigurationProperty("connectionStringName")]
        public string ConnectionStringName
        {
            get { return (string)base["connectionStringName"]; }
            set { base["connectionStringName"] = value; }
        }

        public string ConnectionString
        {
            get
            {
                string connStringName = (string.IsNullOrEmpty(this.ConnectionStringName) ?
                   Globals.Settings.DefaultConnectionStringName : this.ConnectionStringName);
                return WebConfigurationManager.ConnectionStrings[connStringName].ConnectionString;
            }
        }

        [ConfigurationProperty("providerType", DefaultValue = "UC.DAL.SqlClient.SqlNewslettersProvider")]
        public string ProviderType
        {
            get { return (string)base["providerType"]; }
            set { base["providerType"] = value; }
        }

        [ConfigurationProperty("pageSize", DefaultValue = "10")]
        public int PageSize
        {
            get { return (int)base["pageSize"]; }
            set { base["pageSize"] = value; }
        }

        [ConfigurationProperty("lastNewsSize", DefaultValue = "5")]
        public int LastNewsSize
        {
            get { return (int)base["lastNewsSize"]; }
            set { base["lastNewsSize"] = value; }
        }

        [ConfigurationProperty("fromEmail", IsRequired = true)]
        public string FromEmail
        {
            get { return (string)base["fromEmail"]; }
            set { base["fromEmail"] = value; }
        }

        [ConfigurationProperty("fromDisplayName", IsRequired = true)]
        public string FromDisplayName
        {
            get { return (string)base["fromDisplayName"]; }
            set { base["fromDisplayName"] = value; }
        }

        [ConfigurationProperty("hideFromArchiveInterval", DefaultValue = "15")]
        public int HideFromArchiveInterval
        {
            get { return (int)base["hideFromArchiveInterval"]; }
            set { base["hideFromArchiveInterval"] = value; }
        }

        [ConfigurationProperty("archiveIsPublic", DefaultValue = "false")]
        public bool ArchiveIsPublic
        {
            get { return (bool)base["archiveIsPublic"]; }
            set { base["archiveIsPublic"] = value; }
        }

        [ConfigurationProperty("enableCaching", DefaultValue = "true")]
        public bool EnableCaching
        {
            get { return (bool)base["enableCaching"]; }
            set { base["enableCaching"] = value; }
        }

        [ConfigurationProperty("cacheDuration")]
        public int CacheDuration
        {
            get
            {
                int duration = (int)base["cacheDuration"];
                return (duration > 0 ? duration : Globals.Settings.DefaultCacheDuration);
            }
            set { base["cacheDuration"] = value; }
        }
    }

    public class ForumsElement : ConfigurationElement
    {
        [ConfigurationProperty("connectionStringName")]
        public string ConnectionStringName
        {
            get { return (string)base["connectionStringName"]; }
            set { base["connectionStringName"] = value; }
        }

        public string ConnectionString
        {
            get
            {
                string connStringName = (string.IsNullOrEmpty(this.ConnectionStringName) ?
                   Globals.Settings.DefaultConnectionStringName : this.ConnectionStringName);
                return WebConfigurationManager.ConnectionStrings[connStringName].ConnectionString;
            }
        }

        [ConfigurationProperty("providerType", DefaultValue = "UC.DAL.SqlClient.SqlForumsProvider")]
        public string ProviderType
        {
            get { return (string)base["providerType"]; }
            set { base["providerType"] = value; }
        }

        [ConfigurationProperty("threadsPageSize", DefaultValue = "25")]
        public int ThreadsPageSize
        {
            get { return (int)base["threadsPageSize"]; }
            set { base["threadsPageSize"] = value; }
        }

        [ConfigurationProperty("postsPageSize", DefaultValue = "10")]
        public int PostsPageSize
        {
            get { return (int)base["postsPageSize"]; }
            set { base["postsPageSize"] = value; }
        }

        [ConfigurationProperty("rssItems", DefaultValue = "5")]
        public int RssItems
        {
            get { return (int)base["rssItems"]; }
            set { base["rssItems"] = value; }
        }

        [ConfigurationProperty("hotThreadPosts", DefaultValue = "25")]
        public int HotThreadPosts
        {
            get { return (int)base["hotThreadPosts"]; }
            set { base["hotThreadPosts"] = value; }
        }

        [ConfigurationProperty("bronzePosterPosts", DefaultValue = "100")]
        public int BronzePosterPosts
        {
            get { return (int)base["bronzePosterPosts"]; }
            set { base["bronzePosterPosts"] = value; }
        }

        [ConfigurationProperty("bronzePosterDescription", DefaultValue = "Bronze Poster")]
        public string BronzePosterDescription
        {
            get { return (string)base["bronzePosterDescription"]; }
            set { base["bronzePosterDescription"] = value; }
        }

        [ConfigurationProperty("silverPosterPosts", DefaultValue = "500")]
        public int SilverPosterPosts
        {
            get { return (int)base["silverPosterPosts"]; }
            set { base["silverPosterPosts"] = value; }
        }

        [ConfigurationProperty("silverPosterDescription", DefaultValue = "Silver Poster")]
        public string SilverPosterDescription
        {
            get { return (string)base["silverPosterDescription"]; }
            set { base["silverPosterDescription"] = value; }
        }

        [ConfigurationProperty("goldPosterPosts", DefaultValue = "1000")]
        public int GoldPosterPosts
        {
            get { return (int)base["goldPosterPosts"]; }
            set { base["goldPosterPosts"] = value; }
        }

        [ConfigurationProperty("goldPosterDescription", DefaultValue = "Gold Poster")]
        public string GoldPosterDescription
        {
            get { return (string)base["goldPosterDescription"]; }
            set { base["goldPosterDescription"] = value; }
        }

        [ConfigurationProperty("enableCaching", DefaultValue = "true")]
        public bool EnableCaching
        {
            get { return (bool)base["enableCaching"]; }
            set { base["enableCaching"] = value; }
        }

        [ConfigurationProperty("cacheDuration")]
        public int CacheDuration
        {
            get
            {
                int duration = (int)base["cacheDuration"];
                return (duration > 0 ? duration : Globals.Settings.DefaultCacheDuration);
            }
            set { base["cacheDuration"] = value; }
        }
    }

    public class StoreElement : ConfigurationElement
    {
        [ConfigurationProperty("connectionStringName")]
        public string ConnectionStringName
        {
            get { return (string)base["connectionStringName"]; }
            set { base["connectionStringName"] = value; }
        }

        public string ConnectionString
        {
            get
            {
                string connStringName = (string.IsNullOrEmpty(this.ConnectionStringName) ?
                   Globals.Settings.DefaultConnectionStringName : this.ConnectionStringName);
                return WebConfigurationManager.ConnectionStrings[connStringName].ConnectionString;
            }
        }

        [ConfigurationProperty("providerType", DefaultValue = "UC.DAL.SqlClient.SqlStoreProvider")]
        public string ProviderType
        {
            get { return (string)base["providerType"]; }
            set { base["providerType"] = value; }
        }

        [ConfigurationProperty("departmentRoot", DefaultValue = "0")]
        public int DepartmentRoot
        {
            get { return (int)base["departmentRoot"]; }
            set { base["departmentRoot"] = value; }
        }

        [ConfigurationProperty("ratingLockInterval", DefaultValue = "15")]
        public int RatingLockInterval
        {
            get { return (int)base["ratingLockInterval"]; }
            set { base["ratingLockInterval"] = value; }
        }

        [ConfigurationProperty("pageSize", DefaultValue = "10")]
        public int PageSize
        {
            get { return (int)base["pageSize"]; }
            set { base["pageSize"] = value; }
        }

        [ConfigurationProperty("rssItems", DefaultValue = "5")]
        public int RssItems
        {
            get { return (int)base["rssItems"]; }
            set { base["rssItems"] = value; }
        }

        [ConfigurationProperty("defaultOrderListInterval", DefaultValue = "7")]
        public int DefaultOrderListInterval
        {
            get { return (int)base["defaultOrderListInterval"]; }
            set { base["defaultOrderListInterval"] = value; }
        }

        [ConfigurationProperty("sandboxMode", DefaultValue = "false")]
        public bool SandboxMode
        {
            get { return (bool)base["sandboxMode"]; }
            set { base["sandboxMode"] = value; }
        }

        [ConfigurationProperty("businessEmail", IsRequired = true)]
        public string BusinessEmail
        {
            get { return (string)base["businessEmail"]; }
            set { base["businessEmail"] = value; }
        }

        [ConfigurationProperty("priceAccuracy", DefaultValue = "N2")]
        public string PriceAccuracy
        {
            get { return (string)base["priceAccuracy"]; }
            set { base["priceAccuracy"] = value; }
        }

        [ConfigurationProperty("currencyCode", DefaultValue = "руб")]
        public string CurrencyCode
        {
            get { return (string)base["currencyCode"]; }
            set { base["currencyCode"] = value; }
        }

        [ConfigurationProperty("lowAvailability", DefaultValue = "10")]
        public int LowAvailability
        {
            get { return (int)base["lowAvailability"]; }
            set { base["lowAvailability"] = value; }
        }

        [ConfigurationProperty("topSalesProduct", DefaultValue = "5")]
        public int TopSalesProduct
        {
            get { return (int)base["topSalesProduct"]; }
            set { base["topSalesProduct"] = value; }
        }

        [ConfigurationProperty("productSalesRotate", DefaultValue = "true")]
        public bool ProductSalesRotate
        {
            get { return (bool)base["productSalesRotate"]; }
            set { base["productSalesRotate"] = value; }
        }

        [ConfigurationProperty("topManufacturers", DefaultValue = "5")]
        public int TopManufacturers
        {
            get { return (int)base["topManufacturers"]; }
            set { base["topManufacturers"] = value; }
        }

        [ConfigurationProperty("enableCaching", DefaultValue = "true")]
        public bool EnableCaching
        {
            get { return (bool)base["enableCaching"]; }
            set { base["enableCaching"] = value; }
        }

        [ConfigurationProperty("cacheDuration")]
        public int CacheDuration
        {
            get
            {
                int duration = (int)base["cacheDuration"];
                return (duration > 0 ? duration : Globals.Settings.DefaultCacheDuration);
            }
            set { base["cacheDuration"] = value; }
        }
    }

    public class ProductFeaturedElement : ConfigurationElement
    {
        [ConfigurationProperty("topProduct", DefaultValue = "3")]
        public int TopProduct
        {
            get { return (int)base["topProduct"]; }
            set { base["topProduct"] = value; }
        }

        [ConfigurationProperty("rotate", DefaultValue = "true")]
        public bool Rotate
        {
            get { return (bool)base["rotate"]; }
            set { base["rotate"] = value; }
        }
    }

    public class SearchElement : ConfigurationElement
    {
        [ConfigurationProperty("connectionStringName")]
        public string ConnectionStringName
        {
            get { return (string)base["connectionStringName"]; }
            set { base["connectionStringName"] = value; }
        }

        public string ConnectionString
        {
            get
            {
                string connStringName = (string.IsNullOrEmpty(this.ConnectionStringName) ?
                   Globals.Settings.DefaultConnectionStringName : this.ConnectionStringName);
                return WebConfigurationManager.ConnectionStrings[connStringName].ConnectionString;
            }
        }

        [ConfigurationProperty("providerType", DefaultValue = "UC.DAL.SqlClient.SqlSearchProvider")]
        public string ProviderType
        {
            get { return (string)base["providerType"]; }
            set { base["providerType"] = value; }
        }

        [ConfigurationProperty("pageSize", DefaultValue = "50")]
        public int PageSize
        {
            get { return (int)base["pageSize"]; }
            set { base["pageSize"] = value; }
        }

        [ConfigurationProperty("enableCaching", DefaultValue = "true")]
        public bool EnableCaching
        {
            get { return (bool)base["enableCaching"]; }
            set { base["enableCaching"] = value; }
        }

        [ConfigurationProperty("cacheDuration")]
        public int CacheDuration
        {
            get
            {
                int duration = (int)base["cacheDuration"];
                return (duration > 0 ? duration : Globals.Settings.DefaultCacheDuration);
            }
            set { base["cacheDuration"] = value; }
        }
    }

    public class ParsingElement : ConfigurationElement
    {
        [ConfigurationProperty("connectionStringName")]
        public string ConnectionStringName
        {
            get { return (string)base["connectionStringName"]; }
            set { base["connectionStringName"] = value; }
        }

        public string ConnectionString
        {
            get
            {
                string connStringName = (string.IsNullOrEmpty(this.ConnectionStringName) ?
                   Globals.Settings.DefaultConnectionStringName : this.ConnectionStringName);
                return WebConfigurationManager.ConnectionStrings[connStringName].ConnectionString;
            }
        }

        [ConfigurationProperty("providerType", DefaultValue = "UC.DAL.SqlClient.SqlParsingProvider")]
        public string ProviderType
        {
            get { return (string)base["providerType"]; }
            set { base["providerType"] = value; }
        }

        [ConfigurationProperty("pageSize", DefaultValue = "10")]
        public int PageSize
        {
            get { return (int)base["pageSize"]; }
            set { base["pageSize"] = value; }
        }

        [ConfigurationProperty("enableCaching", DefaultValue = "true")]
        public bool EnableCaching
        {
            get { return (bool)base["enableCaching"]; }
            set { base["enableCaching"] = value; }
        }

        [ConfigurationProperty("cacheDuration")]
        public int CacheDuration
        {
            get
            {
                int duration = (int)base["cacheDuration"];
                return (duration > 0 ? duration : Globals.Settings.DefaultCacheDuration);
            }
            set { base["cacheDuration"] = value; }
        }
    }

    public class FrameworkElement : ConfigurationElement
    {
        [ConfigurationProperty("connectionStringName")]
        public string ConnectionStringName
        {
            get { return (string)base["connectionStringName"]; }
            set { base["connectionStringName"] = value; }
        }

        public string ConnectionString
        {
            get
            {
                string connStringName = (string.IsNullOrEmpty(this.ConnectionStringName) ?
                   Globals.Settings.DefaultConnectionStringName : this.ConnectionStringName);
                return WebConfigurationManager.ConnectionStrings[connStringName].ConnectionString;
            }
        }

        [ConfigurationProperty("providerType", DefaultValue = "UC.DAL.SqlClient.SqlFrameworkProvider")]
        public string ProviderType
        {
            get { return (string)base["providerType"]; }
            set { base["providerType"] = value; }
        }

        [ConfigurationProperty("innactiveDays", DefaultValue = "14")]
        public int InnactiveDays
        {
            get { return (int)base["innactiveDays"]; }
            set { base["innactiveDays"] = value; }
        }
    }

    public class SiteMapElement : ConfigurationElement
    {
        [ConfigurationProperty("staticPages", IsDefaultCollection = false)]
        public PagesCollection StaticPages
        {
            get
            {
                PagesCollection pagesCollection = (PagesCollection)base["staticPages"];
                return pagesCollection;
            }
        }
    }

    public class StatisticsElement : ConfigurationElement
    {
        [ConfigurationProperty("connectionStringName")]
        public string ConnectionStringName
        {
            get { return (string)base["connectionStringName"]; }
            set { base["connectionStringName"] = value; }
        }

        public string ConnectionString
        {
            get
            {
                string connStringName = (string.IsNullOrEmpty(this.ConnectionStringName) ?
                   Globals.Settings.DefaultConnectionStringName : this.ConnectionStringName);
                return WebConfigurationManager.ConnectionStrings[connStringName].ConnectionString;
            }
        }

        [ConfigurationProperty("providerType", DefaultValue = "UC.DAL.SqlClient.SqlStatisticsProvider")]
        public string ProviderType
        {
            get { return (string)base["providerType"]; }
            set { base["providerType"] = value; }
        }

        [ConfigurationProperty("pageSize", DefaultValue = "10")]
        public int PageSize
        {
            get { return (int)base["pageSize"]; }
            set { base["pageSize"] = value; }
        }

        [ConfigurationProperty("enableCaching", DefaultValue = "true")]
        public bool EnableCaching
        {
            get { return (bool)base["enableCaching"]; }
            set { base["enableCaching"] = value; }
        }

        [ConfigurationProperty("cacheDuration")]
        public int CacheDuration
        {
            get
            {
                int duration = (int)base["cacheDuration"];
                return (duration > 0 ? duration : Globals.Settings.DefaultCacheDuration);
            }
            set { base["cacheDuration"] = value; }
        }

       [ConfigurationProperty("pages", IsDefaultCollection = false)]
        public PagesCollection Pages
        {
            get
            {
                PagesCollection pagesCollection = (PagesCollection)base["pages"];
                return pagesCollection;
            }
        }
    }

    public class PageElement : ConfigurationElement
    {
        [ConfigurationProperty("page")]
        public string Page
        {
            get { return (string)base["page"]; }
            set { base["page"] = value; }
        }

        [ConfigurationProperty("name")]
        public string Name
        {
            get { return (string)base["name"]; }
            set { base["name"] = value; }
        }
    }

    public class PagesCollection : ConfigurationElementCollection
    {
        //public PagesCollection()
        //{
        //    PageElement page = (PageElement)CreateNewElement();
        //    Add(page);
        //}

        protected override Object GetElementKey(ConfigurationElement element)
        {
            return ((PageElement)element).Page;
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.AddRemoveClearMap; }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new PageElement();
        }

        public new int Count
        {
            get { return base.Count; }
        }

        public PageElement this[int index]
        {
            get { return (PageElement)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        new public PageElement this[string Name]
        {
            get
            {
                return (PageElement)BaseGet(Name);
            }
        }

        public int IndexOf(PageElement page)
        {
            return BaseIndexOf(page);
        }

        public void Add(PageElement page)
        {
            BaseAdd(page);
        }

        protected override void BaseAdd(ConfigurationElement element)
        {
            BaseAdd(element, false);
        }

        public void Remove(PageElement page)
        {
            if (BaseIndexOf(page) >= 0)
                BaseRemove(page.Page);
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        public void Remove(string name)
        {
            BaseRemove(name);
        }

        public void Clear()
        {
            BaseClear();
        }
    }

    public class ImagesElement : ConfigurationElement
    {
        [ConfigurationProperty("smallImageWidth", DefaultValue = "100")]
        public int SmallImageWidth
        {
            get { return (int)base["smallImageWidth"]; }
            set { base["smallImageWidth"] = value; }
        }

        [ConfigurationProperty("smallImageHeight", DefaultValue = "100")]
        public int SmallImageHeight
        {
            get { return (int)base["smallImageHeight"]; }
            set { base["smallImageHeight"] = value; }
        }

        [ConfigurationProperty("fullImageWidth", DefaultValue = "233")]
        public int FullImageWidth
        {
            get { return (int)base["fullImageWidth"]; }
            set { base["fullImageWidth"] = value; }
        }

        [ConfigurationProperty("fullImageHeight", DefaultValue = "233")]
        public int FullImageHeight
        {
            get { return (int)base["fullImageHeight"]; }
            set { base["fullImageHeight"] = value; }
        }

        [ConfigurationProperty("watermarkText")]
        public string WatermarkText
        {
            get { return (string)base["watermarkText"]; }
            set { base["watermarkText"] = value; }
        }

        [ConfigurationProperty("watermarkFontSize", DefaultValue = "8") ]
        public int WatermarkFontSize
        {
            get { return (int)base["watermarkFontSize"]; }
            set { base["watermarkFontSize"] = value; }
        }

        [ConfigurationProperty("watermarkImagePath")]
        public string WatermarkImagePath
        {
            get { return (string)base["watermarkImagePath"]; }
            set { base["watermarkImagePath"] = value; }
        }

        [ConfigurationProperty("productSalesImageWidth", DefaultValue = "70")]
        public int ProductSalesImageWidth
        {
            get { return (int)base["productSalesImageWidth"]; }
            set { base["productSalesImageWidth"] = value; }
        }

        [ConfigurationProperty("productSalesImageHeight", DefaultValue = "70")]
        public int ProductSalesImageHeight
        {
            get { return (int)base["productSalesImageHeight"]; }
            set { base["productSalesImageHeight"] = value; }
        }

        [ConfigurationProperty("productFeaturedImageWidth", DefaultValue = "70")]
        public int ProductFeaturedImageWidth
        {
            get { return (int)base["productFeaturedImageWidth"]; }
            set { base["productFeaturedImageWidth"] = value; }
        }

        [ConfigurationProperty("productFeaturedImageHeight", DefaultValue = "70")]
        public int ProductFeaturedImageHeight
        {
            get { return (int)base["productFeaturedImageHeight"]; }
            set { base["productFeaturedImageHeight"] = value; }
        }

        [ConfigurationProperty("discountImagePath")]
        public string DiscountImagePath
        {
            get { return (string)base["discountImagePath"]; }
            set { base["discountImagePath"] = value; }
        }

        [ConfigurationProperty("discountFontName", DefaultValue = "Impact")]
        public string DiscountFontName
        {
            get { return (string)base["discountFontName"]; }
            set { base["discountFontName"] = value; }
        }

        [ConfigurationProperty("discountFontSize", DefaultValue = "10")]
        public int DiscountFontSize
        {
            get { return (int)base["discountFontSize"]; }
            set { base["discountFontSize"] = value; }
        }

        [ConfigurationProperty("manufacturerImageWidth", DefaultValue = "37")]
        public int ManufacturerImageWidth
        {
            get { return (int)base["manufacturerImageWidth"]; }
            set { base["manufacturerImageWidth"] = value; }
        }

        [ConfigurationProperty("manufacturerImageHeight", DefaultValue = "37")]
        public int ManufacturerImageHeight
        {
            get { return (int)base["manufacturerImageHeight"]; }
            set { base["manufacturerImageHeight"] = value; }
        }

        [ConfigurationProperty("defaultProductImagePath")]
        public string DefaultProductImagePath
        {
            get { return (string)base["defaultProductImagePath"]; }
            set { base["defaultProductImagePath"] = value; }
        }
    }
}
