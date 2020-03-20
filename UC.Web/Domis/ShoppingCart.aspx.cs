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
            //������ ������� ���������� ��������
            BaseWebPart cartBox = base.Master.FindControl("ShoppingCartBox") as BaseWebPart;
            if (cartBox != null)
            {
                cartBox.Visible = false;
            }

            // ���� ����������� �������������� ���������� ��� ���������� ����
            // ���������� ��� - ���������
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

            // ���� ������� ������
            if (this.Profile.ShoppingCart.Items.Count == 0)
            {
                ActiveStep = 0;
                mvwSubmitOrder.SetActiveView(vwEmptyCart);
                BreadCrumb.AddInActiveLink("�������");
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

        //������� ����������� � �������� �������
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
                    //����������� � �����������
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
                case -1: //�������
                    mvwSubmitOrder.ActiveViewIndex = -1;
                    BreadCrumb.AddInActiveLink("�������");
                    if (!Cart.Visible) Cart.Visible = true;
                    Cart.ValidationGroup = "";
                    Cart.BtnOrder = ShoppingCartControl.BtnProceedOrder.proceed;
                    break;
                case 0: //������ �������
                    mvwSubmitOrder.SetActiveView(vwEmptyCart);
                    BreadCrumb.AddInActiveLink("�������");
                    Cart.Visible = false;
                    break;
                case 1: //�����������
                    mvwSubmitOrder.SetActiveView(vwRegister);
                    BreadCrumb.AddInActiveLink("���������� ������");
                    Cart.ValidationGroup = "Register";
                    Cart.BtnOrder = ShoppingCartControl.BtnProceedOrder.continue_proceed;
                    break;
                case 2: //�����
                    mvwSubmitOrder.SetActiveView(vwAddress);
                    BreadCrumb.AddInActiveLink("���������� ������");
                    Cart.ValidationGroup = "Address";
                    Cart.BtnOrder = ShoppingCartControl.BtnProceedOrder.continue_proceed;
                    break;
                case 3: //������ ������
                    mvwSubmitOrder.SetActiveView(vwPayment);
                    BreadCrumb.AddInActiveLink("���������� ������");
                    Cart.ValidationGroup = "";
                    Cart.BtnOrder = ShoppingCartControl.BtnProceedOrder.continue_proceed;
                    break;
                case 4: //��������� �����������
                    mvwSubmitOrder.SetActiveView(vwPayer);
                    BreadCrumb.AddInActiveLink("���������� ������");
                    Cart.ValidationGroup = "Payer";
                    Cart.BtnOrder = ShoppingCartControl.BtnProceedOrder.continue_proceed;
                    break;
                case 5: //������������� ������
                    mvwSubmitOrder.SetActiveView(vwConfirm);
                    BreadCrumb.AddInActiveLink("������������� ������");
                    Cart.ValidationGroup = "";
                    Cart.BtnOrder = ShoppingCartControl.BtnProceedOrder.confirm;
                    lnkPrC.Visible = (Profile.Payment.PaymentMethod == UC.BLL.Store.PaymentMethod.Wire);
                    Confirm.Generate();
                    break;
                case 6:
                    mvwSubmitOrder.SetActiveView(vwAdopt);
                    BreadCrumb.AddInActiveLink("������������� ������");
                    Cart.Visible = false;
                    break;
            }
        }

        //��������� ������� �� ������� ������
        protected void onCommand(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "StepOrder")
            {
                ActiveStep = Int32.Parse(e.CommandArgument.ToString());
            }
        }
}
}