<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="SiteMap.aspx.cs" Inherits="UC.UI.SiteMapPage" %>
<%@ Register Src="Controls/BreadCrumb.ascx" TagName="BreadCrumb" TagPrefix="mb" %>
<%@ Register Src="Controls/SiteMap.ascx" TagName="SiteMap" TagPrefix="mb" %>
<%@ Register Src="Controls/ColBox/ProductFeaturedBox.ascx" TagName="ProductFeaturedBox" TagPrefix="mb" %>
<asp:Content ID="AdvertBox" ContentPlaceHolderID="AdvertBox" runat="Server">
    <mb:ProductFeaturedBox ID="Recommend" runat="server" />
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
<mb:BreadCrumb ID="BreadCrumb" runat="server" />
    <div id="content">
       <mb:SiteMap ID="ucSiteMap" runat="server" />
    </div>
</asp:Content>
