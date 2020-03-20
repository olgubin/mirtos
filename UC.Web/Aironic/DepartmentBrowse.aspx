<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DepartmentBrowse.aspx.cs" Inherits="UC.UI.DepartmentBrowse" MasterPageFile="~/Template.master" %>
<%@ Register Src="Controls/Departments.ascx" TagName="Departments" TagPrefix="mb" %>
<%@ Register Src="Controls/ColBox/ProductFeaturedBox.ascx" TagName="ProductFeaturedBox" TagPrefix="mb" %>
<%@ Register Src="Controls/BreadCrumb.ascx" TagName="BreadCrumb" TagPrefix="mb" %>

<%--<asp:Content ID="AdvertBox" ContentPlaceHolderID="AdvertBox" runat="Server">
    <mb:ProductFeaturedBox ID="Recommend" runat="server"/>
</asp:Content>--%>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <mb:BreadCrumb ID="BreadCrumb" runat="server"/>
    <mb:Departments ID="Departments" runat="server" RepeatColumns="3" MainReferencePage="BrowseProducts.aspx" ReferencePage="BrowseProducts.aspx"/>
</asp:Content>
