<%@ Page Language="C#" MasterPageFile="Admin.master" AutoEventWireup="true" CodeFile="ManageParsingProducts.aspx.cs" Inherits="UC.UI.Admin.ManageParsingProducts" Culture="auto" UICulture="auto" MaintainScrollPositionOnPostback="true" %>
<%@ Register Src="../Controls/ParsingProductListing.ascx" TagName="ProductListing" TagPrefix="mb" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="breadcrumb">
        <table>
            <tr>
                <td class="h1">
                    <a href="../Default.aspx">Мебель для ванной</a>
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
                <td><h1><asp:Literal runat="server" ID="lblCatalogTitle"></asp:Literal></h1></td>
            </tr>
        </table>
    </div>
    <div id="content">
        <mb:ProductListing ID="ProductListing" runat="server" />
    </div>
</asp:Content>
