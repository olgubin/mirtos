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
using UC.BLL.Articles;

namespace UC.BLL.Store
{
    public class ProductType : BaseEntity
    {
        public ProductType()
        {
        }

        public int ProductTypeID { get; set; }

        public string Type { get; set; }
    }
}