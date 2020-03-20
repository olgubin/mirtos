using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Net.Mail;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using UC;
using UC.Core;
using UC.UI;
using UC.BLL.Store;
//using UC.SmsUslugi;

namespace UC.UI.Controls
{
    public partial class OneClickOrderControl : BaseWebPart
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
            }

            //Если корзина пустая
            if (this.Profile.ShoppingCart.Items.Count == 0)
            {
                BreadCrumb.AddInActiveLink("Корзина");
                pnlEmptyCart.Visible = true;
                pnlOrder.Visible = false;
            }
            else
            {
                BreadCrumb.AddInActiveLink("Оформление заказа");
            }
        }

        protected void EmptyCart(object sender, EventArgs e)
        {
            // Если корзина пустая
            if (this.Profile.ShoppingCart.Items.Count == 0)
            {
                BreadCrumb.AddInActiveLink("Корзина");
                pnlEmptyCart.Visible = true;
                pnlOrder.Visible = false;
            }
        }

        protected void btnReserve_Click(object sender, EventArgs e)
        {
            string paymentMethod = "";

            if (rbtnCash.Checked) paymentMethod = "наличными при получении";
            if (rbtnCard.Checked) paymentMethod = "картой Visa или MasterCard";
            if (rbtnTranslation.Checked) paymentMethod = "банковский перевод";
            if (rbtnWire.Checked) paymentMethod = "безналичный расчет";
            //if (rbtnPOD.Checked) paymentMethod = "наложенный расчет";

            int orderID = Order.InsertOrder(
                this.Profile.ShoppingCart,
                paymentMethod,
                0,
                txtFIO.Text.Trim(),
                txtTelephone.Text.Trim(),
                txtEmail.Text.Trim(),
                txtAddress.Text.Trim(),
                txtComment.Text.Trim(),
                optlOptions.SelectedValue,
                "",
                "",
                "",
                "",
                "");

            string OrderNum = "";

            OrderNum = "MR-0" + orderID.ToString();

            string mainMsg = "";
            string formTxt = "";
            string userMsg = "";

            //SendSms
            //    (
            //    OrderNum,
            //    txtFIO.Text.Trim(),
            //    txtTelephone.Text.Trim(),
            //    Profile.ShoppingCart.Items
            //    );

            //SendClientSms
            //    (
            //    OrderNum,
            //    Pin,
            //    txtTelephone.Text.Trim(),
            //    (this.Page as BasePage).FormatPrice(this.Profile.ShoppingCart.Total)
            //    );

            formTxt += "<p>Благодарим Вас за заказ в интернет-магазине <b style=\"color: #76A933\">MIRTOS.RU</b>!</p><p>Номер Вашего заказа: ";
            userMsg += "<p>Благодарим Вас за заказ в интернет-магазине <b style=\"color: #76A933\">MIRTOS.RU</b>!</p><p>Номер Вашего заказа: ";
            mainMsg += "<p>Заказ № ";

            string body = "";
            body = body + "<b>{0}</b></p>";
            body = body + "<p><table style=\"font-family:Verdana,Arial;font-size:11px;\"><tr>";
            body = body + "<td style=\"width:170px\">Получатель:</td><td><b>" + txtFIO.Text.Trim() + "</b></td></tr>";
            body = body + "<tr><td>Телефон:</td><td><b>" + txtTelephone.Text.Trim() + "</b></td></tr>";
            body = body + "<tr><td>E-mail:</td><td><b>" + txtEmail.Text.Trim() + "</b></td></tr>";
            body = body + "<tr><td>Адрес доставки:</td><td>" + txtAddress.Text.Trim() + "</td></tr>";
            body = body + "<tr><td>Способ оплаты:</td><td><b>" + paymentMethod + "</b></td></tr>";
            //body = body + "<tr><td>ПИН код:</td><td><b>" + Pin + "</b></td></tr>";
            //if (!String.IsNullOrEmpty(promocode)) body = body + "<tr><td>Промокод:</td><td><b>" + promocode + "</b></td></tr>";
            body = body + "<tr><td>Комментарий к заказу:</td><td><b>" + txtComment.Text.Trim() + "<b/></td></tr>";
            body = body + "</table></p>";
            body = body + "{1}";
            body = body + "<p><table style=\"font-family:Verdana,Arial;font-size:11px;\">";

            //if (this.Profile.ShoppingCart.DiscountPercentage > 0)
            //{
            //    string discount = "";
            //    discount += "<tr><td style=\"width:170px\">Товаров на сумму:</td><td><b>{0}</b></td></tr>";
            //    discount += "<tr><td>Скидка:</td><td><b>{1}</b>. {2}% по дисконтной карте {3} № {4}</td></tr>";
            //    body = body +
            //           String.Format(discount, (this.Page as BasePage).FormatPrice(this.Profile.ShoppingCart.Total),
            //                         (this.Page as BasePage).FormatPrice(this.Profile.ShoppingCart.Discount),
            //                         this.Profile.ShoppingCart.DiscountPercentage,
            //                         this.Profile.ShoppingCart.DiscountCardName,
            //                         this.Profile.ShoppingCart.DiscountCardNumber);
            //}

            body = body + "<tr><td>Стоимость заказа: </td><td><b>{2}</b>. </td></tr>";
            body = body + "<tr><td>Стоимость доставки:</td><td> будет расчитана нашими менеджерами и сообщена Вам по телефону.</td></tr>";
            body = body + "</table></p>";

            string prim = "";
            prim = prim + "<p><b>Примечание:</b></p>";

            if (rbtnCash.Checked) prim = prim + "<p>Оплата должна быть произведена наличными, при доставке заказа, по указанному Вами адресу курьеру. Сумма к оплате будет включать стоимость заказа и стоимость доставки.";
            if (rbtnTranslation.Checked) prim = prim + "<p>Оплата должна быть произведена перечислением на наш расчетный счет суммы, согласно выставленной квитанции. Квитанция будет выставлена менеджером после подтверждения заказа по телефону и передана Вам по факсу или электронной почте.";
            if (rbtnWire.Checked) prim = prim + "<p>Оплату можно провести через любой банк, находящийся на территории РФ. На e-mail Вам будет выслан счет с реквизитами для оплаты. В поле &quot;Назначение платежа&quot; следует указать номер вашего заказа. Например, &quot;Заказ №8734&quot;.";

            prim = prim + "</p>";
            prim = prim + "<p>Вопросы, связанные с заказами, а также предложения и пожелания по работе магазина и службы доставки Вы можете направлять по адресу: <a href=\"mailto:mirtos@inbox.ru\">mirtos@inbox.ru</a>.</p>";

            string products = "";
            products = products + "<table style=\"font-family:Verdana,Arial;font-size:11px;\"><tr><th style=\"width:70px;height:30px\">Артикул</th><th>Наименование</th><th style=\"width:70px\">Кол-во</th><th style=\"width:100px\">Цена</th><th style=\"width:100px\">Сумма</th></tr>";
            foreach (ShoppingCartItem item in Profile.ShoppingCart.Items)
            {
                products = products + "<tr><td style=\"text-align:center;height:20px\">" + item.SKU + "</td><td><a href=\"http://www.mirtos.ru/ShowProduct.aspx?ID=" + item.ID.ToString() + "\">" + item.Title + "</a></td><td style=\"text-align:center\">" + item.Quantity.ToString() + "</td>";
                products = products + "<td style=\"text-align:right\">" + (this.Page as BasePage).FormatPrice(item.UnitPrice) + "</td><td style=\"text-align:right\">" + (this.Page as BasePage).FormatPrice(item.UnitPrice * item.Quantity) + "</td></tr>";
            }

            products = products + "</table>";

            body = String.Format(body, OrderNum + " от " + DateTime.Now.ToString("D"), products, (this.Page as BasePage).FormatPrice(this.Profile.ShoppingCart.Total));

            lblAdopt.Text = formTxt + body + prim + "<p style=\"text-align:left\">Служба заказов интернет-магазина <b style=\"color: #76A933\">MIRTOS.RU</b>.</p>";

            // Очищаем корзину
            this.Profile.ShoppingCart.Clear();

            // Отправляем письмо
            userMsg = "<div style=\"font-family:Verdana,Arial;font-size:11px;\"><p>Здравствуйте, " + txtFIO.Text.Trim() + "!</p>" + userMsg + body + prim + "<p>С уважением,<br/>администрация магазина MIRTOS.RU <br/>8 499 394 04 09, 8 495 005 53 95<br/>www.mirtos.ru</p></div>";
            mainMsg += "<div style=\"font-family:Verdana,Arial;font-size:11px;\">" + body + "<p>Mirtos.RU Климатическое оборудование <br/>8 499 394 04 09, 8 495 005 53 95<br/>www.mirtos.ru</p></div>";
            try
            {
                SmtpClient client = new SmtpClient();
                MailMessage message = new MailMessage();

                string storeName = "MIRTOS.RU Климатическое оборудование";

                //message.From = new MailAddress("zakaz@mirtos.ru", storeName, System.Text.Encoding.UTF8);
                //message.From = new MailAddress("info@mirtos.ru", storeName, System.Text.Encoding.UTF8);
                message.From = new MailAddress(SettingManager.GetSettingValue("Common.ZakazFrom"), storeName, System.Text.Encoding.UTF8);
                message.IsBodyHtml = true;
                message.Subject = "Mirtos.RU. " + "Заказ № " + OrderNum + " от " + DateTime.Now.ToString("D");

                message.Body = userMsg;

                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.SubjectEncoding = System.Text.Encoding.UTF8;
                message.Priority = System.Net.Mail.MailPriority.High;

                message.To.Add(txtEmail.Text.Trim());

                client.Send(message);

                message.Body = mainMsg;
                message.To.Clear();

                message.To.Add(SettingManager.GetSettingValue("Common.ZakazTo"));
                //message.To.Add("swapps@rambler.ru");
                
                // разбор адресов куда отправлять почту указанных в web.config
                //string[] mailTo = Globals.Settings.Store.BusinessEmail.Split(',');
                //foreach (string item in mailTo)
                //{
                //    message.To.Add(new MailAddress(item));
                //}

                client.Send(message);

                this.Profile.ShoppingCart.Clear();

                this.Response.Redirect("~/ConfirmOrder.aspx?id=" + orderID.ToString());

                //pnlAdopt.Visible = true;
                //pnlOrder.Visible = false;
                //pnlEmptyCart.Visible = false;
            }
            catch (Exception ex)
            {
                //new RecordCustomEvent("Ошибка при отправке почты." + ex.Message, null).Raise();
                this.Response.Redirect("~/ConfirmOrder.aspx?id=" + orderID.ToString());
                //pnlAdopt.Visible = true;
                //lblAdopt.Text += "<p><b style=\"color:Red\">Ошибка при отправке подтверждения заказа по электронной почте.</b></p>";
            }
        }

        //public void SendSms(string оrderNum, string FIO, string tel, ICollection items)
        //{
        //    string sms = "";

        //    sms += "Заказ № " + оrderNum+"\n";

        //    foreach (ShoppingCartItem item in items)
        //    {
        //        sms += "Арт. " + item.SKU + " " + item.Title + " " + (this.Page as BasePage).FormatPrice(item.UnitPrice) + " " + item.Quantity + " шт.;\n";
        //    }

        //    sms += "Имя: " + FIO + "\n";
        //    sms += "Тел: " + tel + "\n";

        //    List<string> smsToZakaz = new List<string>();

        //    //smsToZakaz.AddRange(SettingManager.GetSettingValue("SMS.ToZakaz").Split(','));
        //    //smsToZakaz.Add("89168222107");
        //    smsToZakaz.Add("89039610733");

        //    SmsUslugi.SendSMS
        //        (
        //        sms,
        //        smsToZakaz,
        //        "domis",
        //        "domis123",
        //        "Diktophone",
        //        "https://transport.sms-pager.com:7214/send.xml"
        //        );
        //}

        //public void SendClientSms(string оrderNum, string pin, string tel, string totalPrice)
        //{
        //    string sms = "";

        //    sms += "Заказ № " + оrderNum + " принят. Пин код заказа: " + pin + ". В ближайшее время с вами свяжется менеджер для уточнения условий оплаты и доставки товара.";

        //    List<string> smsToZakaz = new List<string>();

        //    smsToZakaz.AddRange(tel.Split(','));

        //    SmsUslugi.SendSMS
        //        (
        //        sms,
        //        smsToZakaz,
        //        "domis",
        //        "domis123",
        //        "Diktophone",
        //        "https://transport.sms-pager.com:7214/send.xml"
        //        );
        //}
    }
}