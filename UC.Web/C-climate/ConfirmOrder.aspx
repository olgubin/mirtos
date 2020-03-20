<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="ConfirmOrder.aspx.cs" Inherits="UC.UI.ConfirmOrder" Culture="auto" UICulture="auto" %>
<%@ MasterType VirtualPath="~/Template.master" %>
<%@ Register Src="Controls/BreadCrumb.ascx" TagName="BreadCrumb" TagPrefix="mb" %>    
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <mb:BreadCrumb ID="BreadCrumb" runat="server"/>
    <div id="content">
        <p><asp:Label runat="server" ID="lblAdopt" /></p>
    </div>
</asp:Content>