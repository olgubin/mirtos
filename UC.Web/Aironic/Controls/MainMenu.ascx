<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MainMenu.ascx.cs" Inherits="UC.UI.Controls.MainMenu" %>
<asp:Table ID="Table1" CssClass="mainmenu" runat="server">
    <asp:TableRow>
        <asp:TableHeaderCell><asp:HyperLink runat="server" NavigateUrl="~/About.aspx">О компании</asp:HyperLink></asp:TableHeaderCell>
        <asp:TableCell></asp:TableCell>
        <asp:TableHeaderCell><asp:HyperLink runat="server" NavigateUrl="~/Contact.aspx">Контакты</asp:HyperLink></asp:TableHeaderCell>
        <asp:TableCell></asp:TableCell>
        <asp:TableHeaderCell><asp:HyperLink runat="server" NavigateUrl="~/Service.aspx">Сервис</asp:HyperLink></asp:TableHeaderCell>
        <asp:TableCell></asp:TableCell>
        <asp:TableHeaderCell><asp:HyperLink runat="server" NavigateUrl="~/Objects.aspx">Объекты</asp:HyperLink></asp:TableHeaderCell>
        <asp:TableCell></asp:TableCell>
        <asp:TableHeaderCell><asp:HyperLink runat="server" NavigateUrl="~/Design.aspx">Проектирование</asp:HyperLink></asp:TableHeaderCell>
        <asp:TableCell></asp:TableCell>
        <asp:TableHeaderCell><asp:HyperLink runat="server" NavigateUrl="~/Assembly.aspx">Монтаж</asp:HyperLink></asp:TableHeaderCell>
        <asp:TableCell></asp:TableCell>
        <asp:TableHeaderCell><asp:HyperLink runat="server" NavigateUrl="~/Guarantees.aspx">Гарантии</asp:HyperLink></asp:TableHeaderCell>
        <asp:TableCell></asp:TableCell>
        <asp:TableHeaderCell><asp:HyperLink runat="server" NavigateUrl="~/Payments.aspx">Оплата</asp:HyperLink></asp:TableHeaderCell>
        <asp:TableCell></asp:TableCell>        
        <asp:TableHeaderCell><asp:HyperLink runat="server" NavigateUrl="~/Shipping.aspx">Доставка</asp:HyperLink></asp:TableHeaderCell>
        <asp:TableCell ID="AdminSeparator" runat="server"></asp:TableCell>
        <asp:TableHeaderCell ID="AdminMenu" runat="server"><asp:HyperLink runat="server" NavigateUrl="~/Admin/Default.aspx">Администрирование</asp:HyperLink></asp:TableHeaderCell>
    </asp:TableRow>
</asp:Table>
