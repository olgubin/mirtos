<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="Dealer.aspx.cs" Inherits="UC.UI.Dealer" %>
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
                        �������</h1>
                </td>
            </tr>
        </table>
    </div>
    <div id="content">
        <p>
            ������� �� ����� ������������� �������, �� ������ ��������� ����������� ����� �������,
            �� ����������� ��� ���� ����� ���������.</p>
        <p>
            �� �������������� � ����������� ������������� ����������������� ������������.</p>
        <p>
            �� ����������� ���� �������� ���������� ����� �� ������������ ��������� ������������,
            ����������������� ���� �����������, �������������� �������� � �������� ������� �����.</p>
        <p>
            ������������ ������ � ����� ���������:</p>
        <ul type="disc">
            <li>���������� ������ � ��� ����� � ������ �������������� � �������������� �������</li>
            <li>������������� �������� ��������� �� �����������, ������������� �������� � ����</li>
            <li>������� ����������� ������������</li>
            <li><b>����������� �����</b> (������������ �� ����������� ��������, ��������� �������)</li>
            <li><b>��������� �����</b> (����������� ���������� ���-�������, �����-���������� ������,
                ����� �������� �� ������)</li>
            <li><b>����� ������� � ��������������� ������������</b> (���������� ��������� �� �����������
                ���������� ������������ ������������ � ���������) </li>
            <li><b>��������� �����</b> (���������� ����������� ������������; ���������� ��������
                �� �������� ����������, �����������������, ��������� � �������������; ������� ������)</li>
            <li>�������� �� ������ ����� ������������ ��������, ������� ������ ���</li>
            <li>�������� �������������� ��������� (��������, �������, �����������, ��������)</li>
        </ul>
        <p><b>����������� ������������ ��������� ��������������:</b></p>
        <div class="wizard">
            <table style="width:100%">
                <tbody>
                    <tr>
                        <th>������� �����������������</th>
                        <th>�������� ������������</th>
                    </tr>
                    <tr>
                        <td style="vertical-align:top">
                    <ul style="list-style-type:none">
                        <li><b>Daikin</b></li>
                        <li><b>General Fujitsu</b></li>
                        <li><b>Toshiba</b></li>
                        <li><b>Sanyo</b></li>
                        <li><b>Mitsubishi Electric</b></li>
                        <li><b>General Climate</b></li>
                        <li><b>Panasonic</b></li>
                        <li><b>Hitachi</b></li>
                        <li><b>Haier</b></li>
                        <li><b>Kentatsu</b></li>
                        <li><b>LG</b></li>
                        <li><b>Midea</b></li>
                        <li><b>Lessar</b></li>
                    </ul>
                        </td>
                        <td style="vertical-align:top">
                    <ul style="list-style-type:none">
                        <li><b>��������</b></li>
                        <li><b>Frico</b></li>
                        <li><b>������</b></li>
                        <li><b>2VV</b></li>
                        <li><b>EuroHeat</b></li>
                        <li><b>Olefini/General</b></li>
                        <li><b>NED</b></li>
                        <li><b>Korf</b></li>
                        <li><b>Remak</b></li>
                        <li><b>Pyrox</b></li>
                        <li><b>Ensto</b></li>
                    </ul>
                        </td>
                    </tr>
                    <tr>
                        <th>������� ����������</th>
                        <th>���������</th>
                    </tr>
                    <tr>
                        <td style="vertical-align:top">
                    <ul style="list-style-type:none">
                        <li><b>NED</b></li>
                        <li><b>�����-�</b></li>
                        <li><b>Lindab</b></li>
                        <li><b>Systemair</b></li>
                    </ul>
                        </td>
                        <td style="vertical-align:top">
                    <ul style="list-style-type:none">
                        <li><b>Global</b></li>
                        <li><b>Purmo</b></li>
                        <li><b>Danfoss</b></li>
                        <li><b>Bugatti</b></li>
                        <li><b>RBM</b></li>
                    </ul>
                        </td>
                    </tr>
                </tbody>
            </table>        
        </div>
        <p>
        </p>
    </div>
</asp:Content>
