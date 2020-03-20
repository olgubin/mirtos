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
using UC;
using UC.BLL.Store;
using UC.UI;

namespace UC.UI.Controls
{
    public partial class ShoppingCartBox : BaseWebPart
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Из-за него не обновлялась при добавлении товара из списка,
            //при удалении товара из корзины
            //if (!this.IsPostBack)
            //{
            //    if (this.Profile.ShoppingCart.Items.Count > 0)
            //    {
            //        repOrderItems.DataSource = this.Profile.ShoppingCart.Items;
            //        repOrderItems.DataBind();

            //        lblSubtotal.Text = (this.Page as BasePage).FormatPrice(this.Profile.ShoppingCart.Total);
            //        lblSubtotal.Visible = true;
            //        lblSubtotalHeader.Visible = true;
            //        panLinkShoppingCart.Visible = true;
            //        lblCartIsEmpty.Visible = false;
            //    }
            //    else
            //    {
            //        lblSubtotal.Visible = false;
            //        lblSubtotalHeader.Visible = false;
            //        panLinkShoppingCart.Visible = false;
            //        lblCartIsEmpty.Visible = true;
            //    }
            //}
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            repOrderItems.DataSource = this.Profile.ShoppingCart.Items;
            repOrderItems.DataBind();

            if (this.Profile.ShoppingCart.Items.Count > 0)
            {
                //lblTotal.Text = this.Profile.ShoppingCart.Items.Count.ToString();
                lblTotal.Text = this.Profile.ShoppingCart.Count.ToString();
                lblSubtotal.Text = (this.Page as BasePage).FormatPrice(this.Profile.ShoppingCart.Total);
                //lblSubtotal.Visible = true;
                //lblSubtotalHeader.Visible = true;
                panLinkShoppingCart.Visible = true;
            }
            else
            {
                lblTotal.Text = "0";
                lblSubtotal.Text = (this.Page as BasePage).FormatPrice(0);
                //lblSubtotal.Visible = false;
                //lblSubtotalHeader.Visible = false;
                panLinkShoppingCart.Visible = false;
            }
        }
    }
}