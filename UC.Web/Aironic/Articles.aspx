<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="Articles.aspx.cs" Inherits="UC.UI.BrowseArticles" %>

<%@ MasterType VirtualPath="~/Template.master" %>
<%@ Register Src="./Controls/ArticleListing.ascx" TagName="ArticleListing" TagPrefix="mb" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="breadcrumb">
        <table>
            <tr>
                <td class="h1">
                    <a href="Default.aspx">Главная</a>
                </td>
                <td>
                    <asp:Image ID="Image1" runat="server" SkinID="Separator" />
                </td>
                <td>
                    <h1>
                        <asp:Label ID="Label1" runat="server" Text="Статьи" /></h1>                    
                </td>
            </tr>
        </table>
    </div>
    <div id="content">
        <br />
        <mb:ArticleListing ID="ArticleListing" runat="server" PublishedOnly="True" ShowCategoryPicker="false" ShowCategoryTitle="false" />
    </div>
</asp:Content>
