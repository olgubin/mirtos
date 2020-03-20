<%@ Page Language="C#" MasterPageFile="~/Template.master" ValidateRequest="false"
    AutoEventWireup="true" CodeFile="Newsletters.aspx.cs" Inherits="UC.UI.Newsletters" %>
<%@ Register Src="Controls/BreadCrumb.ascx" TagName="BreadCrumb" TagPrefix="mb" %>
<%@ Register Src="~/Controls/NewsletterListing.ascx" TagName="NewsletterListing"
    TagPrefix="mb" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
<mb:BreadCrumb ID="BreadCrumb" runat="server" />
    <div id="content">
        <p />
        <mb:NewsletterListing ID="NewsletterListing" runat="server" />
    </div>
</asp:Content>
