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
    public partial class ShoppingCartControl : BaseWebPart
    {
        public enum BtnProceedOrder { proceed, continue_proceed, confirm };
        
        string _validationGroup = "";
        public string ValidationGroup
        {
            get { return _validationGroup; }
            set 
            { 
                _validationGroup = value;
                btnProceedOrder.ValidationGroup = _validationGroup;
            }
        }

        BtnProceedOrder _btnOrder = BtnProceedOrder.proceed;
        public BtnProceedOrder BtnOrder
        {
            set
            {
                _btnOrder = value;

                switch (_btnOrder)
                {
                    case BtnProceedOrder.proceed:
                        {
                            btnReserve.Visible = true;
                            btnProceedOrder.Visible = false;
                            btnConfirmOrder.Visible = false;

                            gvwOrderItems.Columns[6].Visible = true;
                            gvwOrderItems.Columns[2].Visible = true;
                            gvwOrderItems.Columns[3].Visible = false;
                            tdFalse.Visible = true;
                            lblMsg.Text = "Если Вы изменили количество товара, пожалуйста нажмите <b>пересчитать</b> *";
                            break;
                        }
                    case BtnProceedOrder.continue_proceed:
                        {
                            btnReserve.Visible = false;
                            btnProceedOrder.Visible = true;
                            btnConfirmOrder.Visible = false;

                            gvwOrderItems.Columns[6].Visible = true;
                            gvwOrderItems.Columns[2].Visible = true;
                            gvwOrderItems.Columns[3].Visible = false;
                            tdFalse.Visible = true;
                            lblMsg.Text = "Если Вы изменили количество товара, пожалуйста нажмите <b>пересчитать</b> *";
                            break;
                        }
                    case BtnProceedOrder.confirm:
                        {
                            btnReserve.Visible = false;
                            btnProceedOrder.Visible = false;
                            btnConfirmOrder.Visible = true;

                            gvwOrderItems.Columns[6].Visible = false;
                            gvwOrderItems.Columns[2].Visible = false;
                            gvwOrderItems.Columns[3].Visible = true;
                            btnContinueShopping.Visible = false;
                            btnUpdateTotals.Visible = false;
                            tdFalse.Visible = false;
                            lblMsg.Text = "<b>Срок доставки и стоимость сообщит наш менеджер по телефону *</b>";
                            break;
                        }
                }
            }
        }

        public delegate void ProceedOrderEventHandler(object sender,ImageClickEventArgs e);

        public event ProceedOrderEventHandler ProceedOrder;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                UpdateTotals();
            }
        }

        protected void UpdateTotals()
        {
            // update the quantities
            foreach (GridViewRow row in gvwOrderItems.Rows)
            {
                int id = Convert.ToInt32(gvwOrderItems.DataKeys[row.RowIndex][0]);
                int quantity = Convert.ToInt32((row.FindControl("txtQuantity") as TextBox).Text);
                this.Profile.ShoppingCart.UpdateItemQuantity(id, quantity);
            }

            // display the subtotal and the total amounts
            lblSubtotal.Text = (this.Page as BasePage).FormatPrice(this.Profile.ShoppingCart.Total);

            // if the shopping cart is empty, hide the link to proceed
            if (this.Profile.ShoppingCart.Items.Count == 0)
            {
                panTotals.Visible = false;

                Response.Redirect("Default.aspx");
            }

            gvwOrderItems.DataBind();
        }

        protected void gvwOrderItems_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            UpdateTotals();
        }

        protected void btnUpdateTotals_Click(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        protected void btnContinueShopping_Click(object sender, EventArgs e)
        {
            if (Session["last_product_page"] != null)
            {
                Response.Redirect(Session["last_product_page"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        protected void gvwOrderItems_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton btn = e.Row.Cells[6].Controls[0] as ImageButton;
                btn.OnClientClick = "if (confirm(\"Подтвердите удаление товара из карзины\") == false) return false;";
            }
        }

        protected void btnProceedOrder_Click(object sender, ImageClickEventArgs e)
        {
            //генерирование события оформления заказа
            if (ProceedOrder != null)
            {
                ProceedOrder(this, e);
            }
        }
    }
}