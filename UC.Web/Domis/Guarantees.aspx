<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Guarantees.aspx.cs" Inherits="UC.UI.Guarantees"
    MasterPageFile="~/Template.master" %>

<%@ Register Src="Controls/BreadCrumb.ascx" TagName="BreadCrumb" TagPrefix="mb" %>
<%@ Register Src="Controls/ColBox/ProductFeaturedBox.ascx" TagName="ProductFeaturedBox"
    TagPrefix="mb" %>
<asp:Content ID="AdvertBox" ContentPlaceHolderID="AdvertBox" runat="Server">
    <mb:ProductFeaturedBox ID="Recommend" runat="server" />
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <mb:BreadCrumb ID="BreadCrumb" runat="server" />
    <div id="content">
        <table CellPadding="0" cellspacing="0">
            <tr>
                <td>
                    <img src="Images/Brands/edelform.gif">
                </td>
                <td style="vertical-align:middle">
                        �������� �� ������ ��� ������ ������� EDELFORM � <b>2 ����</b>
                </td>
            </tr>
            <tr>
                <td>
                    <img src="Images/Brands/aqulife.gif" align="left" hspace="12">
                </td>
                <td style="vertical-align:middle">
                        �������� �� ������ ��� ������ ������� �������� � <b>2 ����</b>
                </td>
            </tr>
            <tr>
                <td>
                    <img src="Images/Brands/edelform.gif">
                </td>
                <td style="vertical-align:middle">
                        �������� �� ������� ������ EDELFORM � <b>2 ����</b>
                </td>
            </tr>
            <tr>
                <td>
                    <img src="Images/Brands/luxus.gif" align="left" hspace="12">
                </td>
                <td style="vertical-align:middle">
                        �������� �� ������� ������ LUXUS � <b>2 ����</b>
                </td>
            </tr>
        </table>
        <p>
            ��� ��������� �� �������� ���������� ������ ������������ ����������� ���������,
            ����������� ��������������� �������. (�������, ����������� �����, �������� ��������������
            ������).</p>
    </div>
</asp:Content>
