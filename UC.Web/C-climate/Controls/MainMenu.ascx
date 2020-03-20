<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MainMenu.ascx.cs" Inherits="UC.UI.Controls.MainMenu" %>
<%@ Import Namespace="UC.SEOHelper"%>
<asp:Table ID="Table1" CssClass="mainmenu" runat="server">
    <asp:TableRow>
        <asp:TableHeaderCell><asp:HyperLink runat="server" NavigateUrl='<%# SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/About.aspx"))%>'>� ��������</asp:HyperLink></asp:TableHeaderCell>
        <asp:TableCell></asp:TableCell>       
        <asp:TableHeaderCell><asp:HyperLink runat="server" NavigateUrl='<%# SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/Contact.aspx"))%>'>��������</asp:HyperLink></asp:TableHeaderCell>
        <asp:TableCell></asp:TableCell>
        <asp:TableHeaderCell><asp:HyperLink runat="server" NavigateUrl='<%# SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/Service.aspx"))%>'>������</asp:HyperLink></asp:TableHeaderCell>
        <asp:TableCell></asp:TableCell>
<%--        <asp:TableHeaderCell><asp:HyperLink runat="server" NavigateUrl='<%# SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/Objects.aspx"))%>'>�������</asp:HyperLink></asp:TableHeaderCell>
        <asp:TableCell></asp:TableCell>--%>
        <asp:TableHeaderCell><asp:HyperLink runat="server" NavigateUrl='<%# SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/Design.aspx"))%>'>��������������</asp:HyperLink></asp:TableHeaderCell>
        <asp:TableCell></asp:TableCell>
        <asp:TableHeaderCell><asp:HyperLink runat="server" NavigateUrl='<%# SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/Assembly.aspx"))%>'>������</asp:HyperLink></asp:TableHeaderCell>
        <asp:TableCell></asp:TableCell>
        <asp:TableHeaderCell><asp:HyperLink runat="server" NavigateUrl='<%# SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/Guarantees.aspx"))%>'>��������</asp:HyperLink></asp:TableHeaderCell>
        <asp:TableCell></asp:TableCell>
        <asp:TableHeaderCell><asp:HyperLink runat="server" NavigateUrl='<%# SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/Payments.aspx"))%>'>������</asp:HyperLink></asp:TableHeaderCell>
        <asp:TableCell></asp:TableCell>        
        <asp:TableHeaderCell><asp:HyperLink runat="server" NavigateUrl='<%# SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/Shipping.aspx"))%>'>��������</asp:HyperLink></asp:TableHeaderCell>
        <asp:TableCell ID="_adminSeparator" runat="server"></asp:TableCell>
        <asp:TableHeaderCell ID="_adminMenu" runat="server"><asp:HyperLink runat="server" NavigateUrl='<%# SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/Admin/Default.aspx"))%>'>�����������������</asp:HyperLink></asp:TableHeaderCell>
    </asp:TableRow>
</asp:Table>
