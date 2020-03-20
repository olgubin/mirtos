<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="UC.UI._Default"
    MasterPageFile="~/Template.master" %>

<%@ MasterType VirtualPath="~/Template.master" %>
<%@ Register Src="Controls/Departments.ascx" TagName="Departments" TagPrefix="mb" %>
<%@ Register Src="Controls/WelcomeBox.ascx" TagName="Welcome" TagPrefix="mb" %>
<%@ Register Src="Controls/BannerHelp.ascx" TagName="BannerHelp" TagPrefix="mb" %>
<%@ Register Src="Controls/ColBox/ProductFeaturedBox.ascx" TagName="ProductFeaturedBox" TagPrefix="mb" %>

<asp:Content ID="AdvertBox" ContentPlaceHolderID="AdvertBox" runat="Server">
    <mb:ProductFeaturedBox ID="ProductFeatured" runat="server"/>
    <mb:BannerHelp ID="BannerHelp" runat="server"/>    
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
<%--<div class="breadcrumb">
    <div class="breadcrumb_middle">
        <table>
            <tr>
                <td>
                    <h1>
                        Климатическое оборудование</h1>
                </td>
            </tr>
        </table>
    </div>
    <div class="breadcrumb_left">
    </div>
    <div class="breadcrumb_right">
    </div>
</div>--%>
    <mb:Departments ID="Departments" runat="server" RepeatColumns="2" MainReferencePage="Departments.aspx" ReferencePage="Departments.aspx"/>
    <mb:Welcome ID="Welcome" runat="server" />
</asp:Content>
