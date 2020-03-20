<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="Departments.aspx.cs" Inherits="UC.UI.Departments" Culture="auto" UICulture="auto"%>
<%@ MasterType VirtualPath="~/Template.master" %>
<%--<%@ Register Src="~/Controls/DepartmentProductListing.ascx" TagName="DepartmentProductListing" TagPrefix="mb" %>--%>
<%@ Register Src="Controls/BreadCrumb.ascx" TagName="BreadCrumb" TagPrefix="mb" %>
<%@ Register Src="Controls/404.ascx" TagName="Control404" TagPrefix="mb" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <mb:BreadCrumb ID="BreadCrumb" runat="server" />
    <mb:Control404 runat="server" ID="ctrl404" />
    <asp:Panel runat="server" ID="pnlContent">
        <asp:PlaceHolder runat="server" ID="ProductPlaceHolder"></asp:PlaceHolder>
    </asp:Panel>
    <%--<mb:DepartmentProductListing ID="DepartmentProductListing1" runat="server" />--%>
</asp:Content>
