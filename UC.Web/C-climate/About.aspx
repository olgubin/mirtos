<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="About.aspx.cs" Inherits="UC.UI.About" %>

<%@ Register Src="Controls/ColBox/ProductFeaturedBox.ascx" TagName="ProductFeaturedBox"
    TagPrefix="mb" %>
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
                        � ��������</h1>
                </td>
            </tr>
        </table>
    </div>
    <div id="content">
        <p />
        <p>
            �������� ��� ������ ������ ���������������� �� ��������������, ������� � ��������
            ������������ ��� ������ ���������� � �����������������.
        </p>
        <p>
            ���� �������� �������� ����������� ����������� ������ ����������, �����������������
            � ��������� ������������ �� ���� ������.
        </p>
        <p>
            �������� �����, � �������� �� ��������, �������� ��������� ����������� ��-�� ������������
            ����������� �����/��������.
        </p>
        <p>
            ��� ��������� �� ��� ���� ������������� ������ �����������������:
        </p>
        <p>
            <b>Daikin, Panasonic, LG, Toshiba, Sanyo, Hitachi, Haier, Mitsubishi, Kentatsu, Fujitsu,
                General</b>
        </p>
        <p>
            ������� ����������:
        </p>
        <p>
            <b>Systemair, Lindab, ����, �����-�</b>
        </p>
        <p>
            �������� ������:
        </p>
        <p>
            <b>�uroHeat, 2VV, Frico, Ned, Remak, Olefini/General</b>
        </p>
        <p>
            �������� ������ ������ ������ ���������������� ��� � ������� �� ��� ������� �� �����������
            ��������������� ������������. ��������� �������� ������ ������, ���� �����������
            ��������� ��� ��������� ��������� ������������, ����������� ��� ������ ������.
        </p>
        <p>
            �� ������������ ��������������� � �������������� ����������� �������������.
        </p>
        <p>
            �� �������� ������ ��� ����� �������� � ��������.
        </p>
        <p>
            <strong><a name="quest4"></a>��������� ��������</strong></p>
        <p>
            <div class="wizard">
                <table cellpadding="5px">
                    <tr>
                        <td>
                            <b>������������ �����������</b>
                        </td>
                        <td>
                            ����� ������, ���
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>����������� �����</b>
                        </td>
                        <td>
                            115230,�.������, ������ ��������������, 7
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>����</b>
                        </td>
                        <td>
                            1167746553754
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>���/���</b>
                        </td>
                        <td>
                            7724368592/7772401001
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>�������</b>
                        </td>
                        <td>
                            +7 (495) 005-53-95, +7 (499) 394-04-09
                        </td>
                    </tr>
                </table>
            </div>
            <p />
    </div>
</asp:Content>
