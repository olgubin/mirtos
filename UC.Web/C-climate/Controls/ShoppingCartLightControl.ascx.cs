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
using UC.UI;
using UC.BLL.Store;

namespace UC.UI.Controls
{
    public partial class ShoppingCartLightControl : BaseWebPart
    {
        public delegate void DeleteEventHandler(object sender,EventArgs e);

        public event DeleteEventHandler DeleteItem;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                UpdateTotals();
            }
        }

        public void UpdateTotals()
        {
            // update the quantities
            foreach (GridViewRow row in gvwOrderItems.Rows)
            {
                int id = Convert.ToInt32(gvwOrderItems.DataKeys[row.RowIndex][0]);
                int quantity = Convert.ToInt32((row.FindControl("txtQuantity") as TextBox).Text);
                this.Profile.ShoppingCart.UpdateItemQuantity(id, quantity);
            }

            //if (this.Profile.ShoppingCart.Discount > 0)
            //{
            //    panDiscountCard.Visible = true;
            //    lblTotal.Text = (this.Page as BasePage).FormatPrice(this.Profile.ShoppingCart.Total);
            //    litDiscountCard.Text = String.Format("Дисконтная карта {0} № {1}. Cкидка {2}%:", Profile.ShoppingCart.DiscountCardName, Profile.ShoppingCart.DiscountCardNumber, Profile.ShoppingCart.DiscountPercentage);
            //    litDiscount.Text = "- " + (this.Page as BasePage).FormatPrice(this.Profile.ShoppingCart.Discount);
            //}

            // display the subtotal and the total amounts
            lblSubtotal.Text = (this.Page as BasePage).FormatPrice(this.Profile.ShoppingCart.Total);

            // if the shopping cart is empty, hide the link to proceed
            if (this.Profile.ShoppingCart.Items.Count == 0)
            {
                panTotals.Visible = false;

                //Response.Redirect("Default.aspx");
            }

            gvwOrderItems.DataBind();
        }

        protected void gvwOrderItems_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            if (DeleteItem != null)
            {
                DeleteItem(this, e);
            }
            UpdateTotals();
        }

        protected void btnUpdateTotals_Click(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        protected void btnContinueShopping_Click(object sender, EventArgs e)
        {
            //if (Session["last_product_page"] != null)
            //{
            //    Response.Redirect(Session["last_product_page"].ToString());
            //}
            //else
            //{
                Response.Redirect("~/Default.aspx");
            //}
        }

        protected void gvwOrderItems_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton btn = e.Row.Cells[6].Controls[0] as ImageButton;
                btn.OnClientClick = "if (confirm(\"Подтвердите удаление товара из карзины\") == false) return false;";
            }
        }

        //protected void btnProceedOrder_Click(object sender, ImageClickEventArgs e)
        //{
        //    //генерирование события оформления заказа
        //    if (ProceedOrder != null)
        //    {
        //        ProceedOrder(this, e);
        //    }
        //}
    }
}