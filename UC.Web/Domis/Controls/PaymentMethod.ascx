<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PaymentMethod.ascx.cs"
    Inherits="UC.UI.Controls.PaymentMethod" %>
<table>
    <tr style="background-color: #fef7f8">
        <td>
            <asp:RadioButton runat="server" ID="rbtnCash" GroupName="Payment" Checked="true" />
        </td>
        <td class="fieldcaption">
            <asp:Label ID="Label1" runat="server" AssociatedControlID="rbtnCash">
                            <strong>Оплата наличными</strong>
                            <br/>
                            Вы оплачиваете товар наличными при доставке. Оплата производится только в рублях.
            </asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:RadioButton runat="server" ID="rbtnTranslation" GroupName="Payment"/>
        </td>
        <td class="fieldcaption">
            <asp:Label ID="Label2" runat="server" AssociatedControlID="rbtnTranslation">
<strong>Банковский перевод</strong>
<br/>
Вам на e-mail или факс (по желанию) высылается счет с реквизитами для оплаты. В поле "Назначение платежа" следует указать номер выставленного счета, его дату и НДС. Например, "За товар по счету №8734 от 01.01.2009. Без НДС.". Отгрузка заказа осуществляется в течение 1 дня.
            </asp:Label>
        </td>
    </tr>
    <tr style="background-color: #fef7f8">
        <td>
            <asp:RadioButton runat="server" ID="rbtnWire" GroupName="Payment" />
        </td>
        <td class="fieldcaption">
            <asp:Label ID="Label3" runat="server" AssociatedControlID="rbtnWire">
<strong>Безналичный расчет</strong>
(только для юридических лиц)
<br/>
Для оплаты товара по безналичному расчету юридическим лицам после поступления заказа высылается счет.
            </asp:Label>
        </td>
    </tr>
</table>
