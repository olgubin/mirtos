<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ConfirmOrder.ascx.cs"
    Inherits="UC.UI.Controls.ConfirmOrder" %>
<asp:Table ID="Table1" runat="server" Width="100%">
<asp:TableRow CssClass="alt_row">
<asp:TableCell CssClass="fieldcaption" Width="170px">Получатель:
</asp:TableCell>
<asp:TableCell ID="tdFIO" CssClass="fieldtext">
</asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell CssClass="fieldcaption">Телефон:
</asp:TableCell>
<asp:TableCell ID="tdTel" CssClass="fieldtext">
</asp:TableCell>
</asp:TableRow>
<asp:TableRow CssClass="alt_row">
<asp:TableCell CssClass="fieldcaption">Адрес получателя:
</asp:TableCell>
<asp:TableCell CssClass="fieldtext" ID="tdAddress">
</asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell CssClass="fieldcaption">Способ оплаты:
</asp:TableCell>
<asp:TableCell CssClass="fieldtext" ID="tdPayment">
</asp:TableCell>
</asp:TableRow>
<asp:TableRow ID="trPayer"  CssClass="alt_row">
<asp:TableCell CssClass="fieldcaption">Реквизиты плательщика:
</asp:TableCell>
<asp:TableCell CssClass="fieldtext" ID="tdPayer">
</asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell CssClass="fieldcaption" Width="170px">Комментарий к заказу (например, желаемое время доставки):
</asp:TableCell>
<asp:TableCell CssClass="fieldtext">
<asp:TextBox runat="server" ID="txtComment" Rows="5" Width="100%" TextMode="MultiLine" MaxLength="1024"/>
</asp:TableCell>
</asp:TableRow>
</asp:Table>
<br />

