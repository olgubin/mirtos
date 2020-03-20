<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="Service.aspx.cs" Inherits="UC.UI.Service" %>
<%@ Register Src="Controls/BreadCrumb.ascx" TagName="BreadCrumb" TagPrefix="mb" %>    
<%@ Register Src="Controls/ColBox/ProductFeaturedBox.ascx" TagName="ProductFeaturedBox" TagPrefix="mb" %>
<asp:Content ID="AdvertBox" ContentPlaceHolderID="AdvertBox" runat="Server">
    <mb:ProductFeaturedBox ID="Recommend" runat="server" />
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
<mb:BreadCrumb ID="BreadCrumb" runat="server" />
    <div id="content">
        <p />
        <p>
            ��������� ������ ������������ ��������� ������������
            ������� �����.
        </p>
        <p>
            �� ��������� ��������� ����� � ��������� ���������� ������������ �������� ��������.
        </p>
        <p>
            ��������� ���������������� � ��������� ����� ������������ ����� ������ �������� �� ������ ���������.
        </p>
        <p>
            ����� �������� ��������� ������ ��� ���������� ����������� ������������, � �����
            ����������� ��������� ��������� ����� �������������� - ������.
        </p>
        <p>
            ��������������� ��������� ���������� ������������, ����� ��������, ���������� �
            ��������� ������������ ������ �� �������� � <b>(495)514-86-37</b>.
        </p>
        <p>
            <b>�� ��� ����������� ������ �� ������������� �������� 1 ���.</b>
        </p>
        <p />
    </div>
</asp:Content>
