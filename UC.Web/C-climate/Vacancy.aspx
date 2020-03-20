<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="Vacancy.aspx.cs" Inherits="UC.UI.Vacancy" %>
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
                        ��������</h1>
                </td>
            </tr>
        </table>
    </div>
    <div id="content">
        <p>
            <b>��� ������ ������</b> - �������� ������ ���������� � �����������������, ������������ 
            ������, ��������-������� ������</p>
        <p>
            <b>���������: </b>
        </p>
        <ul>
            <li>
                ������� �� �������� ���</li>
        </ul>
        <p>
            </p>
        <p>
            <b>����� ������:</b> 
        </p>
        <ul>
            <li>�. 
                ������, ��. ������������, 11, ���. 8 (�. ��������������)</li>
        </ul>
        <p>
            </p>
        <p>
            <b>����������� �����������: </b>
        </p>
        <ul>
            <li>�������� ����� ����� ��������; </li>
            <li>������������ � ����������� ����������� ��������������� � ���������, ���������� �����������, ��������� �� ������� � ������������� ������������;</li>
            <li>����������� ������������ � ������ ������������;</li>
            <li>����������� �������-������������ �����������, ����������� ������ �� ������, ���������� ���������;</li>
            <li>���������� ����� ������;</li>
            <li>�������� � ������������ ����������� �������������;</li>
            <li>����������� � ���������� �����������.</li>
        </ul>
        <p>
            </p>
        <p>
            <b>����������:</b></p>
        <ul>
            <li>������ ����������� (���������� �����������);</li>
            <li>������� 23-35 ���;</li>
            <li>���� ������ � ������� ������ ������ ����������������� � ���������� �� 3-� ���;</li>
            <li>������ ������������, ������ � ���������� �������;</li>
            <li>������ ����� ����������� ������������ (������������� �������);</li>
            <li>������ ���������� �����������;</li>
            <li>�� � ��������� ������������ (1� 7.0);</li>
        </ul>
        <p></p>
        <p><b>������� ������:</b></p>
        <ul>
            <li>�����  + % � ������ + ������;</li>
            <li>������ ������: 5�2 � 9.00 �� 18.00;</li>
            <li>���������� �� �� ��;</li>
            <li>��������� ����;</li>
        </ul>
        <br />
    </div>
</asp:Content>
