<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MainMenu.ascx.cs" Inherits="UC.UI.Controls.MainMenu" %>
<asp:Table ID="Table1" CssClass="mainmenu" runat="server">
    <asp:TableRow>
        <asp:TableHeaderCell><asp:HyperLink runat="server" NavigateUrl="~/About.aspx">� ��������</asp:HyperLink></asp:TableHeaderCell>
        <asp:TableCell></asp:TableCell>
        <asp:TableHeaderCell><asp:HyperLink runat="server" NavigateUrl="~/Contact.aspx">��������</asp:HyperLink></asp:TableHeaderCell>
        <asp:TableCell></asp:TableCell>
        <asp:TableHeaderCell><asp:HyperLink runat="server" NavigateUrl="~/Service.aspx">������</asp:HyperLink></asp:TableHeaderCell>
        <asp:TableCell></asp:TableCell>
        <asp:TableHeaderCell><asp:HyperLink runat="server" NavigateUrl="~/Objects.aspx">�������</asp:HyperLink></asp:TableHeaderCell>
        <asp:TableCell></asp:TableCell>
        <asp:TableHeaderCell><asp:HyperLink runat="server" NavigateUrl="~/Design.aspx">��������������</asp:HyperLink></asp:TableHeaderCell>
        <asp:TableCell></asp:TableCell>
        <asp:TableHeaderCell><asp:HyperLink runat="server" NavigateUrl="~/Assembly.aspx">������</asp:HyperLink></asp:TableHeaderCell>
        <asp:TableCell></asp:TableCell>
        <asp:TableHeaderCell><asp:HyperLink runat="server" NavigateUrl="~/Guarantees.aspx">��������</asp:HyperLink></asp:TableHeaderCell>
        <asp:TableCell></asp:TableCell>
        <asp:TableHeaderCell><asp:HyperLink runat="server" NavigateUrl="~/Payments.aspx">������</asp:HyperLink></asp:TableHeaderCell>
        <asp:TableCell></asp:TableCell>        
        <asp:TableHeaderCell><asp:HyperLink runat="server" NavigateUrl="~/Shipping.aspx">��������</asp:HyperLink></asp:TableHeaderCell>
        <asp:TableCell ID="AdminSeparator" runat="server"></asp:TableCell>
        <asp:TableHeaderCell ID="AdminMenu" runat="server"><asp:HyperLink runat="server" NavigateUrl="~/Admin/Default.aspx">�����������������</asp:HyperLink></asp:TableHeaderCell>
    </asp:TableRow>
</asp:Table>
