using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using UC;
using UC.BLL.Store;
using UC.UI;

namespace UC.UI.Controls
{
    public partial class ProductFeaturedBox : BaseWebPart
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductFeaturedCollection products = ProductFeaturedManager.GetProductFeaturedTop(Globals.Settings.ProductFeatured.TopProduct,Globals.Settings.ProductFeatured.Rotate);
            repProductFeatured.DataSource = products;
            repProductFeatured.DataBind();
        }
    }
}