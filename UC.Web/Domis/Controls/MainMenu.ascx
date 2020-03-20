<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MainMenu.ascx.cs" Inherits="UC.UI.Controls.MainMenu" %>
<%@ Import Namespace="UC.SEOHelper"%>
<asp:Table ID="Table1" CssClass="mainmenu" runat="server">
    <asp:TableRow>
        <asp:TableHeaderCell><asp:HyperLink runat="server" NavigateUrl='<%# SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/About.aspx"))%>'>О компании</asp:HyperLink></asp:TableHeaderCell>
        <asp:TableHeaderCell><asp:HyperLink runat="server" NavigateUrl='<%# SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/AboutProducts.aspx"))%>'>О продукции</asp:HyperLink></asp:TableHeaderCell>
        <asp:TableHeaderCell><asp:HyperLink runat="server" NavigateUrl='<%# SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/Contact.aspx"))%>'>Контакты</asp:HyperLink></asp:TableHeaderCell>
        <asp:TableHeaderCell><asp:HyperLink runat="server" NavigateUrl='<%# SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/Guarantees.aspx"))%>'>Гарантии</asp:HyperLink></asp:TableHeaderCell>
        <asp:TableHeaderCell><asp:HyperLink runat="server" NavigateUrl='<%# SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/Payments.aspx"))%>'>Оплата</asp:HyperLink></asp:TableHeaderCell>
        <asp:TableHeaderCell><asp:HyperLink runat="server" NavigateUrl='<%# SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/Shipping.aspx"))%>'>Доставка</asp:HyperLink></asp:TableHeaderCell>
<%--        <asp:TableHeaderCell><asp:HyperLink runat="server" NavigateUrl='<%# SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/Assembly.aspx"))%>'>Монтаж</asp:HyperLink></asp:TableHeaderCell>
        <asp:TableHeaderCell><asp:HyperLink runat="server" NavigateUrl='<%# SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/Service.aspx"))%>'>Сервис</asp:HyperLink></asp:TableHeaderCell>--%>
        <asp:TableHeaderCell><asp:HyperLink runat="server" NavigateUrl='<%# SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/SiteMap.aspx"))%>'>Карта сайта</asp:HyperLink></asp:TableHeaderCell>
        <asp:TableHeaderCell ID="_adminMenu" runat="server"><asp:HyperLink runat="server" NavigateUrl='<%# SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/Admin/Default.aspx"))%>'>Администрирование</asp:HyperLink></asp:TableHeaderCell>
    </asp:TableRow>
</asp:Table>
