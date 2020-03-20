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
using UC.UI.Controls;
using System.Net.Mail;

namespace UC.UI
{
    public partial class ShoppingCart : BasePage
    {
        int _activeStep = -1;
        public int ActiveStep
        {
            get
            {
                if (Session["proceed_order_step"] != null)
                {
                    _activeStep = (int)Session["proceed_order_step"];
                }
                else
                {
                    if (ViewState["proceed_order_step"] != null)
                    {
                        _activeStep = (int)ViewState["proceed_order_step"];
                    }
                }

                return _activeStep;
            }
            set
            {
                _activeStep = value;

                Session["proceed_order_step"] = value;
                ViewState["proceed_order_step"] = value;
            }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //Прячет элемент управления корзиной
            BaseWebPart cartBox = base.Master.FindControl("ShoppingCartBox") as BaseWebPart;
            if (cartBox != null)
            {
                cartBox.Visible = false;
            }

            // Если регистрация соответственно обновление без увеличения шага
            // Исправляем это - обновляем
            if (!Page.IsPostBack)
            {
                if (ActiveStep == 1)
                {
                    if (Page.User.Identity.IsAuthenticated)
                    {
                        ActiveStep = 2;
                    }
                }
                else
                {
                    if (ActiveStep!=2)
                        ActiveStep = -1;
                }
            }

            // Если корзина пустая
            if (this.Profile.ShoppingCart.Items.Count == 0)
            {
                ActiveStep = 0;
                mvwSubmitOrder.SetActiveView(vwEmptyCart);
                BreadCrumb.AddInActiveLink("Корзина");
                Cart.Visible = false;
            }
            else
            {
                if (ActiveStep == 6 | ActiveStep == 0)
                    ActiveStep = -1;
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            ActivateView(ActiveStep);
        }

        //Событие возникающее в контроле карзины
        protected void ProceedOrder(object sender, ImageClickEventArgs e)
        {
            switch (ActiveStep)
            {
                case -1:
                    if (Page.User.Identity.IsAuthenticated)
                        ActiveStep = 2;
                    else
                        ActiveStep = 1;
                    break;
                case 1:
                    //регистрация и авторизация
                    if (Reg.onRegister())
                    {
                        ActiveStep = 2;
                    }
                    break;
                case 2:
                    if (this.User.Identity.IsAuthenticated)
                    {
                        Address.onSave();
                        ActiveStep = 3;
                    }
                    else
                        ActiveStep = 1;
                    break;
                case 3:
                    if (this.User.Identity.IsAuthenticated)
                    {
                        Payment.onSave(sender, e);
                        if (Payment.UserProfile.Payment.PaymentMethod == UC.BLL.Store.PaymentMethod.Wire)
                        {
                            ActiveStep = 4;
                        }
                        else
                        {
                            ActiveStep = 5;
                        }
                    }
                    else
                        ActiveStep = 1;
                    break;
                case 4:
                    if (this.User.Identity.IsAuthenticated)
                    {
                        Payer.onSave(sender, e);
                        ActiveStep = 5;
                    }
                    else
                        ActiveStep = 1;
                    break;
                case 5:
                    if (this.User.Identity.IsAuthenticated)
                    {
                        Adopt.Comment = Confirm.Comment;
                        Adopt.Generate();
                        ActiveStep = 6;
                    }
                    else
                        ActiveStep = 1;
                    break;
            }
        }

        protected void ActivateView(int step)
        {
            switch (step)
            {
                case -1: //Корзина
                    mvwSubmitOrder.ActiveViewIndex = -1;
                    BreadCrumb.AddInActiveLink("Корзина");
                    if (!Cart.Visible) Cart.Visible = true;
                    Cart.ValidationGroup = "";
                    Cart.BtnOrder = ShoppingCartControl.BtnProceedOrder.proceed;
                    break;
                case 0: //Пустая корзина
                    mvwSubmitOrder.SetActiveView(vwEmptyCart);
                    BreadCrumb.AddInActiveLink("Корзина");
                    Cart.Visible = false;
                    break;
                case 1: //Регистрация
                    mvwSubmitOrder.SetActiveView(vwRegister);
                    BreadCrumb.AddInActiveLink("Оформление заказа");
                    Cart.ValidationGroup = "Register";
                    Cart.BtnOrder = ShoppingCartControl.BtnProceedOrder.continue_proceed;
                    break;
                case 2: //Адрес
                    mvwSubmitOrder.SetActiveView(vwAddress);
                    BreadCrumb.AddInActiveLink("Оформление заказа");
                    Cart.ValidationGroup = "Address";
                    Cart.BtnOrder = ShoppingCartControl.BtnProceedOrder.continue_proceed;
                    break;
                case 3: //Способ оплаты
                    mvwSubmitOrder.SetActiveView(vwPayment);
                    BreadCrumb.AddInActiveLink("Оформление заказа");
                    Cart.ValidationGroup = "";
                    Cart.BtnOrder = ShoppingCartControl.BtnProceedOrder.continue_proceed;
                    break;
                case 4: //Реквизиты плательщика
                    mvwSubmitOrder.SetActiveView(vwPayer);
                    BreadCrumb.AddInActiveLink("Оформление заказа");
                    Cart.ValidationGroup = "Payer";
                    Cart.BtnOrder = ShoppingCartControl.BtnProceedOrder.continue_proceed;
                    break;
                case 5: //Подтверждение заказа
                    mvwSubmitOrder.SetActiveView(vwConfirm);
                    BreadCrumb.AddInActiveLink("Подтверждение заказа");
                    Cart.ValidationGroup = "";
                    Cart.BtnOrder = ShoppingCartControl.BtnProceedOrder.confirm;
                    lnkPrC.Visible = (Profile.Payment.PaymentMethod == UC.BLL.Store.PaymentMethod.Wire);
                    Confirm.Generate();
                    break;
                case 6:
                    mvwSubmitOrder.SetActiveView(vwAdopt);
                    BreadCrumb.AddInActiveLink("Подтверждение заказа");
                    Cart.Visible = false;
                    break;
            }
        }

        //Обработка событий от хлебных крошек
        protected void onCommand(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "StepOrder")
            {
                ActiveStep = Int32.Parse(e.CommandArgument.ToString());
            }
        }
}
}