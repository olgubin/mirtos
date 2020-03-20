<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="SearchResult.aspx.cs" Inherits="UC.UI.SearchResult" Culture="auto"
    UICulture="auto" %>

<%@ MasterType VirtualPath="~/Template.master" %>
<%@ Register Src="~/Controls/SearchProductListing.ascx" TagName="SearchProductListing" TagPrefix="mb" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="breadcrumb">
        <table>
            <tr>
                <td class="h1">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Главная</asp:HyperLink>
                </td>
                <td><asp:Image ID="Image1" runat="server" SkinID="Separator"/> </td>
                <td><h1>Результаты поиска</h1></td>
            </tr>
        </table>
    </div>
    
    
    <div id="content">
        <mb:SearchProductListing ID="SearchProductListing1" runat="server" />
    </div>
</asp:Content>
