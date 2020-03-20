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
using UC.Core;

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

                //получение номера заказа

                string shippingMethod = "";

                switch (Profile.Payment.PaymentMethod)
                {
                    case UC.BLL.Store.PaymentMethod.Cash:
                        shippingMethod = "наличными при получении";
                        break;
                    case UC.BLL.Store.PaymentMethod.Translation:
                        shippingMethod = "банковский перевод";
                        break;
                    case UC.BLL.Store.PaymentMethod.Wire:
                        shippingMethod = "безналичный расчет";
                        break;
                }

                int orderID = Order.InsertOrder(
                    this.Profile.ShoppingCart,
                    shippingMethod,
                    0,
                    Profile.Address.FIO,
                    "",
                    Profile.Address.Street + " " + Profile.Address.House + "/" + Profile.Address.Ofis,
                    Profile.Address.PostCode,
                    Profile.Address.Gorod,
                    Profile.Address.Raion,
                    Profile.Address.Oblast,
                    user.Email,
                    Profile.Address.Tel,
                    Profile.Address.Comment,
                    "");

                string OrderNum = "";

                OrderNum = "DP-0" + orderID.ToString();

                string mainMsg = "";
                string formTxt = "";
                string userMsg = "";

                formTxt += "<p>Благодарим Вас за заказ в интернет-магазине <b style=\"color: #9aaab1\">" + SettingManager.GetSettingValue("Common.Domen") + "</b>!</p><p>Номер Вашего заказа: ";
                userMsg += "<p>Благодарим Вас за заказ в интернет-магазине <b style=\"color: #9aaab1\">" + SettingManager.GetSettingValue("Common.Domen") + "</b>!</p><p>Номер Вашего заказа: ";
                mainMsg += "<p>Заказ № ";

                string body = "";
                body = body + "<b>{0}</b></p>";
                body = body + "<p><table style=\"font-family:Verdana,Arial;font-size:11px;\"><tr>";
                body = body + "<td style=\"width:170px\">Получатель:</td><td><b>" + Profile.Address.FIO + "</b></td></tr>";
                body = body + "<tr><td>Телефон:</td><td><b>" + Profile.Address.Tel +"</b></td></tr>";
                body = body + "<tr><td>E-mail:</td><td><b>" + user.Email + "</b></td></tr>";
                body = body + "<tr><td>Адрес доставки:</td>";
                string address = "<td>";
                address = address + "Почтовый индекс: <b>" + Profile.Address.PostCode + "</b><br />";
                address = address + "Область: <b>" + Profile.Address.Oblast + "</b><br />";
                address = address + "Район: <b>" + Profile.Address.Raion + "</b><br />";
                address = address + "Город/поселок: <b>" + Profile.Address.Gorod + "</b><br />";
                address = address + "Улица: <b>" + Profile.Address.Street + "</b><br />";
                address = address + "Дом: <b>" + Profile.Address.House + "</b><br />";
                address = address + "Квартира/офис: <b>" + Profile.Address.Ofis + "</b><br />";
                address = address + "Комментарий: <b>" + Profile.Address.Comment + "</b>";
                body = body + address + "</td></tr>";
                switch (Profile.Payment.PaymentMethod)
                {
                    case UC.BLL.Store.PaymentMethod.Cash:
                        body = body + "<tr><td>Способ оплаты:</td><td><b>наличными при получении</b></td></tr>";
                        break;
                    case UC.BLL.Store.PaymentMethod.Translation:
                        body = body + "<tr><td>Способ оплаты:</td><td><b>банковский перевод</b></td></tr>";
                        break;
                    case UC.BLL.Store.PaymentMethod.Wire:
                        body = body + "<tr><td>Способ оплаты:</td><td><b>безналичный расчет</b></td></tr>";
                        break;
                }
                if (Profile.Payment.PaymentMethod == UC.BLL.Store.PaymentMethod.Wire)
                {
                    string payer = "<tr><td>Реквизиты плательщика:</td><td>";
                    if (!String.IsNullOrEmpty(Profile.Payer.Organization)) payer = payer + "организация: <b>" + Profile.Payer.Organization + "</b>";
                    if (!String.IsNullOrEmpty(Profile.Payer.UrAddress)) payer = payer + ", юридический адрес: <b>" + Profile.Payer.UrAddress + "</b>";
                    if (!String.IsNullOrEmpty(Profile.Payer.INN)) payer = payer + ", ИНН: <b>" + Profile.Payer.INN + "</b>";
                    if (!String.IsNullOrEmpty(Profile.Payer.KPP)) payer = payer + ", КПП: <b>" + Profile.Payer.KPP + "</b>";
                    if (!String.IsNullOrEmpty(Profile.Payer.OKPO)) payer = payer + ", ОКПО: <b>" + Profile.Payer.OKPO + "</b>";
                    if (!String.IsNullOrEmpty(Profile.Payer.OKONH)) payer = payer + ", ОКОНХ: <b>" + Profile.Payer.OKONH + "</b>";
                    if (!String.IsNullOrEmpty(Profile.Payer.Account)) payer = payer + ", р/счет: <b>" + Profile.Payer.Account + "</b>";
                    if (!String.IsNullOrEmpty(Profile.Payer.CorrAccount)) payer = payer + ", кор. счет: <b>" + Profile.Payer.CorrAccount + "</b>";
                    if (!String.IsNullOrEmpty(Profile.Payer.Bank)) payer = payer + ", банк: <b>" + Profile.Payer.Bank + "</b>";
                    if (!String.IsNullOrEmpty(Profile.Payer.BIK)) payer = payer + ", БИК: <b>" + Profile.Payer.BIK + "</b>";
                    if (!String.IsNullOrEmpty(Profile.Payer.PostAddress)) payer = payer + ", почтовый адрес: <b>" + Profile.Payer.PostAddress + "</b>";
                    body = body + payer+ "</td></tr>";
                }
                if (!String.IsNullOrEmpty(Comment)) body = body + "<tr><td>Комментарий к заказу:</td><td><b>" + Comment + "<b/></td></tr>";
                body = body + "</table></p>";
                body = body + "{1}";
                body = body + "<p>Стоимость заказа: <b>{2}</b>. <br/>Стоимость доставки: будет расчитана нашими менеджерами и сообщена Вам по телефону.</p>";

                string prim = "";
                prim = prim + "<p><b>Примечание:</b></p>";
                switch (Profile.Payment.PaymentMethod)
                {
                    case UC.BLL.Store.PaymentMethod.Cash:
                        prim = prim + "<p>Оплата должна быть произведена наличными, при доставке заказа, по указанному Вами адресу курьеру. Сумма к оплате будет включать стоимость заказа и стоимость доставки.";
                        break;
                    case UC.BLL.Store.PaymentMethod.Translation:
                        prim = prim + "<p>Оплата должна быть произведена перечислением на наш расчетный счет суммы, согласно выставленной квитанции. Квитанция будет выставлена менеджером после подтверждения заказа по телефону и передана Вам по факсу или электронной почте.";
                        break;
                    case UC.BLL.Store.PaymentMethod.Wire:
                        prim = prim + "<p>Оплату можно провести через любой банк, находящийся на территории РФ. На e-mail Вам будет выслан счет с реквизитами для оплаты. В поле &quot;Назначение платежа&quot; следует указать номер выставленного счета, его дату и НДС. Например, &quot;За товар по счету №8734 от 01.01.2006. Без НДС.&quot;.";
                        break;
                }
                prim = prim + "</p>";
                prim = prim + "<p>Вопросы, связанные с заказами, а также предложения и пожелания по работе магазина и службы доставки Вы можете направлять по адресу: <a href=\"mailto:" + SettingManager.GetSettingValue("Common.ZakazFrom") + "\">" + SettingManager.GetSettingValue("Common.ZakazFrom") + "</a>. Для нас важно знать Ваше мнение!</p><p><b style=\"color: #9aaab1\">Спасибо, что Вы выбрали нас!</b></p>";
                
                
                string products = "";
                products = products + "<table style=\"font-family:Verdana,Arial;font-size:11px;\"><tr><th style=\"width:70px;height:30px\">Артикул</th><th>Наименование</th><th style=\"width:70px\">Кол-во</th><th style=\"width:100px\">Цена</th><th style=\"width:100px\">Сумма</th></tr>";
                foreach (ShoppingCartItem item in Profile.ShoppingCart.Items)
                {
                    products = products + "<tr><td style=\"text-align:center;height:20px\">" + item.SKU + "</td><td><a href=\"" + SettingManager.GetSettingValue("Common.StoreURL") + "ShowProduct.aspx?ID=" + item.ID.ToString() + "\">" + item.Title + "</a></td><td style=\"text-align:center\">" + item.Quantity.ToString() + "</td>";
                    products = products + "<td style=\"text-align:right\">" + (this.Page as BasePage).FormatPrice(item.UnitPrice) + "</td><td style=\"text-align:right\">" + (this.Page as BasePage).FormatPrice(item.UnitPrice * item.Quantity) + "</td></tr>";
                }
                products = products + "</table>";

                body = String.Format(body, OrderNum + " от " + DateTime.Now.ToString("D"), products, (this.Page as BasePage).FormatPrice(this.Profile.ShoppingCart.Total));

                lblAdopt.Text = formTxt + body + prim + "<p style=\"text-align:left\">Служба заказов интернет-магазина <b style=\"color: #9aaab1\">" + SettingManager.GetSettingValue("Common.Domen") + "</b>.</p>";

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

                // Очищаем корзину
                this.Profile.ShoppingCart.Clear();

                // Отправляем письмо клиенту, на наши ящики и в виру на 2 ящика
                userMsg = "<p>Здравствуйте, " + user.Comment + "!</p>" + userMsg + body + prim + "<p>С уважением,<br/>администрация магазина " + SettingManager.GetSettingValue("Common.Domen") + " <br/>+7 " + SettingManager.GetSettingValue("Common.Phone") + "<br/>" + SettingManager.GetSettingValue("Common.Domen") + "</p>";
                mainMsg += body + "<p>" + SettingManager.GetSettingValue("Common.StoreName") + " <br/>+7 " + SettingManager.GetSettingValue("Common.Phone") + "<br/>" + SettingManager.GetSettingValue("Common.Domen") + "</p>";
                try
                {
                    SmtpClient client = new SmtpClient();
                    MailMessage message = new MailMessage();

                    string storeName = SettingManager.GetSettingValue("Common.StoreName");
                    storeName = storeName.Replace("–", "");
                    
                    message.From = new MailAddress(SettingManager.GetSettingValue("Common.ZakazFrom"), storeName, System.Text.Encoding.UTF8);
                    //message.From = new MailAddress(SettingManager.GetSettingValue("Common.ZakazTo"), storeName, System.Text.Encoding.UTF8);
                    message.IsBodyHtml = true;
                    message.Subject = "Заказ № " + OrderNum + " от " + DateTime.Now.ToString("D");

                    message.Body = userMsg;

                    message.BodyEncoding = System.Text.Encoding.UTF8;
                    message.SubjectEncoding = System.Text.Encoding.UTF8;
                    message.Priority = System.Net.Mail.MailPriority.High;

                    message.To.Add(user.Email);

                    client.Send(message);

                    message.Body = mainMsg;
                    message.To.Clear();

                    message.To.Add(SettingManager.GetSettingValue("Common.ZakazTo"));

                    client.Send(message);

                    this.Profile.ShoppingCart.Clear();
                }
                catch
                {
                    lblAdopt.Text += "<p><b style=\"color:Red\">Ошибка при отправке подтверждения заказа по электронной почте.</b></p>";
                }
            }
        }
    }
}
