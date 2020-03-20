<%@ Page Language="C#" MasterPageFile="Admin.master" AutoEventWireup="true"
    CodeFile="RefreshParsingCatalog.aspx.cs" Inherits="UC.UI.Admin.RefreshParsingCatalog"
    Culture="auto" UICulture="auto" %>

<%@ Register Src="../Controls/RefreshParsingProductListing.ascx" TagName="ProductListing" TagPrefix="mb" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="breadcrumb">
        <table>
            <tr>
                <td class="h1">
                    <a href="../Default.aspx">Климатическое оборудование</a>
                </td>
                <td class="s">
                    |</td>
                <td class="h1">
                    <a href="Default.aspx">Администрирование</a>
                </td>
                <td class="s">
                    |</td>
                <td class="h1">
                    <a href="ManageParsingCatalogs.aspx">Управление каталогами</a>
                </td>
                <td class="s">
                    |</td>                
                <td class="h1">
                    <asp:HyperLink runat="server" ID="lnkCatalogTitle"></asp:HyperLink>
                </td>
            </tr>
        </table>
    </div>
    <mb:ProductListing ID="ProductListing1" runat="server" />
</asp:Content>
