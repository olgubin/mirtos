<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="ShowDepartments.aspx.cs" Inherits="UC.UI.ShowDepartments" %><%@ MasterType VirtualPath="~/Template.master" %><%@ Register Src="Controls/Departments.ascx" TagName="Departments" TagPrefix="mb" %><asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server"><div class="sectiontitle"><asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:PageCaption %>" /></div><p></p><mb:Departments ID="Departments" runat="server" /></asp:Content>
