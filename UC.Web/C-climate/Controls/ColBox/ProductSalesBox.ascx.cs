using System;
using System.Data;
using System.Configuration;
using System.Collections;
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
    public partial class ProductSalesBox : BaseWebPart
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //repOrderItems.DataSource = Product.GetProductsTopSales(Globals.Settings.Store.TopSalesProduct);
            //repOrderItems.DataBind();
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            repOrderItems.DataSource = ProductManager.GetProductsTopSales(Globals.Settings.Store.TopSalesProduct, Globals.Settings.Store.ProductSalesRotate);
            repOrderItems.DataBind();
        }
}
}