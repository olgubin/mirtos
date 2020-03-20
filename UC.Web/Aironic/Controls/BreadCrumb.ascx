<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BreadCrumb.ascx.cs" Inherits="UC.UI.Controls.BreadCrumb" %>
<%@ Import Namespace="UC.UI" %>
<div class="breadcrumb">
    <asp:Table runat="server">
        <asp:TableRow ID="rowBreadCrumb" runat="server">
            <asp:TableCell><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx" EnableViewState="false">Главная</asp:HyperLink></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</div>
