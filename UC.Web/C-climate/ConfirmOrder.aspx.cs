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
using UC.Core;
using UC.UI;
using UC.BLL.Store;
using System.Net.Mail;

namespace UC.UI
{
    public partial class ConfirmOrder : BasePage
    {
        int _orderID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            //������ ������� ���������� ��������
            BaseWebPart cartBox = base.Master.FindControl("ShoppingCartBox") as BaseWebPart;
            if (cartBox != null)
            {
                cartBox.Visible = false;
            }

            BreadCrumb.AddInActiveLink("������������� ������");

            if (string.IsNullOrEmpty(this.Request.QueryString["id"]))
                _orderID = 0;
            else
                _orderID = int.Parse(this.Request.QueryString["id"]);

            Order order = Order.GetOrderByID(_orderID);

            if (order!=null)
            {
                string OrderNum = "";

                OrderNum = "MR-0" + _orderID.ToString();

                string formTxt = "";

                formTxt += "<p>���������� ��� �� ����� � ��������-�������� <b style=\"color: #132f69\">MIRTOS.RU</b>!</p><p>����� ������ ������: ";

                string fio = order.ShippingFirstName.Trim();
                string phone = order.ShippingLastName.Trim();
                string email = order.ShippingStreet.Trim();
                string address = order.ShippingPostalCode.Trim();
                string paymethod = order.ShippingMethod.Trim();
                string comment = order.ShippingCity.Trim();

                decimal total = order.SubTotal;

                string body = "";
                body = body + "<b>{0}</b></p>";
                body = body + "<p><table style=\"font-family:Verdana,Arial;font-size:11px;\"><tr>";
                body = body + "<td style=\"width:170px\">����������:</td><td><b>" + fio + "</b></td></tr>";
                body = body + "<tr><td>�������:</td><td><b>" + phone + "</b></td></tr>";
                body = body + "<tr><td>E-mail:</td><td><b>" + email + "</b></td></tr>";
                body = body + "<tr><td>����� ��������:</td><td>" + address + "</td></tr>";
                body = body + "<tr><td>������ ������:</td><td><b>" + paymethod + "</b></td></tr>";
                //body = body + "<tr><td>��� ���:</td><td><b>" + PIN + "</b></td></tr>";
                //if (!String.IsNullOrEmpty(promocode)) body = body + "<tr><td>��������:</td><td><b>" + promocode + "</b></td></tr>";
                body = body + "<tr><td>����������� � ������:</td><td><b>" + comment + "<b/></td></tr>";
                body = body + "</table></p>";
                body = body + "{1}";
                body = body + "<p><table style=\"font-family:Verdana,Arial;font-size:11px;\">";

                //if (discountPercentage > 0)
                //{
                //    string discount = "";
                //    discount += "<tr><td style=\"width:170px\">������� �� �����:</td><td><b>{0}</b></td></tr>";
                //    discount += "<tr><td>������:</td><td><b>{1}</b>. {2}% �� ���������� ����� {3} � {4}</td></tr>";
                //    body = body +
                //           String.Format(discount, (this.Page as BasePage).FormatPrice(total),
                //                         (this.Page as BasePage).FormatPrice(orderdiscount),
                //                         discountPercentage,
                //                         discountCardName,
                //                         discountCardNumber);
                //}

                body = body + "<tr><td>��������� ������: </td><td><b>{2}</b>. </td></tr>";
                body = body + "<tr><td>��������� ��������:</td><td> ����� ��������� ������ ����������� � �������� ��� �� ��������.</td></tr>";
                body = body + "</table></p>";

                string prim = "";
                prim = prim + "<p><b>����������:</b></p>";

                if (paymethod == "��������� ��� ���������") prim = prim + "<p>������ ������ ���� ����������� ���������, ��� �������� ������, �� ���������� ���� ������ �������. ����� � ������ ����� �������� ��������� ������ � ��������� ��������.";
                if (paymethod == "���������� �������") prim = prim + "<p>������ ������ ���� ����������� ������������� �� ��� ��������� ���� �����, �������� ������������ ���������. ��������� ����� ���������� ���������� ����� ������������� ������ �� �������� � �������� ��� �� ����� ��� ����������� �����.";
                if (paymethod == "����������� ������") prim = prim + "<p>������ ����� �������� ����� ����� ����, ����������� �� ���������� ��. �� e-mail ��� ����� ������ ���� � ����������� ��� ������. � ���� &quot;���������� �������&quot; ������� ������� ����� ������ ������. ��������, &quot;����� � MR-0237&quot;.";
                if (paymethod == "���������� ������") prim = prim + "<p>�� ����������� ����� � ��������� ����� ������ �� ���������� ������. �������� ��� �������� ������ ������.";

                prim = prim + "</p>";
                prim = prim + "<p>�������, ��������� � ��������, � ����� ����������� � ��������� �� ������ �������� � ������ �������� �� ������ ���������� �� ������: <a href=\"mailto:mirtos@inbox.ru\">mirtos@inbox.ru</a>.</p>";
                //prim = prim + "<p>���������� ������ �� ������ ����� ��������� <a href='http://market.yandex.ru/shop-opinions.xml?shop_id=862&from=862'>������ ������</a>, <a href='http://torg.mail.ru/client/rating/add/?client_id=9822'>������@Mail.ru</a>. ��� ����� ���� ������!</p><p><b style=\"color: #76A933\">�������, ��� �� ������� ���!</b></p>";

                string products = "";
                products = products + "<table style=\"font-family:Verdana,Arial;font-size:11px;\"><tr><th style=\"width:70px;height:30px\">�������</th><th>������������</th><th style=\"width:70px\">���-��</th><th style=\"width:100px\">����</th><th style=\"width:100px\">�����</th></tr>";

                foreach (OrderItem item in order.Items)
                {
                    products = products + "<tr><td style=\"text-align:center;height:20px\">" + item.SKU + "</td><td><a href=\"http://www.mirtos.ru/ShowProduct.aspx?ID=" + item.ID.ToString() + "\">" + item.Title + "</a></td><td style=\"text-align:center\">" + item.Quantity.ToString() + "</td>";
                    products = products + "<td style=\"text-align:right\">" + (this.Page as BasePage).FormatPrice(item.UnitPrice) + "</td><td style=\"text-align:right\">" + (this.Page as BasePage).FormatPrice(item.UnitPrice * item.Quantity) + "</td></tr>";                    
                }

                products = products + "</table>";

                body = String.Format(body, OrderNum + " �� " + DateTime.Now.ToString("D"), products, (this.Page as BasePage).FormatPrice(total));

                lblAdopt.Text = formTxt + body + prim + "<p style=\"text-align:left\">������ ������� ��������-�������� <b style=\"color: #132f69\">MIRTOS.RU</b>.</p>";
            }
            else
            {
                lblAdopt.Text += "<p><b style=\"color:Red\">���� ������� �����. ���� ��� ���������� ������ �������� ���������. ���������, ����������, � ��������� �� ��������. �������� ��������� �� ��������� ����������.</b></p>";
            }
        }
    }
}