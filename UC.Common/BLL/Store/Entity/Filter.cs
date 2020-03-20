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
using UC.Core;

namespace UC.BLL.Store
{
    public class Filter : BaseEntity
    {
        public Filter()
        {
        }

        public int FilterID { get; set; }

        public string Name { get; set; }
    }

}
