<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="Articles.aspx.cs" Inherits="UC.UI.BrowseArticles" %>
<%@ Register Src="Controls/BreadCrumb.ascx" TagName="BreadCrumb" TagPrefix="mb" %>
<%@ MasterType VirtualPath="~/Template.master" %>
<%@ Register Src="./Controls/ArticleListing.ascx" TagName="ArticleListing" TagPrefix="mb" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
<mb:BreadCrumb ID="BreadCrumb" runat="server" />
    <div id="content">
        <br />
        <mb:ArticleListing ID="ArticleListing" runat="server" PublishedOnly="True" ShowCategoryPicker="false" ShowCategoryTitle="false" />
    </div>
</asp:Content>
