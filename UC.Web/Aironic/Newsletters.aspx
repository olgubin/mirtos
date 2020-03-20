<%@ Page Language="C#" MasterPageFile="~/Template.master" ValidateRequest="false"
    AutoEventWireup="true" CodeFile="Newsletters.aspx.cs" Inherits="UC.UI.Newsletters" %>

<%@ Register Src="~/Controls/NewsletterListing.ascx" TagName="NewsletterListing"
    TagPrefix="mb" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="breadcrumb">
        <table>
            <tr>
                <td class="h1">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Главная</asp:HyperLink>
                </td>
                <td>
                    <asp:Image ID="Image1" runat="server" SkinID="Separator" />
                </td>
                <td>
                    <h1>
                        <asp:Label ID="Label1" runat="server" Text="Новости" /></h1>
                </td>
            </tr>
        </table>
    </div>
    <div id="content">
        <p />
        <mb:NewsletterListing ID="NewsletterListing" runat="server" />
    </div>
</asp:Content>
