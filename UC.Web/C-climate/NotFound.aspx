<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="NotFound.aspx.cs" Inherits="UC.UI.NotFound" Culture="auto" UICulture="auto" %>

<%@ Register Src="Controls/ContactForm.ascx" TagName="ContactForm" TagPrefix="mb" %>
<%@ Register Src="Controls/Departments.ascx" TagName="Departments" TagPrefix="mb" %>
<%@ Register Src="Controls/WelcomeBox.ascx" TagName="Welcome" TagPrefix="mb" %>
<%@ Register Src="Controls/BannerHelp.ascx" TagName="BannerHelp" TagPrefix="mb" %>
<%@ Register Src="Controls/ColBox/ProductFeaturedBox.ascx" TagName="ProductFeaturedBox" TagPrefix="mb" %>

<asp:Content ID="AdvertBox" ContentPlaceHolderID="AdvertBox" runat="Server">
    <mb:ProductFeaturedBox ID="ProductFeatured" runat="server"/>
    <mb:BannerHelp ID="BannerHelp" runat="server"/>    
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="breadcrumb">
        <table>
            <tr>
                <td>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx" EnableViewState="false">�������</asp:HyperLink>
                </td>
                <td>
                    <asp:Image ID="Image1" runat="server" SkinID="Separator" />
                </td>
                <td>
                    <h1><asp:Label ID="lblTitle" runat="server" ForeColor="Red"/></h1>
                </td>
            </tr>
        </table>
    </div>
    <div id="content">
<%--        <p>
        </p>
        <asp:Label runat="server" SkinID="FeedbackKO" ID="lbl404" Text="�������� �������� ��� ������ �� �������." />
        <asp:Label runat="server" SkinID="FeedbackKO" ID="lbl408" Text="����� ���������� ������� �������. �������� ������ ����������. ���������� ��������� ������ ����� ��������� �����." />
        <asp:Label runat="server" SkinID="FeedbackKO" ID="lbl505" Text="������ ����������� � ����������� ��������, ������� �������� ��� ��������� ��� ������. ���������� ��������� ������ ����� ��������� �����." />
        <asp:Label runat="server" SkinID="FeedbackKO" ID="lblError" Visible="False" Text="��������� ������ ��� ��������� �������." />
        <p>
        </p>
        <center>
            <mb:ContactForm ID="ContactForm" runat="server" Title="�� ����� ����������, ���� �� �������� ��� � ���������, ��� ������� ��������� ������:"
                DefaultName="ErrorFromUser" DefaultEmail="info@MIRTOS.RU" DefaultSubject="��������� �� ������ �� ������������"
                ShowFieldCaption="false" />
        </center>--%>
        <mb:Departments ID="Departments" runat="server" RepeatColumns="2" MainReferencePage="Departments.aspx" ReferencePage="Departments.aspx"/>
        <mb:Welcome ID="Welcome" runat="server" />
    </div>
</asp:Content>
