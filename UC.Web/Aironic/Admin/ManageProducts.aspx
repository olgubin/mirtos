<%@ Page Language="C#" MasterPageFile="Admin.master" AutoEventWireup="true"
    CodeFile="ManageProducts.aspx.cs" Inherits="UC.UI.Admin.ManageProducts"
    Culture="auto" UICulture="auto" MaintainScrollPositionOnPostback="true" %>

<%@ Register Src="../Controls/ProductListing.ascx" TagName="ProductListing" TagPrefix="mb" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="breadcrumb">
            <table>
                <tr>
                <td class="h1">
                    <a href="../Default.aspx">Главная</a>
                </td>
                <td><asp:Image ID="Image1" runat="server" SkinID="Separator"/> </td>
                <td class="h1">
                    <a href="Default.aspx">Администрирование</a>
                </td>
                <td><asp:Image ID="Image2" runat="server" SkinID="Separator"/> </td>
                <td><h1>Управление товарами</h1></td>
                </tr>
            </table>
    </div>
    <div id="content">
        <p></p>
        <mb:ProductListing ID="ProductListing1" runat="server" />
    </div>
</asp:Content>
