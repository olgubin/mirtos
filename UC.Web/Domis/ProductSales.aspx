<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="ProductSales.aspx.cs" Inherits="UC.UI.ProductSales" Culture="auto"
    UICulture="auto" %>

<%@ MasterType VirtualPath="~/Template.master" %>
<%@ Register Src="~/Controls/ProductSalesListing.ascx" TagName="ProductSalesListing"
    TagPrefix="mb" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="breadcrumb">
        <table>
            <tr>
                <td class="h1">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Мебель для ванной</asp:HyperLink></td>
                <td><h1>Товары со скидкой</h1></td>
            </tr>
        </table>
    </div>
    <div id="content">
        <mb:ProductSalesListing ID="ProductSalesListing" runat="server" />
    </div>
</asp:Content>
