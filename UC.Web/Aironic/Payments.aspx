<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Payments.aspx.cs" Inherits="UC.UI.Payments" MasterPageFile="~/Template.master" %>
<%@ Register Src="Controls/ColBox/ProductFeaturedBox.ascx" TagName="ProductFeaturedBox" TagPrefix="mb" %>
<%--<asp:Content ID="AdvertBox" ContentPlaceHolderID="AdvertBox" runat="Server">
    <mb:ProductFeaturedBox ID="Recommend" runat="server" />
</asp:Content>--%>
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
                        ������</h1>
                </td>
            </tr>
        </table>
    </div>
    <div id="content">
        <h3>
            ��������:</h3>
        <ul>
            <p>
                ����� ������������ � ������ ��������� ������. ������ ������������ ������ � ������.
               <b>������ ��� ������ �������� ������ ��� ������ � M���������
            �������</b>.
        </ul>
        <h3>
            �����������:</h3>
        <ul>
            <b>������ ��������� ����� ���� (��� ���������� ���)</b>
            <br>
            <br>
            <p>
                ����� ���������� ������ �� �������� ����������� � ������ ������ �� ������������
                �� ��������� ���� ��� ����������� ����������� �����. ����� ������������� �������
                ����� �� ������ ������ �������� � ������.
                <p>
                    ��� ������������ ���� �� ������ ������� ������������ ��� �� ����������� ����� ��� �����, ��������� � ����� ������. 
                    <p>
                        ��������! ������������ ��������� ������������� � ������� 3-� ���������� ����.
                        <p>
                            ���������� ����� � ����� �����, ����������� ������� �� ������� ���. ��� ��������
                            ������� ���� ������� ��������. ����������, ������� ��������������� ��������� ��������
                            � ����� �����.
                            <p>
                                ����� �������� ������, ������� ������� ����� ��������� �� ����� <a href="mailto:zakaz@aironic.ru">zakaz@aironic.ru</a> ��� �� �����.
                                <p><hr style="width:100%;size:1px;color:#d7c5ab" noshade=""/></p>
                                <b>������ �� ������������ ������� (��� ����������� ���)</b>
                                <br>
                                <br>
                                <p>
                                    ����� ���������� ������ �� ��������� ����������� � ������ ������ �� ������������
                                    �� ��������� ���� ��� ����������� ����������� �����. ����� ������������� �������
                                    ����� �� ������ ������ �������� � ������.
                                    <p>
                                        ��� ������ �� ������������ ����, ��� ����������, ��� ���������� ������ ������� ������� ������ "����������� ������".
                                        <p>
                                            ��� ������������ ����, ������� ����� ������� �� ����������� ����� ��� �� �����.
                                            <p>
                                                ��������! ������������ ���� ������������ � ������� 3-� ���������� ����.
                                                <p>
        ����� �������� ������, ������� ������� ����� ���������� ��������� �� ����� <a href="mailto:zakaz@aironic.ru">zakaz@aironic.ru</a> ��� �� �����.
    </div>
</asp:Content>
