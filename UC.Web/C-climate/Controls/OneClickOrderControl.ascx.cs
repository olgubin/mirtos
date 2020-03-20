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

            //���� ������� ������
            if (this.Profile.ShoppingCart.Items.Count == 0)
            {
                BreadCrumb.AddInActiveLink("�������");
                pnlEmptyCart.Visible = true;
                pnlOrder.Visible = false;
            }
            else
            {
                BreadCrumb.AddInActiveLink("���������� ������");
            }
        }

        protected void EmptyCart(object sender, EventArgs e)
        {
            // ���� ������� ������
            if (this.Profile.ShoppingCart.Items.Count == 0)
            {
                BreadCrumb.AddInActiveLink("�������");
                pnlEmptyCart.Visible = true;
                pnlOrder.Visible = false;
            }
        }

        protected void btnReserve_Click(object sender, EventArgs e)
        {
            string paymentMethod = "";

            if (rbtnCash.Checked) paymentMethod = "��������� ��� ���������";
            if (rbtnCard.Checked) paymentMethod = "������ Visa ��� MasterCard";
            if (rbtnTranslation.Checked) paymentMethod = "���������� �������";
            if (rbtnWire.Checked) paymentMethod = "����������� ������";
            //if (rbtnPOD.Checked) paymentMethod = "���������� ������";

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

            formTxt += "<p>���������� ��� �� ����� � ��������-�������� <b style=\"color: #76A933\">MIRTOS.RU</b>!</p><p>����� ������ ������: ";
            userMsg += "<p>���������� ��� �� ����� � ��������-�������� <b style=\"color: #76A933\">MIRTOS.RU</b>!</p><p>����� ������ ������: ";
            mainMsg += "<p>����� � ";

            string body = "";
            body = body + "<b>{0}</b></p>";
            body = body + "<p><table style=\"font-family:Verdana,Arial;font-size:11px;\"><tr>";
            body = body + "<td style=\"width:170px\">����������:</td><td><b>" + txtFIO.Text.Trim() + "</b></td></tr>";
            body = body + "<tr><td>�������:</td><td><b>" + txtTelephone.Text.Trim() + "</b></td></tr>";
            body = body + "<tr><td>E-mail:</td><td><b>" + txtEmail.Text.Trim() + "</b></td></tr>";
            body = body + "<tr><td>����� ��������:</td><td>" + txtAddress.Text.Trim() + "</td></tr>";
            body = body + "<tr><td>������ ������:</td><td><b>" + paymentMethod + "</b></td></tr>";
            //body = body + "<tr><td>��� ���:</td><td><b>" + Pin + "</b></td></tr>";
            //if (!String.IsNullOrEmpty(promocode)) body = body + "<tr><td>��������:</td><td><b>" + promocode + "</b></td></tr>";
            body = body + "<tr><td>����������� � ������:</td><td><b>" + txtComment.Text.Trim() + "<b/></td></tr>";
            body = body + "</table></p>";
            body = body + "{1}";
            body = body + "<p><table style=\"font-family:Verdana,Arial;font-size:11px;\">";

            //if (this.Profile.ShoppingCart.DiscountPercentage > 0)
            //{
            //    string discount = "";
            //    discount += "<tr><td style=\"width:170px\">������� �� �����:</td><td><b>{0}</b></td></tr>";
            //    discount += "<tr><td>������:</td><td><b>{1}</b>. {2}% �� ���������� ����� {3} � {4}</td></tr>";
            //    body = body +
            //           String.Format(discount, (this.Page as BasePage).FormatPrice(this.Profile.ShoppingCart.Total),
            //                         (this.Page as BasePage).FormatPrice(this.Profile.ShoppingCart.Discount),
            //                         this.Profile.ShoppingCart.DiscountPercentage,
            //                         this.Profile.ShoppingCart.DiscountCardName,
            //                         this.Profile.ShoppingCart.DiscountCardNumber);
            //}

            body = body + "<tr><td>��������� ������: </td><td><b>{2}</b>. </td></tr>";
            body = body + "<tr><td>��������� ��������:</td><td> ����� ��������� ������ ����������� � �������� ��� �� ��������.</td></tr>";
            body = body + "</table></p>";

            string prim = "";
            prim = prim + "<p><b>����������:</b></p>";

            if (rbtnCash.Checked) prim = prim + "<p>������ ������ ���� ����������� ���������, ��� �������� ������, �� ���������� ���� ������ �������. ����� � ������ ����� �������� ��������� ������ � ��������� ��������.";
            if (rbtnTranslation.Checked) prim = prim + "<p>������ ������ ���� ����������� ������������� �� ��� ��������� ���� �����, �������� ������������ ���������. ��������� ����� ���������� ���������� ����� ������������� ������ �� �������� � �������� ��� �� ����� ��� ����������� �����.";
            if (rbtnWire.Checked) prim = prim + "<p>������ ����� �������� ����� ����� ����, ����������� �� ���������� ��. �� e-mail ��� ����� ������ ���� � ����������� ��� ������. � ���� &quot;���������� �������&quot; ������� ������� ����� ������ ������. ��������, &quot;����� �8734&quot;.";

            prim = prim + "</p>";
            prim = prim + "<p>�������, ��������� � ��������, � ����� ����������� � ��������� �� ������ �������� � ������ �������� �� ������ ���������� �� ������: <a href=\"mailto:mirtos@inbox.ru\">mirtos@inbox.ru</a>.</p>";

            string products = "";
            products = products + "<table style=\"font-family:Verdana,Arial;font-size:11px;\"><tr><th style=\"width:70px;height:30px\">�������</th><th>������������</th><th style=\"width:70px\">���-��</th><th style=\"width:100px\">����</th><th style=\"width:100px\">�����</th></tr>";
            foreach (ShoppingCartItem item in Profile.ShoppingCart.Items)
            {
                products = products + "<tr><td style=\"text-align:center;height:20px\">" + item.SKU + "</td><td><a href=\"http://www.mirtos.ru/ShowProduct.aspx?ID=" + item.ID.ToString() + "\">" + item.Title + "</a></td><td style=\"text-align:center\">" + item.Quantity.ToString() + "</td>";
                products = products + "<td style=\"text-align:right\">" + (this.Page as BasePage).FormatPrice(item.UnitPrice) + "</td><td style=\"text-align:right\">" + (this.Page as BasePage).FormatPrice(item.UnitPrice * item.Quantity) + "</td></tr>";
            }

            products = products + "</table>";

            body = String.Format(body, OrderNum + " �� " + DateTime.Now.ToString("D"), products, (this.Page as BasePage).FormatPrice(this.Profile.ShoppingCart.Total));

            lblAdopt.Text = formTxt + body + prim + "<p style=\"text-align:left\">������ ������� ��������-�������� <b style=\"color: #76A933\">MIRTOS.RU</b>.</p>";

            // ������� �������
            this.Profile.ShoppingCart.Clear();

            // ���������� ������
            userMsg = "<div style=\"font-family:Verdana,Arial;font-size:11px;\"><p>������������, " + txtFIO.Text.Trim() + "!</p>" + userMsg + body + prim + "<p>� ���������,<br/>������������� �������� MIRTOS.RU <br/>8 499 394 04 09, 8 495 005 53 95<br/>www.mirtos.ru</p></div>";
            mainMsg += "<div style=\"font-family:Verdana,Arial;font-size:11px;\">" + body + "<p>Mirtos.RU ������������� ������������ <br/>8 499 394 04 09, 8 495 005 53 95<br/>www.mirtos.ru</p></div>";
            try
            {
                SmtpClient client = new SmtpClient();
                MailMessage message = new MailMessage();

                string storeName = "MIRTOS.RU ������������� ������������";

                //message.From = new MailAddress("zakaz@mirtos.ru", storeName, System.Text.Encoding.UTF8);
                //message.From = new MailAddress("info@mirtos.ru", storeName, System.Text.Encoding.UTF8);
                message.From = new MailAddress(SettingManager.GetSettingValue("Common.ZakazFrom"), storeName, System.Text.Encoding.UTF8);
                message.IsBodyHtml = true;
                message.Subject = "Mirtos.RU. " + "����� � " + OrderNum + " �� " + DateTime.Now.ToString("D");

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
                
                // ������ ������� ���� ���������� ����� ��������� � web.config
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
                //new RecordCustomEvent("������ ��� �������� �����." + ex.Message, null).Raise();
                this.Response.Redirect("~/ConfirmOrder.aspx?id=" + orderID.ToString());
                //pnlAdopt.Visible = true;
                //lblAdopt.Text += "<p><b style=\"color:Red\">������ ��� �������� ������������� ������ �� ����������� �����.</b></p>";
            }
        }

        //public void SendSms(string �rderNum, string FIO, string tel, ICollection items)
        //{
        //    string sms = "";

        //    sms += "����� � " + �rderNum+"\n";

        //    foreach (ShoppingCartItem item in items)
        //    {
        //        sms += "���. " + item.SKU + " " + item.Title + " " + (this.Page as BasePage).FormatPrice(item.UnitPrice) + " " + item.Quantity + " ��.;\n";
        //    }

        //    sms += "���: " + FIO + "\n";
        //    sms += "���: " + tel + "\n";

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

        //public void SendClientSms(string �rderNum, string pin, string tel, string totalPrice)
        //{
        //    string sms = "";

        //    sms += "����� � " + �rderNum + " ������. ��� ��� ������: " + pin + ". � ��������� ����� � ���� �������� �������� ��� ��������� ������� ������ � �������� ������.";

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