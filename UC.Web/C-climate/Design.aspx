<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="Design.aspx.cs" Inherits="UC.UI.Design" %>
<%@ Register Src="Controls/ColBox/ProductFeaturedBox.ascx" TagName="ProductFeaturedBox" TagPrefix="mb" %>
<asp:Content ID="AdvertBox" ContentPlaceHolderID="AdvertBox" runat="Server">
    <mb:ProductFeaturedBox ID="Recommend" runat="server" />
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
                    <h1>
                        ��������������</h1>
                </td>
            </tr>
        </table>
    </div>
    <div id="content">
        <p />
        <p>
            �������� ������ ������ ���������� ������ �� �������������� ������ ���������� � �����������������.
        </p>
        <p>
            ��� ���������������� ���������� ��������� ������������ �� �������� ������������
            � ����������� ��������������� ����������� �� ���� ������� ���������� � �����������������.
            ��� ���������� ���� - �� �������� ���������� �������� ����������� ������� ���������,
            ����� ������� � �������� ������������ ������. �������� ���������� ������ ������ ������
            ����� ������� ���� �������������� ������ ���������� � ����������������� ����������������
            � ������������ ������, ����������� ������������� �������, �������� � ���������������
            �������, ��������� � �������.
        </p>
        <p>
            ����������� ������ �� ��������������:
        </p>
        <ul>
            <li>���������� �������� ������ ���������� � ����������������� ����� ���������.</li>
            <li>���������� ��������� ����, ���������� ��� ����������� ���������� ��� ������� �����-������,
                ��������� , VRV � ��.</li>
            <li>������������ ���������-��������������� �� �������� �����������������, ����������
                � ���������.</li>
            <li>����� ����������� �� ������ ���������, ������������ �� �����.</li>
            <li>���������� ������������ ����������� (������ ������������, ������ ������� ���������
                ������������, ��������� ����� � ����������).</li>
            <li>������ � �������� ��������� � ������������ �������.</li>
        </ul>
        <p>
            ��������� ������� ������� �� ����, ������� � ������������� ���������, � ��� �����
            ���� ������������ ������������ � ��������� ���������.
        </p>
    </div>
</asp:Content>
