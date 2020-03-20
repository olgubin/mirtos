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

namespace UC.Core
{
    public class Setting : BaseEntity
    {
        public Setting()
        {
        }

        public int SettingID { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
    }
}