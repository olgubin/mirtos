using System;
using System.Collections;
using System.Collections.Specialized;
using System.Text;
using System.Configuration;
using System.Xml;

namespace effetto.Sape
{
    public class SapeConfigSection : ConfigurationSection
    {
        public SapeConfigSection()
        {
            if (DefaultDocuments == null)
                DefaultDocuments = new SapeDefaultPageCollection();
        }

        [ConfigurationProperty("CacheTimeout", DefaultValue = "45")]
        [LongValidator(ExcludeRange = false, MinValue = 10)]
        public long CacheTimeout
        {
            get
            {
                return (long)this["CacheTimeout"];
            }
            set
            {
                this["CacheTimeout"] = value;
            }
        }
        [ConfigurationProperty("CacheInSQL", DefaultValue = "false")]
        public Nullable<Boolean> CacheInSQL
        {
            get
            {
                return (Boolean)this["CacheInSQL"];
            }
            set
            {
                this["CacheInSQL"] = value;
            }
        }
        [ConfigurationProperty("ConnectionStringName", DefaultValue = "")]
        public String ConnectionStringName
        {
            get
            {
                return (String)this["ConnectionStringName"];
            }
            set
            {
                this["ConnectionStringName"] = value;
            }
        }
        [ConfigurationProperty("SystemId", DefaultValue = "47474747-4747-4747-4747-474747474747")]
        public String SystemId
        {
            get
            {
                return (String)this["SystemId"];
            }
            set
            {
                this["SystemId"] = value;
            }
        }

        [ConfigurationProperty("ExpireTimeout", DefaultValue = "600")]
        [LongValidator(ExcludeRange = false, MinValue = 20)]
        public long ExpireTimeout
        {
            get
            {
                return (long)this["ExpireTimeout"];
            }
            set
            {
                this["ExpireTimeout"] = value;
            }
        }        

        [ConfigurationProperty("UserId", DefaultValue = "00000000000000000000000000000000")]
        [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\", MinLength = 32, MaxLength = 32)]
        public String UserId
        {
            get
            {
                return (String)this["UserId"];
            }
            set
            {
                this["UserId"] = value;
            }
        }

        [ConfigurationProperty("Host")]
        [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\")]
        public String Host
        {
            get
            {
                return (String)this["Host"];
            }
            set
            {
                this["Host"] = value;
            }
        }

        [ConfigurationProperty("UrlAnalyzer", DefaultValue = "true")]
        public Nullable<Boolean> UrlAnalyzer
        {
            get
            {
                return (Boolean)this["UrlAnalyzer"];
            }
            set
            {
                this["UrlAnalyzer"] = value;
            }
        }

        [ConfigurationProperty("QueryAnalyzer", DefaultValue = "true")]
        public Nullable<Boolean> QueryAnalyzer
        {
            get
            {
                return (Boolean)this["QueryAnalyzer"];
            }
            set
            {
                this["QueryAnalyzer"] = value;
            }
        }

        [ConfigurationProperty("QueryFilter", DefaultValue = "false")]
        public Nullable<Boolean> QueryFilter
        {
            get
            {
                return (Boolean)this["QueryFilter"];
            }
            set
            {
                this["QueryFilter"] = value;
            }
        }

        [ConfigurationProperty("IgnoreCase", DefaultValue = "true")]
        public Nullable<Boolean> IgnoreCase
        {
            get
            {
                return (Boolean)this["IgnoreCase"];
            }
            set
            {
                this["IgnoreCase"] = value;
            }
        }

        [ConfigurationProperty("QueryParameters", DefaultValue = "")]
        public String QueryParameters
        {
            get
            {
                return (String)this["QueryParameters"];
            }
            set
            {
                this["QueryParameters"] = value;
            }
        }


        [ConfigurationProperty("DefaultDocuments")]
        public SapeDefaultPageCollection DefaultDocuments 
        {
            get
            {
                return (SapeDefaultPageCollection)this["DefaultDocuments"];
            }
            set
            {
                this["DefaultDocuments"] = value;
            }
        }

        [ConfigurationProperty("RussianNormalizer", DefaultValue = "true")]
        public Nullable<Boolean> RussianNormalizer
        {
            get
            {
                return (Boolean)this["RussianNormalizer"];
            }
            set
            {
                this["RussianNormalizer"] = value;
            }
        }
        [ConfigurationProperty("ForceCheckCode", DefaultValue = "false")]
        public Nullable<Boolean> ForceCheckCode
        {
            get
            {
                return (Boolean)this["ForceCheckCode"];
            }
            set
            {
                this["ForceCheckCode"] = value;
            }
        }
    }

    [ConfigurationCollection(typeof(SapeDefaultPage), CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap)]
    public class SapeDefaultPageCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            SapeDefaultPage element = new SapeDefaultPage();
            element.Name = "";
            return element;
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as SapeDefaultPage).Name;
        }
    }
    
    public class SapeDefaultPage : ConfigurationElement
    {
        [ConfigurationProperty("Name")]
        public String Name
        {
            get
            {
                return (String)this["Name"];
            }
            set
            {
                this["Name"] = value;
            }
        }
    }
}
