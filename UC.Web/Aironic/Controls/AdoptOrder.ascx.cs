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
using UC.BLL.Store;
using System.Net.Mail;

namespace UC.UI.Controls
{
    public partial class AdoptOrder : System.Web.UI.UserControl
    {
        ProfileCommon _userProfile;
        public ProfileCommon UserProfile
        {
            get
            {
                if (_userProfile == null)
                {
                    _userProfile = this.Profile;
                    //_userProfile = this.Profile.GetProfile(Page.User.Identity.Name);
                }
                return _userProfile;
            }
            set { _userProfile = value; }
        }

        string _comment = "";
        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public void Generate()
        {
            if (Page.User.Identity.IsAuthenticated)
            {
                MembershipUser user = Membership.GetUser();

                //int orderID = Order.InsertOrder(this.Profile.ShoppingCart, shippingMethod, Convert.ToDecimal(ddlShippingMethods.SelectedValue),
                //   txtFirstName.Text, txtLastName.Text, txtStreet.Text, txtPostalCode.Text, txtCity.Text,
                //   txtState.Text, ddlCountries.SelectedValue, txtEmail.Text, txtPhone.Text, txtFax.Text, "");


                //// check that the user is still logged in (the cookie may have expired)
                //// and if not redirect to the login page
                //if (this.User.Identity.IsAuthenticated)
                //{
                //    //string shippingMethod = ddlShippingMethods.SelectedItem.Text;
                //    //shippingMethod = shippingMethod.Substring(0, shippingMethod.LastIndexOf('('));

                //    // saves the order into the DB, and clear the shopping cart in the profile
                //    int orderID = Order.InsertOrder(this.Profile.ShoppingCart, shippingMethod, Convert.ToDecimal(ddlShippingMethods.SelectedValue),
                //       txtFirstName.Text, txtLastName.Text, txtStreet.Text, txtPostalCode.Text, txtCity.Text,
                //       txtState.Text, ddlCountries.SelectedValue, txtEmail.Text, txtPhone.Text, txtFax.Text, "");

                //    this.Profile.ShoppingCart.Clear();

                //    // redirect to PayPal for the credit-card payment
                //    //Order order = Order.GetOrderByID(orderID);
                //    //this.Response.Redirect(order.GetPayPalPaymentUrl(), false);
                //}
                ////else
                ////    this.RequestLogin();


                //this.Profile.ShoppingCart.Clear();



                string mainMsg = "";
                string formTxt = "";
                string userMsg = "";

                formTxt += "<p>���������� ��� �� ����� � ��������-�������� <b style=\"color: #d7c5ab\">AIRONIC.RU</b>!</p><p>����� ������ ������: ";
                userMsg += "<p>���������� ��� �� ����� � ��������-�������� <b style=\"color: #d7c5ab\">AIRONIC.RU</b>!</p><p>����� ������ ������: ";
                mainMsg += "<p>����� � ";

                string body = "";
                body = body + "<b>{0}</b></p>";
                body = body + "<p><table style=\"font-family:Verdana,Arial;font-size:11px;\"><tr>";
                body = body + "<td style=\"width:170px\">����������:</td><td><b>" + Profile.Address.FIO + "</b></td></tr>";
                body = body + "<tr><td>�������:</td><td><b>" + Profile.Address.Tel +"</b></td></tr>";
                body = body + "<tr><td>����� ��������:</td>";
                string address = "<td>";
                address = address + "�������� ������: <b>" + Profile.Address.PostCode + "</b><br />";
                address = address + "�������: <b>" + Profile.Address.Oblast + "</b><br />";
                address = address + "�����: <b>" + Profile.Address.Raion + "</b><br />";
                address = address + "�����/�������: <b>" + Profile.Address.Gorod + "</b><br />";
                address = address + "�����: <b>" + Profile.Address.Street + "</b><br />";
                address = address + "���: <b>" + Profile.Address.House + "</b><br />";
                address = address + "��������/����: <b>" + Profile.Address.Ofis + "</b><br />";
                address = address + "�����������: <b>" + Profile.Address.Comment + "</b>";
                body = body + address + "</td></tr>";
                switch (Profile.Payment.PaymentMethod)
                {
                    case UC.BLL.Store.PaymentMethod.Cash:
                        body = body + "<tr><td>������ ������:</td><td><b>��������� ��� ���������</b></td></tr>";
                        break;
                    case UC.BLL.Store.PaymentMethod.Translation:
                        body = body + "<tr><td>������ ������:</td><td><b>���������� �������</b></td></tr>";
                        break;
                    case UC.BLL.Store.PaymentMethod.Wire:
                        body = body + "<tr><td>������ ������:</td><td><b>����������� ������</b></td></tr>";
                        break;
                }
                if (Profile.Payment.PaymentMethod == UC.BLL.Store.PaymentMethod.Wire)
                {
                    string payer = "<tr><td>��������� �����������:</td><td>";
                    if (!String.IsNullOrEmpty(Profile.Payer.Organization)) payer = payer + "�����������: <b>" + Profile.Payer.Organization + "</b>";
                    if (!String.IsNullOrEmpty(Profile.Payer.UrAddress)) payer = payer + ", ����������� �����: <b>" + Profile.Payer.UrAddress + "</b>";
                    if (!String.IsNullOrEmpty(Profile.Payer.INN)) payer = payer + ", ���: <b>" + Profile.Payer.INN + "</b>";
                    if (!String.IsNullOrEmpty(Profile.Payer.KPP)) payer = payer + ", ���: <b>" + Profile.Payer.KPP + "</b>";
                    if (!String.IsNullOrEmpty(Profile.Payer.OKPO)) payer = payer + ", ����: <b>" + Profile.Payer.OKPO + "</b>";
                    if (!String.IsNullOrEmpty(Profile.Payer.OKONH)) payer = payer + ", �����: <b>" + Profile.Payer.OKONH + "</b>";
                    if (!String.IsNullOrEmpty(Profile.Payer.Account)) payer = payer + ", �/����: <b>" + Profile.Payer.Account + "</b>";
                    if (!String.IsNullOrEmpty(Profile.Payer.CorrAccount)) payer = payer + ", ���. ����: <b>" + Profile.Payer.CorrAccount + "</b>";
                    if (!String.IsNullOrEmpty(Profile.Payer.Bank)) payer = payer + ", ����: <b>" + Profile.Payer.Bank + "</b>";
                    if (!String.IsNullOrEmpty(Profile.Payer.BIK)) payer = payer + ", ���: <b>" + Profile.Payer.BIK + "</b>";
                    if (!String.IsNullOrEmpty(Profile.Payer.PostAddress)) payer = payer + ", �������� �����: <b>" + Profile.Payer.PostAddress + "</b>";
                    body = body + payer+ "</td></tr>";
                }
                if (!String.IsNullOrEmpty(Comment)) body = body + "<tr><td>����������� � ������:</td><td><b>" + Comment + "<b/></td></tr>";
                body = body + "</table></p>";
                body = body + "{1}";
                body = body + "<p>��������� ������: <b>{2}</b>. <br/>��������� ��������: ����� ��������� ������ ����������� � �������� ��� �� ��������.</p>";

                string prim = "";
                prim = prim + "<p><b>����������:</b></p>";
                switch (Profile.Payment.PaymentMethod)
                {
                    case UC.BLL.Store.PaymentMethod.Cash:
                        prim = prim + "<p>������ ������ ���� ����������� ���������, ��� �������� ������, �� ���������� ���� ������ �������. ����� � ������ ����� �������� ��������� ������ � ��������� ��������.";
                        break;
                    case UC.BLL.Store.PaymentMethod.Translation:
                        prim = prim + "<p>������ ������ ���� ����������� ������������� �� ��� ��������� ���� �����, �������� ������������ ���������. ��������� ����� ���������� ���������� ����� ������������� ������ �� �������� � �������� ��� �� ����� ��� ����������� �����.";
                        break;
                    case UC.BLL.Store.PaymentMethod.Wire:
                        prim = prim + "<p>������ ����� �������� ����� ����� ����, ����������� �� ���������� ��. �� e-mail ��� ����� ������ ���� � ����������� ��� ������. � ���� &quot;���������� �������&quot; ������� ������� ����� ������������� �����, ��� ���� � ���. ��������, &quot;�� ����� �� ����� �8734 �� 01.01.2006. ��� ���.&quot;.";
                        break;
                }
                prim = prim + "</p>";
                prim = prim + "<p>�������, ��������� � ��������, � ����� ����������� � ��������� �� ������ �������� � ������ �������� �� ������ ���������� �� ������: <a href=\"mailto:zakaz@aironic.ru\">zakaz@aironic.ru</a>. ��� ��� ����� ����� ���� ������!</p><p><b style=\"color: #d7c5ab\">�������, ��� �� ������� ���!</b></p>";
                
                
                string products = "";
                products = products + "<table style=\"font-family:Verdana,Arial;font-size:11px;\"><tr><th style=\"width:70px;height:30px\">�������</th><th>������������</th><th style=\"width:70px\">���-��</th><th style=\"width:100px\">����</th><th style=\"width:100px\">�����</th></tr>";
                foreach (ShoppingCartItem item in Profile.ShoppingCart.Items)
                {
                    products = products + "<tr><td style=\"text-align:center;height:20px\">" + item.SKU + "</td><td><a href=\"http://www.aironic.ru/ShowProduct.aspx?ID=" + item.ID.ToString() + "\">" + item.Title + "</a></td><td style=\"text-align:center\">" + item.Quantity.ToString() + "</td>";
                    products = products + "<td style=\"text-align:right\">" + (this.Page as BasePage).FormatPrice(item.UnitPrice) + "</td><td style=\"text-align:right\">" + (this.Page as BasePage).FormatPrice(item.UnitPrice * item.Quantity) + "</td></tr>";
                }
                products = products + "</table>";

                body = String.Format(body, "DP-02437 �� " + DateTime.Now.ToString("D"), products, (this.Page as BasePage).FormatPrice(this.Profile.ShoppingCart.Total));

                lblAdopt.Text = formTxt + body + prim + "<p style=\"text-align:left\">������ ������� ��������-�������� <b style=\"color: #d7c5ab\">AIRONIC.RU</b>.</p>";

                //// check that the user is still logged in (the cookie may have expired)
                //// and if not redirect to the login page
                //if (this.User.Identity.IsAuthenticated)
                //{
                //    //string shippingMethod = ddlShippingMethods.SelectedItem.Text;
                //    //shippingMethod = shippingMethod.Substring(0, shippingMethod.LastIndexOf('('));

                //    // saves the order into the DB, and clear the shopping cart in the profile
                //    int orderID = Order.InsertOrder(this.Profile.ShoppingCart, shippingMethod, Convert.ToDecimal(ddlShippingMethods.SelectedValue),
                //       txtFirstName.Text, txtLastName.Text, txtStreet.Text, txtPostalCode.Text, txtCity.Text,
                //       txtState.Text, ddlCountries.SelectedValue, txtEmail.Text, txtPhone.Text, txtFax.Text, "");

                //    this.Profile.ShoppingCart.Clear();

                //    // redirect to PayPal for the credit-card payment
                //    //Order order = Order.GetOrderByID(orderID);
                //    //this.Response.Redirect(order.GetPayPalPaymentUrl(), false);
                //}
                ////else
                ////    this.RequestLogin();

                // ������� �������
                this.Profile.ShoppingCart.Clear();

                // ���������� ������ �������, �� ���� ����� � � ���� �� 2 �����
                userMsg = "<p>������������, " + user.Comment + "!</p>" + userMsg + body + prim + "<p>� ���������,<br/>������������� �������� AIRONIC.RU <br/>+7 (495) 730-78-18<br/>WWW.AIRONIC.RU</p>";
                mainMsg += body + "<p>�������� ������������ AIRONIC.RU <br/>+7 (495) 730-78-18<br/>www.AIRONIC.RU</p>";
                try
                {
                    SmtpClient client = new SmtpClient();
                    MailMessage message = new MailMessage();
                    message.From = new MailAddress("zakaz@aironic.ru", "�������� ������������ AIRONIC.RU", System.Text.Encoding.UTF8);
                    message.IsBodyHtml = true;
                    message.Subject = "����� � " + "DP-02437 �� " + DateTime.Now.ToString("D");

                    message.Body = userMsg;

                    message.BodyEncoding = System.Text.Encoding.UTF8;
                    message.SubjectEncoding = System.Text.Encoding.UTF8;
                    message.Priority = System.Net.Mail.MailPriority.High;

                    message.To.Add(user.Email);

                    client.Send(message);

                    message.Body = mainMsg;
                    message.To.Clear();

                    message.To.Add("zakaz@aironic.ru");
                    message.To.Add("info@aironic.ru");

                    client.Send(message);

                    this.Profile.ShoppingCart.Clear();
                }
                catch
                {
                    lblAdopt.Text += "<p><b style=\"color:Red\">������ ��� �������� ������������� ������ �� ����������� �����.</b></p>";
                }
            }
        }
    }
}
