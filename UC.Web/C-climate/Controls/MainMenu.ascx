<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MainMenu.ascx.cs" Inherits="UC.UI.Controls.MainMenu" %>
<%@ Import Namespace="UC.SEOHelper"%>
<asp:Table ID="Table1" CssClass="mainmenu" runat="server">
    <asp:TableRow>
        <asp:TableHeaderCell><asp:HyperLink runat="server" NavigateUrl='<%# SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/About.aspx"))%>'>О компании</asp:HyperLink></asp:TableHeaderCell>
        <asp:TableCell></asp:TableCell>       
        <asp:TableHeaderCell><asp:HyperLink runat="server" NavigateUrl='<%# SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/Contact.aspx"))%>'>Контакты</asp:HyperLink></asp:TableHeaderCell>
        <asp:TableCell></asp:TableCell>
        <asp:TableHeaderCell><asp:HyperLink runat="server" NavigateUrl='<%# SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/Service.aspx"))%>'>Сервис</asp:HyperLink></asp:TableHeaderCell>
        <asp:TableCell></asp:TableCell>
<%--        <asp:TableHeaderCell><asp:HyperLink runat="server" NavigateUrl='<%# SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/Objects.aspx"))%>'>Объекты</asp:HyperLink></asp:TableHeaderCell>
        <asp:TableCell></asp:TableCell>--%>
        <asp:TableHeaderCell><asp:HyperLink runat="server" NavigateUrl='<%# SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/Design.aspx"))%>'>Проектирование</asp:HyperLink></asp:TableHeaderCell>
        <asp:TableCell></asp:TableCell>
        <asp:TableHeaderCell><asp:HyperLink runat="server" NavigateUrl='<%# SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/Assembly.aspx"))%>'>Монтаж</asp:HyperLink></asp:TableHeaderCell>
        <asp:TableCell></asp:TableCell>
        <asp:TableHeaderCell><asp:HyperLink runat="server" NavigateUrl='<%# SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/Guarantees.aspx"))%>'>Гарантии</asp:HyperLink></asp:TableHeaderCell>
        <asp:TableCell></asp:TableCell>
        <asp:TableHeaderCell><asp:HyperLink runat="server" NavigateUrl='<%# SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/Payments.aspx"))%>'>Оплата</asp:HyperLink></asp:TableHeaderCell>
        <asp:TableCell></asp:TableCell>        
        <asp:TableHeaderCell><asp:HyperLink runat="server" NavigateUrl='<%# SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/Shipping.aspx"))%>'>Доставка</asp:HyperLink></asp:TableHeaderCell>
        <asp:TableCell ID="_adminSeparator" runat="server"></asp:TableCell>
        <asp:TableHeaderCell ID="_adminMenu" runat="server"><asp:HyperLink runat="server" NavigateUrl='<%# SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/Admin/Default.aspx"))%>'>Администрирование</asp:HyperLink></asp:TableHeaderCell>
    </asp:TableRow>
</asp:Table>
