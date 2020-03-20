<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="BrowseProducts.aspx.cs" Inherits="UC.UI.BrowseProducts" Culture="auto"
    UICulture="auto"%>

<%@ MasterType VirtualPath="~/Template.master" %>
<%--<%@ Register Src="~/Controls/DepartmentProductListing.ascx" TagName="DepartmentProductListing" TagPrefix="mb" %>--%>
<%@ Register Src="Controls/BreadCrumb.ascx" TagName="BreadCrumb" TagPrefix="mb" %>    
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <mb:BreadCrumb ID="BreadCrumb" runat="server"/>
    <asp:PlaceHolder runat="server" ID="ProductPlaceHolder"></asp:PlaceHolder>
    <%--<mb:DepartmentProductListing ID="DepartmentProductListing1" runat="server" />--%>
</asp:Content>
