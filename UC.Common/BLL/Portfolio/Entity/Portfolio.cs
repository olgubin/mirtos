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

namespace UC.BLL.Gallery
{
    public class Portfolio : BaseEntity
    {
        public Portfolio()
        {
        }

        public int PortfolioID { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int DisplayOrder { get; set; }
    }

}
