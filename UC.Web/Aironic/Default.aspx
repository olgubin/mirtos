<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="UC.UI._Default"
    MasterPageFile="~/Template.master" %>

<%@ MasterType VirtualPath="~/Template.master" %>
<%@ Register Src="Controls/Departments.ascx" TagName="Departments" TagPrefix="mb" %>
<%@ Register Src="Controls/WelcomeBox.ascx" TagName="Welcome" TagPrefix="mb" %>
<%@ Register Src="Controls/BannerHelp.ascx" TagName="BannerHelp" TagPrefix="mb" %>
<%@ Register Src="Controls/ColBox/ProductFeaturedBox.ascx" TagName="ProductFeaturedBox" TagPrefix="mb" %>
<%@ Register Src="Controls/BreadCrumb.ascx" TagName="BreadCrumb" TagPrefix="mb" %>

<%--<asp:Content ID="AdvertBox" ContentPlaceHolderID="AdvertBox" runat="Server">
    <mb:ProductFeaturedBox ID="ProductFeatured" runat="server"/>
    <mb:BannerHelp ID="BannerHelp" runat="server"/>    
</asp:Content>--%>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <mb:BreadCrumb ID="BreadCrumb" runat="server"/>
    <mb:Departments ID="Departments" runat="server" RepeatColumns="2" MainReferencePage="BrowseProducts.aspx" ReferencePage="BrowseProducts.aspx" DepartmentID="5"/>
    <mb:Welcome ID="Welcome" runat="server" />
</asp:Content>
